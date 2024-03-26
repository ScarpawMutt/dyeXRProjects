/* Charlie Dye - 2024.03.26

This is the script for the audio manager */

using DyeXR.Singleton;
using System;
using System.Collections;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]

public class AudioManager : Singleton<AudioManager>
{

    [Header("Background Music Track")]
    [SerializeField] private AudioClip[] tracks; // Array of clips to randomize
    [SerializeField] private AudioSource audio_source; // Needed to play audio

    [Header("Events")]
    public Action on_current_track_end;

    public void Awake()
    {

        audio_source = gameObject.AddComponent<AudioSource>();
        StartCoroutine(ShuffleWhenStoppedPlaying());
        ShuffleAndPlay();

    }

    // References the enum class
    public void ShuffleAndPlay(GameState game_state = GameState.Playing)
    {

        if (tracks.Length > 0)
        {

            audio_source.clip = tracks[UnityEngine.Random.Range(0, tracks.Length - 1)];
            audio_source.Play();

        }

    }

    // Another track will play when the current one ends
    private IEnumerator ShuffleWhenStoppedPlaying()
    {

        while (true)
        {

            yield return new WaitUntil(() => !audio_source.isPlaying);
            ShuffleAndPlay();

            // Invokes this action to anything that is listening
            on_current_track_end?.Invoke();

        }

    }

}
