namespace OsuBeatmapParser.Model.Beatmap.Sections
{
    public class DifficultySection : ValueKeyBeatmapSection
    {

        public decimal HPDrainRate { get; set; }
        public decimal CircleSize { get; set; }
        public decimal OverallDifficulty { get; set; }
        public decimal ApproachRate { get; set; }
        public decimal SliderMultiplier { get; set; }
        public decimal SliderTickRate { get; set; }
        public static DifficultySection FromString(string s)
        {
            Dictionary<string, string> dictionary = GetDictionaryFromKeyValueString(s);

            return new DictionaryDeserializer.DictionaryDeserializer().DeserializeFrom<DifficultySection>(dictionary);

        }
    }
}
