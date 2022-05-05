using System.IO;
using System.Text.RegularExpressions;
using OsuBeatmapParser.Model.Beatmap.Sections;
using OsuBeatmapParser.Model.Beatmap.Objects;
using OsuBeatmapParser.Model.Beatmap.TimingPoints;


namespace OsuBeatmapParser.Model.Beatmap
{
    public class Beatmap
    {
        private const string _regexPattern = @$"\[General\](?<{nameof(General)}>.*)\[Editor\](?<{nameof(Editor)}>.*)\[Metadata\](?<{nameof(Metadata)}>.*)\[Difficulty\](?<{nameof(Difficulty)}>.*)\[Events\](?<{nameof(Events)}>.*)\[TimingPoints\](?<{nameof(TimingPoints)}>.*)(\[Colours\](?<{nameof(SkinColoursSection)}>.*))\[HitObjects\](?<{nameof(HitObjects)}>.*)";
        

        public GeneralSection? General { get; private set; }
        public EditorSection? Editor { get; private set; }
        public MetadataSection? Metadata { get; private set; }
        public DifficultySection? Difficulty { get; private set; }
        // TODO: Events
        public object Events => throw new NotImplementedException();
        public List<TimingPoint>? TimingPoints { get; private set;} 
        // TODO: public SkinColoursSection? Colours { get; private set; }
        public object SkinColoursSection => throw new NotImplementedException();
        public List<HitObject>? HitObjects { get; private set; }
        
        public static Beatmap FromFile(FileInfo file)
        {
            using(var reader = file.OpenText())
            {
                return FromString(reader.ReadToEnd());
            }
        }
        public static Beatmap FromString(string s)
        {
            return new Beatmap(s);
        }

        private Beatmap(string s) 
        {
            Regex regex = new(_regexPattern, RegexOptions.Singleline);
            s = s.Trim();

            var matchGroups = regex.Match(s).Groups;
            setupSectionsFromGroups(matchGroups);
            setupHitObjectsFromString(matchGroups[nameof(HitObjects)].Value);
            setupTimingPointsFromString(matchGroups[nameof(TimingPoints)].Value);
        }

        private void setupSectionsFromGroups(GroupCollection matchGroups)
        {
            General = GeneralSection.FromString(matchGroups[nameof(General)].Value);
            Editor  = EditorSection.FromString(matchGroups[nameof(Editor)].Value);
            Metadata = MetadataSection.FromString(matchGroups[nameof(Metadata)].Value);
            Difficulty = DifficultySection.FromString(matchGroups[nameof(Difficulty)].Value);
        }
        private void setupHitObjectsFromString(string s)
        {
            HitObjects = new();
            foreach(var subString in s.Split('\n', StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries))
            {
                HitObjects.Add(HitObject.FromString(subString));
                
            }
        }
        private void setupTimingPointsFromString(string s)
        {
            TimingPoints = new();
            foreach(var subString in s.Split('\n', StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries))
            {
                TimingPoints.Add(TimingPoint.FromString(subString));
            }
        }
       
    }
}