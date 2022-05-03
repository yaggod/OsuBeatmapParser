using System.Text.RegularExpressions;

namespace OsuBeatmapParser.Model.Beatmap.Objects
{
    public class Spinner : HitObject
    {
        protected override string _regexPattern => @"^(?<x>-?\d+),(?<y>-?\d+),(?<timeStamp>-?\d+),(?<typeMask>\d+),(?<hitsoundsMask>\d+),(?<endTime>-?\d+)(,(?<hitSample>[0-4]:[0-4]:\d+:\d+:\w*))?$";
       
        public int EndTime {get; set; }
        public new static Spinner FromString(string s)
        {
            Spinner result = new Spinner(s);
        
            return result;
        }
        public Spinner(string s) : base(s)
        {
            Match match = Regex.Match(s ,_regexPattern);
            if(!match.Success) throw new ArgumentException(nameof(s) + " is not " + nameof(HitCircle));
            
        }
    }
}