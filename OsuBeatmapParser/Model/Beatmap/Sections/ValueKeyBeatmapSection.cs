using System.Text.RegularExpressions;

namespace OsuBeatmapParser.Model.Beatmap.Sections
{
    public abstract class ValueKeyBeatmapSection : BeatmapSection
    {
        protected static Dictionary<string, string> GetDictionaryFromKeyValueString(string s)
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