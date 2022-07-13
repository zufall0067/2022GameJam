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
        Button btn = startButton.transform.GetComponent<Button>();
        Color[] colors = { Color.red, Color.yellow, Color.green, Color.blue,  };
        while (true)
        {
            Color targetColor = new Color(Random.Range(0, 1f), Random.Range(0, 1f), Random.Range(0, 1f), 1f);
            btn.image.DOColor(targetColor, 0.2f);
            yield return new WaitForSeconds(0.21f);
        }
    }
}
