using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FuelPiece : MonoBehaviour
{
    private float giveFuel;
    private float speed = 3;
    public AudioClip[] clips; // 0 총쏘기  1 히트  2 재장전  3 뒤질때
    public AudioSource audioSource;
    public void PlayEffect(int num)
    {
        Debug.Log("playsound start");
        audioSource.clip = clips[num];
        audioSource.PlayOneShot(clips[num]);
        Debug.Log("playsound end");
    }
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log(audioSource);
        audioSource = GetComponent<AudioSource>();

    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.down * Time.deltaTime * speed);
    }
    public void SetGiveFuel(float _givefuel)
    {

        giveFuel = _givefuel;
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.transform.CompareTag("TOWER"))
        {
            PlayEffect(0);
            other.transform.GetComponent<Tower>().fuel += giveFuel;

            Destroy(gameObject);
        }
        else if (other.transform.CompareTag("OUTLINE"))
        {
            Destroy(gameObject);
        }
    }
}
