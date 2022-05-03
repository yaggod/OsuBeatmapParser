namespace OsuBeatmapParser.Model.Beatmap.Sections
{
    public class DifficultySection : ValueKeyBeatmapSection
    {
        public static DifficultySection FromString(string s)
        {
            return new DifficultySection(s);
        }

        public DifficultySection(string s) : base(s) {}
    }
}
