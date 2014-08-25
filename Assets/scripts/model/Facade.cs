using System;
using UnityEngine;

public class Facade
{
    public static Facade I { get; private set; }

    static Facade ()
    {
        I = new Facade ();
    }

    public Worlds CurrentWorld = Worlds.Disco;

    public Definitions Defs { get; private set; }

    public RegionGenerator Generator { get; private set; }

    public GameController Controller { get; private set; }

    public float CurrentPosition;

    public bool IsTutorialComplete;

    public Facade ()
    {
        Defs = new Definitions ();
        Generator = new RegionGenerator ();
    }

    public void Init (GameObject _world)
    {
        Controller = new GameController (_world);
    }
}

public enum Worlds
{
    Disco,
    Rock
}