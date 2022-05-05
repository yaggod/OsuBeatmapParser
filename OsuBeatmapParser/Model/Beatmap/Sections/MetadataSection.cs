namespace OsuBeatmapParser.Model.Beatmap.Sections
{  
    public class MetadataSection : ValueKeyBeatmapSection
    {
        public string? Title { get; set ;}
        public string? TitleUnicode { get; set; }
        public string? Artist { get; set; }
        public string? ArtistUnicode { get; set; }
        public string? Creator { get; set; }
        public string? Version { get; set; }
        public string? Source { get; set; }
        public string? Tags { get; set; }
        public int BeatmapID { get; set; }
        public int BeatmapSetID { get; set; }

         public static MetadataSection FromString(string s)
        {
            Dictionary<string, string> dictionary = GetDictionaryFromKeyValueString(s);

            return new DictionaryDeserializer.DictionaryDeserializer().DeserializeFrom<MetadataSection>(dictionary);

        }
    }
}
