using System;
using UnityEngine;

public class CoinState : ItemState
{
    [SerializeField] int Amount;

    protected override void OnPlayerCollided (Player _player)
    {
        _player.CollectCoin (Amount);
        Destroy (gameObject.transform.parent.gameObject);
    }
}