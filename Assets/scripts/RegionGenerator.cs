using System.Collections.Generic;

public class RegionGenerator
{
    int minRegionLength = 25;

    public int[][] GetNextRegion ()
    {
        var region = new List<int[]> ();
        while (region.Count < minRegionLength)
            region.AddRange (GetRegionPart ());
        return region.ToArray ();
    }

    Preset CurrentPreset {
        get { 
            var defs = Facade.I.defs;
            return (Facade.I.CurrentWorld == Worlds.Disco) ? 
                defs.DiscoPreset 
                : defs.RockPreset;
        }
    }

    int[][] GetRegionPart ()
    {
        return CurrentPreset.Regions [0];
    }
}