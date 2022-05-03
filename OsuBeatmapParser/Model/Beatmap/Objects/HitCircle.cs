using System.Text.RegularExpressions;

namespace OsuBeatmapParser.Model.Beatmap.Objects
{
    public class HitCircle : HitObject
    {
        protected override string _regexPattern => @"^(?<x>-?\d+),(?<y>-?\d+),(?<timeStamp>-?\d+),(?<typeMask>\d+),(?<hitsoundsMask>-?\d+)(,(?<hitSample>[0-4]:[0-4]:\d+:\d+:\w*))?$";



        public new static HitCircle FromString(string s)
        {
            HitCircle result = new HitCircle(s);
           
            return result;
        }
        public HitCircle(string s) : base(s)
        {
        }

    }
}