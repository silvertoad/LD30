using UnityEngine;
using System.Collections;

public class SoundManager : MonoBehaviour {

    public static string currentTheme = "disco";

    private static GameObject themePlayer = null;
    private static MusicPlayer MusicPlayer = null;

    private static GameObject effectPlayer = null;
    private static MusicPlayer effectMusicPlayer = null;

	public static GameObject getMusicEmitter()
    {
        if (themePlayer == null)
        {
            themePlayer = new GameObject();
            themePlayer.name = "Theme Player";
            themePlayer.AddComponent<AudioSource>();
            themePlayer.audio.loop = true;
            DontDestroyOnLoad(MusicPlayer);
            MusicPlayer = themePlayer.AddComponent<MusicPlayer>();
        }
        return themePlayer;
    }

    public static MusicPlayer getMusicPlayer()
    {
        if (MusicPlayer == null)
        {
            MusicPlayer = getMusicEmitter().GetComponent<MusicPlayer>();
            if (MusicPlayer == null)
            {
                MusicPlayer = themePlayer.AddComponent<MusicPlayer>();
            }
        }
        return MusicPlayer;
    }

    public static void play(AudioClip clip, float fadeOut = 0f, float fadeIn = 0f)
    {
        getMusicPlayer().playMusic(clip, fadeOut, fadeIn);
    }    

    public static void play(string name, float fadeOut = 0f, float fadeIn = 0f)
    {
        AudioClip themeName = (AudioClip)Resources.Load(name, typeof(AudioClip));
        if (themeName != null)
        {
            play(themeName, fadeOut, fadeIn);
        }
    }    

    public static GameObject getEffectEmitter()
    {
        if (effectPlayer == null)
        {
            effectPlayer = new GameObject();
            effectPlayer.name = "Effect Player";
            effectPlayer.AddComponent<AudioSource>();
            effectPlayer.audio.loop = false;
            DontDestroyOnLoad(effectMusicPlayer);
            effectMusicPlayer = effectPlayer.AddComponent<MusicPlayer>();
        }
        return effectPlayer;
    }

    public static MusicPlayer getEffectPlayer()
    {
        if (effectMusicPlayer == null)
        {
            effectMusicPlayer = getEffectEmitter().GetComponent<MusicPlayer>();
            if (effectMusicPlayer == null)
            {
                effectMusicPlayer = effectPlayer.AddComponent<MusicPlayer>();
            }
        }
        return effectMusicPlayer;
    }

    public static void playEffect(AudioClip clip, float fadeOut = 0f, float fadeIn = 0f)
    {
        getEffectPlayer().playMusic(clip, fadeOut, fadeIn);
    }

    public static void playEffect(string name, float fadeOut = 0f, float fadeIn = 0f)
    {
        AudioClip effectName = (AudioClip)Resources.Load(name, typeof(AudioClip));
        if (effectName != null)            
        {
            playEffect(effectName, fadeOut, fadeIn);
        }       
    }

    public static void Mute()
    {
        GameObject camera = GameObject.Find("WorldCamera");
        AudioListener listener = camera.GetComponent<AudioListener>();
        listener.enabled = (listener.enabled == true) ? false : true;
    }

    public static void SwitchTheme() 
    {        
        if (currentTheme == "disco")
        {
            SoundManager.play("Sounds/discoTheme", 1.0f, 1.0f);
            currentTheme = "rock";
        }
        else if (currentTheme == "rock")
        {
            SoundManager.play("Sounds/rockTheme", 1.0f, 1.0f);
            currentTheme = "disco";
        }       
    }
}
