using UnityEngine;

public class AudioManager : SingletonBehaviour<AudioManager>
{
    public float FXVolume = 1;
    public float BGMVolume = .3f;

    private AudioSource FxSource
    {
        get
        {
            if (!_createdFxSource)
            {
                _fxSource = gameObject.AddComponent<AudioSource>();
                _fxSource.spatialize = false;
                _fxSource.volume = FXVolume;
                _createdFxSource = _fxSource != null;
            }

            return _fxSource;
        }
    }

    private bool _createdFxSource;
    private AudioSource _fxSource;

    private AudioSource BgmSource
    {
        get
        {
            if (!_createdBgmSource)
            {
                _bgmSource = gameObject.AddComponent<AudioSource>();
                _bgmSource.spatialize = false;
                _bgmSource.volume = BGMVolume;
                _bgmSource.loop = true;
                _createdBgmSource = _bgmSource != null;
            }

            return _bgmSource;
        }
    }

    private bool _createdBgmSource;
    private AudioSource _bgmSource;

    public void PlayEffect(AudioClip clip)
    {
//        FxSource.pitch = Random.Range(1, 1.05f);
        FxSource.PlayOneShot(clip);
    }

    public void SetBackgroundMusic(AudioClip clip)
    {
        BgmSource.clip = clip;
        BgmSource.Play();
    }
}

public static class AudioClipExtensions
{
    public static void PlayFx(this AudioClip clip)
    {
        AudioManager.Instance.PlayEffect(clip);
    }
    public static void PlayBackgroundMusic(this AudioClip clip)
    {
        AudioManager.Instance.SetBackgroundMusic(clip);
    }

    public static void PlayRandomBackgroundMusic(this AudioClip[] clips)
    {
        var clip = clips[Random.Range(0, clips.Length)];
       clip.PlayBackgroundMusic();
    }
    public static void PlayRandomFx(this AudioClip[] clips)
    {
        var clip = clips[Random.Range(0, clips.Length)];
        clip.PlayFx();
    }
}