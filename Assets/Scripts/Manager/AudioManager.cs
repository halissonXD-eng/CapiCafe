using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance;
    
    [SerializeField] AudioSource GeneralMusicMixer;
    [SerializeField] AudioSource GeneralSFXMixer;

    // esto es para que se quede argando entre escenas
    void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(this);
        }
        DontDestroyOnLoad(this);
    }

    public void SFXPlaySimple(AudioClip clip)
    {
        GeneralSFXMixer.PlayOneShot(clip);
    }

    public void SFXPlayVolume(AudioClip clip, float volume)
    {
        GeneralSFXMixer.PlayOneShot(clip);
        GeneralSFXMixer.volume = volume;
    }

    public void MusicPlaySimple(AudioClip clip)
    {
        //Play one shot ejecuta una vez el clip o el audio
        GeneralMusicMixer.PlayOneShot(clip);
    }

    public void AudioPlayVolume(AudioClip clip, float volume)
    {
        GeneralMusicMixer.PlayOneShot(clip);
        GeneralMusicMixer.volume = volume;
    }

}
