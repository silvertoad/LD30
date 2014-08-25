
using System;
using UnityEngine;
using System.Collections.Generic;

public class Definitions
{
    public Dictionary<int, string> ids = new Dictionary<int, string> ();

    public Preset RockPreset { get; private set; }

    public Preset DiscoPreset { get; private set; }

    public Definitions ()
    {
        ReadIds ();
        LoadPersets ();
    }

    void ReadIds ()
    {
        var idsAssets = Resources.Load<TextAsset> ("defs/ids").text;
        var idsJSON = JSON.Parse (idsAssets);
        foreach (var kvp in idsJSON) {
            var id = Convert.ToInt32 (kvp.Key);
            var prefab = (string)kvp.Value;
            ids.Add (id, prefab);
        }
    }

    void LoadPersets ()
    {
        var regionSource = Resources.Load<TextAsset> ("defs/presets").text;
        var presetsJSON = JSON.Parse (regionSource);

        DiscoPreset = new Preset (JSON.Get <Dictionary<string, object>> ("presets.disco", presetsJSON));
        RockPreset = new Preset (JSON.Get <Dictionary<string, object>> ("presets.rock", presetsJSON));
    }
}

public class Preset
{
    public int[][][] Regions { get; private set; }

    public Dictionary<Dificult, int[]> Dificults = new Dictionary<Dificult, int[]> ();
    Dictionary<string, object> source;

    public Preset (Dictionary<string, object> _presetSource)
    {
        source = _presetSource;
        ParseRegions ();
        ParseDificults ();
    }

    void ParseRegions ()
    {
        var regions = new List<int[][]> ();
        foreach (var kvp in (Dictionary<string, object>)source["regions"]) {
            int[][] region = (int[][])kvp.Value;
            regions.Add (region);
        }
        Regions = regions.ToArray ();
    }

    void ParseDificults ()
    {
        var json = (Dictionary<string, object>)source ["dificults"];
        var difs = Enum.GetNames (typeof(Dificult));
        foreach (var difRate in difs) {
            var difName = difRate.ToLower ();
            var difEnum = (Dificult)Enum.Parse (typeof(Dificult), difRate);

            var value = (int[])json [difName];
            Dificults.Add (difEnum, value);
        }
    }

    public enum Dificult
    {
        Easy,
        Normal,
        Hard,
        Insane
    }
}