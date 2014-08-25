using UnityEngine;
using System.Collections;

public class ScrollScript : MonoBehaviour
{
    public float speed = 0;

    void Update ()
    {
        var realSpeed = speed / 100f;
        renderer.material.mainTextureOffset = new Vector2 (0f, Time.time * realSpeed);
    }
}
