/* Charlie Dye - 2024.02.27

This is the script for core features */

using UnityEngine;

public class CoreFeatures : MonoBehaviour
{

    /* We need a common way to access this code outside of this class.
    Create a property value, or "encapsulation".
    Properties have "accessors", which define the the properties.
    "Get" accessors read and return encapsulated variables.
    "Set" accessors write and allocate new values to fields. */

    public bool AudioSFXSourceCreated { get; set; }

    [field: SerializeField]
    public AudioClip AudioClipOnStart { get; set; }

    [field: SerializeField]
    public AudioClip AudioClipOnEnd { get; set; }

    private AudioSource audio_source;

    public FeatureUsage feature_usage = FeatureUsage.Once;

    protected virtual void Awake()
    {

        MakeAudioSFXSource();

    }

    private void MakeAudioSFXSource()
    {

        audio_source = GetComponent<AudioSource>();

        // If this is null, create it right here
        if (audio_source == null)
        {

            audio_source.gameObject.AddComponent<AudioSource>();

        }

        /* Regardless of a null value or not, we still need to make sure that
        this is true on Awake() */
        AudioSFXSourceCreated = true;

    }

    // Audio play commands
    protected void PlayOnStart()
    {

        if (AudioSFXSourceCreated && AudioClipOnStart != null)
        {

            audio_source.clip = AudioClipOnStart;
            audio_source.Play();

        }

    }

    protected void PlayOnEnd()
    {

        if (AudioSFXSourceCreated && AudioClipOnEnd != null)
        {

            audio_source.clip = AudioClipOnEnd;
            audio_source.Play();

        }

    }

}