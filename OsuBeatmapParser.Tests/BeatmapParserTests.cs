using Xunit;
using OsuBeatmapParser.Model.Beatmap;
using OsuBeatmapParser.Model.Beatmap.Objects;
using OsuBeatmapParser.Model.Beatmap.Sections;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System;

namespace OsuBeatmapParser.Tests;

public class UnitTest1
{
        FileInfo becauseMaybeFullSize = new FileInfo(@"Renard - Because Maybe! (Mismagius) [- Nogard Marathon v2 -].osu");

    [Fact]
    public void TestHitObjects()
    {
        Beatmap becauseMaybe = Beatmap.FromFile(becauseMaybeFullSize);

        List<HitObject> objects = becauseMaybe.HitObjects ?? throw new NullReferenceException();

        Assert.Equal(13041, objects.Where(obj => obj is HitCircle).Count());
        Assert.Equal(4921, objects.Where(obj => obj is Slider).Count());
        Assert.Equal(64, objects.Where(obj => obj is HitCircle).Count());
    }

    [Fact]
    public void TestDifficulty()
    {
        Beatmap becauseMaybe = Beatmap.FromFile(becauseMaybeFullSize);

        DifficultySection difficulty = becauseMaybe.Difficulty ?? throw new NullReferenceException();

        
    }


}