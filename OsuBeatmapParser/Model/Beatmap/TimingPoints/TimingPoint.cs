using System.Globalization;
using System.Text.RegularExpressions;

namespace OsuBeatmapParser.Model.Beatmap.TimingPoints
{
    public class TimingPoint
    {
        protected string _regexPattern => @$"^(?<{nameof(Time)}>-?\d+),(?<{nameof(BeatLength)}>-?\d+(\.\d+)?),(?<{nameof(Meter)}>\d+),(?<{nameof(SampleSet)}>\d+),(?<{nameof(SampleIndex)}>\d+),(?<{nameof(Volume)}>\d+),(?<{nameof(UnInherited)}>[01]),(?<{nameof(Effects)}>\d+)$";
        public int Time { get; set; }
        public decimal BeatLength { get; set; }
        public decimal Meter { get; set; }
        public int SampleSet { get; set; } // TODO: replace with enum
        public int SampleIndex { get; set; }
        public int Volume { get; set; } // TODO: add logics in setter
        public bool UnInherited { get; set; }
        public int Effects { get; set; } // TODO: replace with enum

        public static TimingPoint FromString(string s)
        {
            return new TimingPoint(s);
        }

        private TimingPoint(string s)
        {
            Match match = Regex.Match(s, _regexPattern);

            Time = Int32.Parse(match.Groups[nameof(Time)].Value);
            SampleSet = Int32.Parse(match.Groups[nameof(SampleSet)].Value);
            SampleIndex = Int32.Parse(match.Groups[nameof(SampleIndex)].Value);
            Volume = Int32.Parse(match.Groups[nameof(Volume)].Value);
            Effects = Int32.Parse(match.Groups[nameof(Effects)].Value);

            Meter = Decimal.Parse(match.Groups[nameof(Meter)].Value, CultureInfo.InvariantCulture.NumberFormat);
            BeatLength = Decimal.Parse(match.Groups[nameof(BeatLength)].Value, CultureInfo.InvariantCulture.NumberFormat);
            
            UnInherited = match.Groups[nameof(UnInherited)].Value != "0";
        }

    }
}