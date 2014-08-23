using UnityEngine;
using System.Collections.Generic;

public class MapWidget : MonoBehaviour
{
    float lastPos = 0f;
    List<Region> regions = new List<Region> ();
    CameraMover mover;

    void Awake ()
    {
        mover = GameObject.Find ("WorldCamera").GetComponent<CameraMover> ();
    }

    void Update ()
    {
        if (mover.transform.position.y + .64f * 16 > lastPos)
            AddRegion ();
    }

    public void AddRegion ()
    {
        var region = Facade.I.generator.GetNextRegion ();
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
}