using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SoundManager : MonoBehaviour
{
    public static SoundManager Instance;

    [SerializeField]
    private AudioSource MusicSource, EffectSource;

    [SerializeField]
    private AudioClip[] MusicClips, EffectClips;

    private void Awake()
    {
        // making sure that SoundManager is singleton
        if(Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        if(SceneManager.GetActiveScene().name == "Menu")
        {
            PlayMusic(MusicClips[0]);
        }

        SceneManager.sceneLoaded += ChangeMusic;
    }

    public void PlaySound(AudioClip clip)
    {
        EffectSource.PlayOneShot(clip);
    }

    public void PlayMusic(AudioClip clip)
    {
        MusicSource.clip = clip;
        MusicSource.Play();
    }

    public void ChangeMusic(Scene scene, LoadSceneMode mode)
    {
        Debug.Log("Scene changed");
        if(scene.buildIndex > 0)
        {
            PlayMusic(MusicClips[1]);
        }
    }

    public void ChangeMasterVolume(float value)
    {
        AudioListener.volume = value;
    }
}
