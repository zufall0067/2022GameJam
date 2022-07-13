using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class StartButtonManager : MonoBehaviour
{
    [SerializeField]
    private GameObject startButton;

    void Start()
    {
        StartCoroutine(DG());
    }

    void Update()
    {
        
    }

    public void StartButtonPush()
    {
        startButton.SetActive(false);
    }

    IEnumerator DG()
    {
        while(true)
        {
            startButton.transform.GetComponent<Image>().color = new Color(Random.Range(0, 256), Random.Range(0, 256), Random.Range(0, 256), 200f);

            yield return new WaitForSeconds(1f);
        }
    }
}
