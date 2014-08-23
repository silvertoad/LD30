using UnityEngine;

public class EntryPoint : MonoBehaviour
{
    [SerializeField] GameObject world;

    public void Awake ()
    {
        var map = GameUtils.InstantiateAt<MapWidget> ("world/map/Map", world);
        map.AddRegion ();
    }
}