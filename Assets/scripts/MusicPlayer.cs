﻿using UnityEngine;
using System.Collections;

// This class will manage the volume and the fade in/out effect of the music
public class MusicPlayer : MonoBehaviour
{
    // Private variables
    private enum MusicPlayerStatus { Playing, FadingOut, FadingIn }
    private MusicPlayerStatus status = MusicPlayerStatus.Playing;
    private AudioClip nextclip;
    // Fade in/out
    private float fadeOut;
    private float fadeIn;
    private float fadeStart;
    // Volume
    private float volume = 1.0f;
    private bool smoothVolume = false;
    private float smoothVolumeBeginValue;
    private float smoothVolumeDuration;
    private float smoothVolumeStart;

    // Private tween function
    // Parameters: elapsed time, begin value, end value, duration
    private float cubicInOut(float t, float b, float c, float d)
    {
        t /= d / 2;
        if (t < 1)
            return c / 2 * t * t * t + b;
        t -= 2;
        return c / 2 * (t * t * t + 2) + b;
    }

    // Change the music's volume
    public void setMusicVolume(float volume, float duration)
    {
        // Sanitize input...
        if (volume < 0f) volume = 0f;
        if (volume > 1f) volume = 1f;

        // Set the new volume
        this.volume = volume;
        smoothVolumeBeginValue = audio.volume;
        smoothVolumeDuration = duration;
        smoothVolumeStart = Time.time;
        if (duration > 0f)
            smoothVolume = true;

        // If music is not in a fade effect, set it immediatly
        if (status != MusicPlayerStatus.FadingIn && status != MusicPlayerStatus.FadingOut && duration == 0f)
        {
            audio.volume = volume;
        }
    }

    // Pause the music
    public void pauseMusic()
    {
        audio.Pause();
    }

    // Unpause the music
    public void unpauseMusic()
    {
        if (!audio.isPlaying)
            audio.Play();
    }

    // Play a new music
    public void playMusic(AudioClip a, float fadeOut, float fadeIn)
    {
        if (audio.isPlaying)
        {
            // A music is already playing, so fade it out first
            this.fadeOut = fadeOut;
            this.fadeIn = fadeIn;
            nextclip = a;
            status = MusicPlayerStatus.FadingOut;
            fadeStart = Time.time;
        }
        else
        {
            // Directly play the music with the fadeIn effect
            this.fadeIn = fadeIn;
            audio.volume = 0;
            audio.clip = a;
            audio.Play();
            status = MusicPlayerStatus.FadingIn;
            fadeStart = Time.time;
        }
    }

    // Stop the music
    public void stopMusic(float fadeOut)
    {
        this.fadeOut = fadeOut;
        status = MusicPlayerStatus.FadingOut;
        fadeStart = Time.time;
    }

    // the Update function will do the fade in/out effect
    void Update()
    {
        // First, if the user want to change the volume
        if (smoothVolume)
        {
            if (status == MusicPlayerStatus.FadingOut || status == MusicPlayerStatus.FadingIn)
            {
                smoothVolume = false;
            }
            else
            {
                // Smooth the volume
                if (smoothVolumeBeginValue < volume)
                    audio.volume = cubicInOut(Time.time - smoothVolumeStart, smoothVolumeBeginValue, volume, smoothVolumeDuration);
                else if (smoothVolumeBeginValue > volume)
                    audio.volume = smoothVolumeBeginValue - cubicInOut(Time.time - smoothVolumeStart, 0f, smoothVolumeBeginValue - volume, smoothVolumeDuration);

                // If time is up we stop the animation
                if (Time.time > smoothVolumeStart + smoothVolumeDuration)
                {
                    audio.volume = volume;
                    smoothVolume = false;
                }
            }
        }

        // Now manage fade out/in
        if (status == MusicPlayerStatus.FadingOut)
        {
            if (Time.time < fadeStart + fadeOut)
            {
                audio.volume = volume - cubicInOut(Time.time - fadeStart, 0f, volume, fadeOut);
            }
            else
            {
                // Effect is finished
                audio.Stop();
                audio.volume = 0f;
                status = MusicPlayerStatus.Playing;

                // Is there another music to be played?
                if (nextclip != null)
                {
                    audio.clip = nextclip;
                    audio.Play();
                    nextclip = null;
                    fadeStart = Time.time;
                    status = MusicPlayerStatus.FadingIn;
                }
            }
        }
        else if (status == MusicPlayerStatus.FadingIn)
        {
            if (Time.time < fadeStart + fadeIn)
            {
                audio.volume = cubicInOut(Time.time - fadeStart, 0f, volume, fadeIn);
            }
            else
            {
                // Effect is finished
                audio.volume = volume;
                status = MusicPlayerStatus.Playing;
            }
        }
        if (!audio.isPlaying)
            Destroy(this.gameObject);
    }
}
