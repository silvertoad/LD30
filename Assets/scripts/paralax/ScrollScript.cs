using UnityEngine;
using System;

public class ScrollScript : MonoBehaviour
{
    public float speed = 0;
    [HideInInspector] public float DefaultSpeed;
    float startTime;

    void Awake ()
    {
        startTime = Time.time;
        DefaultSpeed = speed;
    }

    public void Move ()
    {
        speed = Math.Min (speed, DefaultSpeed * 10);
        var realSpeed = speed / 100f;
        renderer.material.mainTextureOffset = new Vector2 (0f, (Time.time - startTime) * realSpeed);
    }
}
