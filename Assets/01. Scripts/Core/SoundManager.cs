using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    private static SoundManager instance = null;

    public static SoundManager Instance
    {
        get
        {
            if (null == instance)
            {
                return null;
            }
            return instance;
        }
    }
    void Awake()
    {
        if (null == instance)
        {
            instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            Destroy(this.gameObject);
        }
    }


    public enum Sound
    {
        Bgm,
        Effect,
        MaxC
    }

    AudioSource[] _audioSources = new AudioSource[100];
    Dictionary<string, AudioClip> _audioClips = new Dictionary<string, AudioClip>();


}
