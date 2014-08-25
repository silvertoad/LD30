using System.Collections.Generic;
using System;
using System.Linq;

public class RegionGenerator
{
    int minRegionLength = 5;
    Random random = new Random ();

    public int[][] GetNextRegion ()
    {
        var region = GetRegionPart ().ToList ();
        if (!Facade.I.IsTutorialComplete)
            region.AddRange (CurrentPreset.Regions [17]);
        while (region.Count < minRegionLength)
            region.InsertRange (0, CurrentPreset.Regions [0]);
        return region.ToArray ();
    }

    Preset CurrentPreset {
        get { 
            var defs = Facade.I.Defs;
            return (Facade.I.CurrentWorld == Worlds.Disco) ? 
                defs.DiscoPreset 
                : defs.RockPreset;
        }
    }

    int[][] GetRegionPart ()
    {
        var regionIds = CurrentPreset.Dificults [Preset.Dificult.Easy];
        var regionId = random.Next (regionIds.Length);
        return CurrentPreset.Regions [regionId];
    }
}