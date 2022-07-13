using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class StartButtonManager : MonoBehaviour
{
    [SerializeField]
    private GameObject startButton;

    [SerializeField]
    private GameObject particle;

    [SerializeField]
    private GameObject tower;

    [SerializeField]
    private GameObject boomAni;

    [SerializeField]
    private GameObject titleText;

    [SerializeField]
    private GameObject[] gameObj;

    void Start()
    {
        Button btn = startButton.transform.GetComponent<Button>();

        StartCoroutine(DG());
    }

    void Update()
    {
        
    }

    public void ButtonPush()
    {
        StartCoroutine(StartButtonPush());
    }

    public IEnumerator StartButtonPush()
    {
        startButton.SetActive(false);

        gameObj[0].transform.DORotate(new Vector3(0f, 90f), 1f);
        gameObj[1].transform.DORotate(new Vector3(0f, 90f), 1f);
        gameObj[2].transform.DORotate(new Vector3(0f, 90f), 1f).OnComplete(() => { gameObj[2].SetActive(false); });
        gameObj[3].transform.DORotate(new Vector3(0f, 90f), 1f).OnComplete(() => { gameObj[3].SetActive(false); });
        gameObj[4].transform.DORotate(new Vector3(0f, 90f), 1f).OnComplete(() => { gameObj[4].SetActive(false); });

        yield return new WaitForSeconds(1f);

        particle.SetActive(true);
        particle.GetComponent<Renderer>().sortingLayerName = "CHARACTER";
        particle.GetComponent<Renderer>().sortingOrder = 6;

        yield return new WaitForSeconds(0.2f);

        tower.transform.DOMoveY(12.5f, 5f);

        yield return new WaitForSeconds(4.5f);

        titleText.SetActive(false);
        boomAni.SetActive(true);

        yield return new WaitForSeconds(0.5f);

        boomAni.SetActive(false);
        
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
