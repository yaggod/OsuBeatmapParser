using System.Text.RegularExpressions;

namespace OsuBeatmapParser.Model.Beatmap.Sections
{
    public abstract class ValueKeyBeatmapSection : BeatmapSection
    {
        protected Dictionary<string, string> _keyValueDictionary = new();
        public string this[string s] 
        {
            get => _keyValueDictionary[s];
            set => _keyValueDictionary[s] = value;
        }

        public int Length => _keyValueDictionary.Count();
        protected ValueKeyBeatmapSection(string s)
        {
            _keyValueDictionary = GetDictionaryFromKeyValueString(s);
        }

        public static Dictionary<string, string> GetDictionaryFromKeyValueString(string s)
        {
            Dictionary<string, string> result = new();

            Regex regex = new Regex(@"^(?<key>.*): *(?<value>.*)$", RegexOptions.Multiline);
            foreach(Match match in regex.Matches(s))
            {
                result.Add(match.Groups["key"].Value, match.Groups["value"].Value.Trim());
            }

            return result;
        }
    }
}