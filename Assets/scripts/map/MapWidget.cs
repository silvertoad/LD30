using UnityEngine;
using System.Collections.Generic;
using System.Linq;

public class MapWidget : MonoBehaviour
{
    float lastPos = 0f;
    List<Region> regions = new List<Region> ();
    bool isRunFirstTime = true;

    void Update ()
    {
        if (isDestroyed) return;
        if (Facade.I.CurrentPosition + .64f * 16 > lastPos)
            AddRegion ();
    }

    public void AddRegion ()
    {
        var region = Facade.I.Generator.GetNextRegion ();
    
        if (isRunFirstTime && Facade.I.IsTutorialComplete) {
            var regionList = region.ToList ();
            for (var i = 0; i < 25; i++)
                regionList.AddRange (Facade.I.Defs.DiscoPreset.Regions [0]);
            region = regionList.ToArray ();
            isRunFirstTime = false;
        }

        var regionView = Draw (region);
        regions.Add (regionView);
    }

    Region Draw (int[][] _region)
    {
        var newPos = lastPos + _region.Length * 0.64f;
        var region = GameUtils.InstantiateAt<Region> ("world/map/Region", gameObject);
        region.Init (_region);
        region.gameObject.transform.localPosition = new Vector3 (0f, lastPos);
        region.gameObject.transform.rotation = new Quaternion (0, 0, 0, 0);
        lastPos = newPos;
        return region;
    }

    bool isDestroyed;

    void OnDestroy ()
    {
        isDestroyed = true;
    }
}