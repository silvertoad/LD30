using UnityEngine;
using System;

public class GameController
{
    GameObject WorldContainer;

    public GameController (GameObject _world)
    {
        WorldContainer = _world;
    }

    public void StartNewGame ()
    {
        AddNew ("world/Game", "world/ParallaxCamera", "world/WorldCamera", "world/player/player");
        SoundManager.play ("Sounds/discoTheme");
    }

    void AddNew (params string[] _names)
    {
        foreach (var name in _names) {
            var nameSplited = name.Split ('/');
            var inGameName = nameSplited [nameSplited.Length - 1];

            var toRemove = WorldContainer.transform.Find (inGameName);
            if (toRemove != null)
                GameObject.Destroy (toRemove.gameObject);
        }
        Array.Reverse (_names);
        foreach (var name in _names)
            GameUtils.InstantiateAt (name, WorldContainer);
    }
}