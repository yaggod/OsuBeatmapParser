using System.IO;
using System.Text.RegularExpressions;
using OsuBeatmapParser.Model.Beatmap.Sections;
using OsuBeatmapParser.Model.Beatmap.Objects;

namespace OsuBeatmapParser.Model.Beatmap
{
    public class Beatmap
    {
        private const string _regexPattern = @"\[General\](?<General>.*)\[Editor\](?<Editor>.*)\[Metadata\](?<Metadata>.*)\[Difficulty\](?<Difficulty>.*)\[Events\](?<Events>.*)\[TimingPoints\](?<TimingPoints>.*)(\[Colours\](?<Colours>.*))?\[HitObjects\](?<HitObjects>.*)";
        

        public GeneralSection? General { get; private set; }
        public EditorSection? Editor { get; private set; }
        public MetadataSection? Metadata { get; private set; }
        public DifficultySection? Difficulty { get; private set; }
        // Events
        // TimingPoints 
        public SkinColoursSection? Colours { get; private set; }
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
            setupHitObjectsFromString(matchGroups["HitObjects"].Value);
        }

        private void setupSectionsFromGroups(GroupCollection matchGroups)
        {
            General = GeneralSection.FromString(matchGroups["General"].Value);
            Editor  = EditorSection.FromString(matchGroups["Editor"].Value);
            Metadata = MetadataSection.FromString(matchGroups["Metadata"].Value);
            Difficulty = DifficultySection.FromString(matchGroups["Difficulty"].Value);
            Colours = SkinColoursSection.FromString(matchGroups["Colours"].Value);
        }
        private void setupHitObjectsFromString(string s)
        {
            HitObjects = new();
            foreach(var subString in s.Split('\n', StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries))
            {
                HitObjects.Add(HitObject.FromString(subString));
                
            }
        }


       
    }
}