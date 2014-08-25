using UnityEngine;
using System;

public class Region : MonoBehaviour
{
    public void Init (int[][] _region)
    {
        Draw (_region);
    }

    void Draw (int[][] _regionsSouce)
    {
        Array.Reverse (_regionsSouce);
        for (var row = 0; row < _regionsSouce.Length; row++) {
            for (var col = 0; col < _regionsSouce [row].Length; col++) {
                var itemId = _regionsSouce [row] [col];
                if (itemId != 0) {
                    var resourceId = Facade.I.Defs.ids [Math.Abs (itemId)];
                    var prefabId = string.Format ("world/map/items/{0}/{0}", resourceId);
                    var instance = GameUtils.InstantiateAt (prefabId, gameObject);
                    var pos = new Vector3 (col * 0.64f, row * 0.64f);
                    instance.transform.position = pos;
                   
                    if (itemId < 0) {
                        var localScale = instance.transform.localScale;
                        var vec = new Vector3 (localScale.x * -1, localScale.y, localScale.z);
                        instance.transform.localScale = vec;
                    }
                }
            }
        }
    }
}