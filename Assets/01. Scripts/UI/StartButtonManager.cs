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
        Button btn = startButton.transform.GetComponent<Button>();

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
            startButton.transform.DOPunchScale(new Vector3(0.1f, 0.1f), 0.9f);
            yield return new WaitForSeconds(1f);
        }
    }
}
