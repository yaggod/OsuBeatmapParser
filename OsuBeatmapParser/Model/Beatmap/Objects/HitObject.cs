using System.Text.RegularExpressions;

namespace OsuBeatmapParser.Model.Beatmap.Objects
{
    public abstract class HitObject
    {
        private static string _hitObjectRegexPattern => @"^(?<x>-?\d+),(?<y>-?\d+),(?<timeStamp>-?\d+),(?<typeMask>\d+),(?<hitsoundsMask>-?\d+)(,(?<objectParams>.*))?(,(?<hitSample>[0-4]:[0-4]:\d+:\d+:\w*))?$";
        
        protected abstract string _regexPattern { get;}
        public int X { get; set; }
        public int Y { get; set; }
        public int TimeStamp { get; set; }

        public HitObjectType ObjectType { get; set;}

        //public abstract HitObject FromString(string s);
        public static HitObject FromString(string s)
        {
            Regex regex = new Regex(_hitObjectRegexPattern, RegexOptions.Multiline);
            Match match = regex.Match(s);
            if(!match.Success) throw new ArgumentException(nameof(s));

            HitObjectType type = (HitObjectType)Int32.Parse(match.Groups["typeMask"].Value);
            if(type.HasFlag(HitObjectType.HitCircle))
                return HitCircle.FromString(s);
            if(type.HasFlag(HitObjectType.Slider))
                return Slider.FromString(s);
            if(type.HasFlag(HitObjectType.Spinner))
                return Spinner.FromString(s);
                
            throw new ArgumentException("HitObject can not be created");
        }

        protected HitObject(string s)
        {
            Match match = Regex.Match(s ,_regexPattern);

            X = Int32.Parse(match.Groups["x"].Value);
            Y = Int32.Parse(match.Groups["y"].Value);
            TimeStamp = Int32.Parse(match.Groups["timeStamp"].Value);
            ObjectType = (HitObjectType)Int32.Parse(match.Groups["typeMask"].Value);
        }
    }
}