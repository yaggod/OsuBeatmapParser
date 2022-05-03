namespace OsuBeatmapParser.Model.Beatmap.Sections
{
    public class GeneralSection : ValueKeyBeatmapSection
    {
        public static GeneralSection FromString(string s)
        {
            return new GeneralSection(s);
        }

        public GeneralSection(string s) : base(s) {}
    }
}
