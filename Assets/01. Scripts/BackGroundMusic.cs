using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackGroundMusic : MonoBehaviour
{
    public AudioClip[] clips; // 0 총쏘�? 1 ?�트  2 ?�장?? 3 ?�질??
    public AudioSource audioSource;
    public bool isStopMusic = false;
    public bool isLoop = true;
    public void PlayEffect(int num)
    {
        audioSource.clip = clips[num];
        //audioSource.PlayOneShot(clips[num]);
    }
    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        PlayEffect(0);
        StartCoroutine("LoopAudio");
    }
    IEnumerator LoopAudio()
    {
        float length = audioSource.clip.length;

        while (isLoop)
        {
            audioSource.Play();
            yield return new WaitForSeconds(length - 3);
        }
    }
    public void StopMusic()
    {
        audioSource.Stop();
        isLoop = false;
    }
    // Update is called once per frame
    void Update()
    {
        if (isStopMusic)
        {
            StopCoroutine("LoopAudio");
            StopMusic();
        }
    }
}
