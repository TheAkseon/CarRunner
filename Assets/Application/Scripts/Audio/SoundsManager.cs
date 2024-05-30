using System;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using Plugins.Audio.Core;

public class SoundsManager : MonoBehaviour
{
    public static SoundsManager Instance = null;

    [Header("Audio Sources")]
    [SerializeField] private SourceAudio _soundsDatabase;

    private float _startVolume;

    private float _fadeDuration = 0.5f;
    private string _nameSoundLevel = "1";

    public string NameSoundLevel => _nameSoundLevel;

    //private int currentClip = 0;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            //DontDestroyOnLoad(gameObject);
        }
        //else
        //Destroy(gameObject);
    }

    private void Start()
    {
        _soundsDatabase.Volume = 0.4f;

        int levelNumber = SceneManager.GetActiveScene().buildIndex;

        _nameSoundLevel = 1.ToString();
        _soundsDatabase.Play(_nameSoundLevel);

        _soundsDatabase.Loop = true;
    }

    public void PlaySound(string name)
    {
        _soundsDatabase.PlayOneShot(name);
    }
    public void PlayBackGround(string name)
    {
        _soundsDatabase.Play(name);
    }
    public void StopSound()
    {
        _soundsDatabase.Stop();
    }

    public void Mute(string source, bool value)
    {
        if (source.Equals("music"))
            _soundsDatabase.Mute = value;
        else
        {
            _soundsDatabase.MuteEffects = value;
        }
    }

    public void FadeOut()
    {
        StartCoroutine(FadeOutMusic());
    }

    private IEnumerator FadeOutMusic()
    {
        float elapsedTime = 0f;

        while (elapsedTime < _fadeDuration)
        {
            elapsedTime += Time.deltaTime;
            _soundsDatabase.Volume = Mathf.Lerp(_startVolume, 0.0f, elapsedTime / _fadeDuration);
            yield return null;
        }

        _soundsDatabase.Stop();
    }
}

[Serializable]
public class Music
{
    public int levelNumber;
    public AudioClip audio;
}
