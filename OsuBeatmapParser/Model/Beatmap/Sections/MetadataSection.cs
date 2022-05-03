namespace OsuBeatmapParser.Model.Beatmap.Sections
{  
    public class MetadataSection : ValueKeyBeatmapSection
    {
        public static MetadataSection FromString(string s)
        {
            return new MetadataSection(s);
        }

        public MetadataSection(string s) : base(s) {}
    }
}
