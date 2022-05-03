namespace OsuBeatmapParser.Model.Beatmap.Sections
{
    public class EditorSection : ValueKeyBeatmapSection
    {
        public static EditorSection FromString(string s)
        {
            return new EditorSection(s);
        }

        public EditorSection(string s) : base(s) {}
    }
}
