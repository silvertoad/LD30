using System;
using UnityEngine;

[RequireComponent (typeof(Collider2D))]
public class Trigger : MonoBehaviour
{
    public Action OnTrigger;

    void OnTriggerEnter2D (Collider2D _collision)
    {
        var player = _collision.gameObject.GetComponent<Player> ();
        if (player != null) {
            OnTrigger ();
        }
    }

    void OnDestroy ()
    {
        OnTrigger = null;
    }
}