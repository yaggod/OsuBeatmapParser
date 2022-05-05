using DictionaryDeserializer;


namespace OsuBeatmapParser.Model.Beatmap.Sections
{
    public class GeneralSection : ValueKeyBeatmapSection
    {

        public string? AudioFilename { get; set;}
        public int AudioLeadIn { get; set;} = 0;
        public int PreviewTime { get; set;} = -1;
        public int Countdown { get; set;} = 1;
        public string SampleSet { get; set;} = "Normal";
        public decimal StackLeniency { get; set;} = 0.7M;
        public int Mode { get; set;} = 0;
        public bool LetterboxInBreaks { get; set;} = false;
        public bool UseSkinSprites { get; set;} = false;
        public string OverlayPosition { get; set;} = "NoChange";
        public string? SkinPreference { get; set;}
        public bool EpilepsyWarning { get; set;} = false;
        public int CountdownOffset { get; set;} = 0;
        public bool SpecialStyle { get; set;} = false;
        public bool WidescreenStoryboard { get; set;} = false;
        public bool SamplesMatchPlaybackRate { get; set;} = false;
        public static GeneralSection FromString(string s)
        {
            Dictionary<string, string> dictionary = GetDictionaryFromKeyValueString(s);

            return new DictionaryDeserializer.DictionaryDeserializer().DeserializeFrom<GeneralSection>(dictionary);

        }
        
    }
}
