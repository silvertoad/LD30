using UnityEditor;

[CustomEditor (typeof(MapItem))]
public class MapItemEditor : Editor
{
    public override void OnInspectorGUI ()
    {
        UpdateDefaultSprite ();
        base.OnInspectorGUI ();
    }

    void UpdateDefaultSprite ()
    {
        MapItem item = (MapItem)target;
    }
}