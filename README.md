# OsuBeatmapParser
Osu beatmap parser with regular expressions

Beatmap used in tests: https://osu.ppy.sh/beatmapsets/773014#osu/2151273

TODO:
  - Avoid code repeating in sections classes
  - Replace group names for patterns by nameof() operator (almost done, only HitObject classes left)
  - Slider path calculator (bezier curve is implemented in https://github.com/yaggod/BezierCurveApp), Point class
  - Osu!mania holds support

Not important:
  - Hitsounds support
  - Events support
  - Colours section support

Done:
- Proper Key:Value sections parsing 
- Main functionality
- Timing points support
