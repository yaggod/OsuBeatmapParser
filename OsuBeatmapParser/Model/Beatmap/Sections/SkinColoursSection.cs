
namespace OsuBeatmapParser.Model.Beatmap.Sections
{
    public class SkinColoursSection : ValueKeyBeatmapSection
    {

         public static SkinColoursSection FromString(string s)
        {
            Dictionary<string, string> dictionary = GetDictionaryFromKeyValueString(s);

            return new DictionaryDeserializer.DictionaryDeserializer().DeserializeFrom<SkinColoursSection>(dictionary);

        }
    }
}
