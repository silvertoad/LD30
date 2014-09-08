using System;
using UnityEngine;

[RequireComponent (typeof(SpriteRenderer))]
[RequireComponent (typeof(Collider2D))]
[RequireComponent (typeof(Rigidbody2D))]
public class ItemState: MonoBehaviour
{
    void Awake ()
    {
        rigidbody2D.isKinematic = true;
    }

    void OnCollisionEnter2D (Collision2D _collision)
    {
        CheckPlayer (_collision.gameObject);
		SoundManager.playEffect ("Sounds/WalHit", 0, 0);
    }

    void OnTriggerEnter2D (Collider2D _collision)
    {
        CheckPlayer (_collision.gameObject);
    }

    void CheckPlayer (GameObject _collision)
    {
        var player = _collision.GetComponent<Player> ();
        if (player != null)
            OnPlayerCollided (player);
    }

    public virtual void WakeUp ()
    {

    }

    protected virtual void OnPlayerCollided (Player _player)
    {
    }
}