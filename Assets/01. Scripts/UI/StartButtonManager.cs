using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using UnityEngine.SceneManagement;

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
    private GameObject Logo;

    [SerializeField]
    private GameObject[] gameObj;

    public List<Sprite> skillSprite;
    public List<string> skillText;
    public List<int> skillList;

    public Frame Frame;
    public Transform frameParent;
    public GameObject framePanel;
    public GameObject ClickToStartText;

    private bool isCanStart;

    void Start()
    {
        Button btn = startButton.transform.GetComponent<Button>();

        StartCoroutine(DG());
    }

    void Update()
    {
        if(isCanStart && Input.GetMouseButtonDown(0))
        {
            SceneManager.LoadScene("SampleScene");
        }
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

        Frame frame1 = Instantiate(Frame, new Vector3(50, -3.25f, 0), Quaternion.identity, frameParent);
        Frame frame2 = Instantiate(Frame, new Vector3(50, -3.25f, 0), Quaternion.identity, frameParent);
        Frame frame3 = Instantiate(Frame, new Vector3(50, -3.25f, 0), Quaternion.identity, frameParent);
        frame1.sprite.sprite = skillSprite[skillList[0]];
        frame2.sprite.sprite = skillSprite[skillList[1]];
        frame3.sprite.sprite = skillSprite[skillList[2]];
        frame1.text.text = skillText[skillList[0]];
        frame2.text.text = skillText[skillList[1]];
        frame3.text.text = skillText[skillList[2]];

        yield return new WaitForSeconds(1f);

        particle.SetActive(true);
        particle.GetComponent<Renderer>().sortingLayerName = "CHARACTER";
        particle.GetComponent<Renderer>().sortingOrder = 6;

        yield return new WaitForSeconds(0.2f);

        tower.transform.DOMoveY(12.5f, 5f);

        yield return new WaitForSeconds(4.5f);

        titleText.SetActive(false);
        boomAni.SetActive(true);
        Logo.SetActive(true);

        yield return new WaitForSeconds(0.5f);

        boomAni.SetActive(false);

        framePanel.transform.DOMoveX(0, 0.25f);
        yield return new WaitForSeconds(0.5f);

        frame1.transform.DOMoveX(-5, 0.25f);
        yield return new WaitForSeconds(0.5f);
        frame2.transform.DOMoveX(0, 0.25f);
        yield return new WaitForSeconds(0.5f);
        frame3.transform.DOMoveX(5, 0.25f);
        ClickToStartText.transform.DOMoveX(8, 0.25f);
        yield return new WaitForSeconds(0.5f);

        isCanStart = true;        
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
