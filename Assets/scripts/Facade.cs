using System;

public class Facade
{
    public static Facade I { get; private set; }

    static Facade ()
    {
        I = new Facade ();
    }

    public Definitions defs { get; private set; }

    public RegionGenerator generator { get; private set; }

    public Worlds CurrentWorld = Worlds.Disco;

    public Facade ()
    {
        defs = new Definitions ();
        generator = new RegionGenerator ();
    }
}

public enum Worlds
{
    Disco,
    Rock
}