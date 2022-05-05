namespace OsuBeatmapParser.Model.Beatmap.Sections
{
    public class EditorSection : ValueKeyBeatmapSection
    {

        // TODO: public decimal Bookmarks { get; set; }
        public decimal DistanceSpacing { get; set; }	
        public decimal BeatDivisor { get; set; }
        public int GridSize { get; set; }
        public decimal TimelineZoom { get; set; }

         public static EditorSection FromString(string s)
        {
            Dictionary<string, string> dictionary = GetDictionaryFromKeyValueString(s);

            return new DictionaryDeserializer.DictionaryDeserializer().DeserializeFrom<EditorSection>(dictionary);

        }
    }
}
