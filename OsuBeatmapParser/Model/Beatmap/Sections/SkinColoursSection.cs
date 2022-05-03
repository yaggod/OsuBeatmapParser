
namespace OsuBeatmapParser.Model.Beatmap.Sections
{
    public class SkinColoursSection : ValueKeyBeatmapSection
    {

        public static SkinColoursSection FromString(string s)
        {
            return new SkinColoursSection(s);
        }

        public SkinColoursSection(string s) : base(s) {}
    }
}
