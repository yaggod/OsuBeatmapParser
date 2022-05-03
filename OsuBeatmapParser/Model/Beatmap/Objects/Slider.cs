using System.Globalization;
using System.Text.RegularExpressions;

namespace OsuBeatmapParser.Model.Beatmap.Objects
{
    public class Slider : HitObject
    {
        protected override string _regexPattern => @"^(?<x>-?\d+),(?<y>-?\d+),(?<timeStamp>-?\d+),(?<typeMask>\d+),(?<hitsoundsMask>\d+),(?<sliderType>[B,C,L,P])(?<sliderPath>(\|-?\d+:-?\d+)+),(?<slidesCount>\d+),(?<length>-?\d+(\.\d+)?)(,(?<edgeSounds>\d+(\|\d+)+),(?<edgeSets>\d+:\d+(\|\d+:\d+)+))?(,(?<hitSample>[0-4]:[0-4]:\d+:\d+:\w*))?$";

        public SliderCurveType CurveType { get; set; }
        // TODO: public List<Point> CurvePath { get; private set; }
        public int SlidesCount { get; set; }
        public float SliderLength { get; set; }


        public new static Slider FromString(string s)
        {
            Slider result = new Slider(s);
            return result;
        }

        private Slider(string s) : base(s)
        {
            Match match = Regex.Match(s ,_regexPattern);
            if(!match.Success) throw new ArgumentException(nameof(s) + " is not " + nameof(HitCircle));

            
            CurveType = (SliderCurveType)Enum.Parse(typeof(SliderCurveType), match.Groups["sliderType"].Value);
            // Список точек
            SlidesCount = Int32.Parse(match.Groups["slidesCount"].Value);
            SliderLength = Single.Parse(match.Groups["length"].Value, CultureInfo.InvariantCulture.NumberFormat);
        }

    }
}