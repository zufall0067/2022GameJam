using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FuelSound : MonoBehaviour
{
    private static FuelSound instance = null;

    private void Awake()
    {
        if (null == instance)
        {
            instance = this;
        }
        else
        {
            Destroy(this.gameObject);
        }
    }
    public static FuelSound Instance
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
    public AudioClip[] clips; // 0 총쏘�? 1 ?�트  2 ?�장?? 3 ?�질??
    public AudioSource audioSource;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    public void PlayEffect(int num)
    {
        audioSource.clip = clips[num];
        audioSource.PlayOneShot(clips[num]);
    }

}
