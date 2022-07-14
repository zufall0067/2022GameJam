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

    public Text announceText;
    public GameObject announceObject;
    private bool isCanStart;
    public AudioClip[] clips; // 0 총쏘기  1 히트  2 재장전  3 뒤질때
    public AudioSource audioSource;
    public BackGroundMusic backGroundMusic;
    public void PlayEffect(int num)
    {
        audioSource.clip = clips[num];
        audioSource.PlayOneShot(clips[num]);
    }
    public void StopEffect(int num)
    {
        audioSource.clip = clips[num];
        audioSource.Stop();
    }
    void Start()
    {
        backGroundMusic = FindObjectOfType<BackGroundMusic>();
        audioSource = GetComponent<AudioSource>();
        Button btn = startButton.transform.GetComponent<Button>();
        StartCoroutine(DG());
    }

    void Update()
    {
        if (isCanStart && Input.GetMouseButtonDown(0))
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
        if (!PlayerSkillSettingManager.Instance.isFirstStart)
        {
            startButton.SetActive(false);
            ShuffleList(skillList);
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

            PlayerSkillSettingManager.Instance.skillList[0] = skillList[0];
            PlayerSkillSettingManager.Instance.skillList[1] = skillList[1];
            PlayerSkillSettingManager.Instance.skillList[2] = skillList[2];

            yield return new WaitForSeconds(1f);
            backGroundMusic.StopMusic();
            PlayEffect(3);
            float length = audioSource.clip.length;
            yield return new WaitForSeconds(0.8f);
            announceObject.gameObject.SetActive(true);
            announceText.text = "타워 11호 발사 준비 완료했다, 라저.";
            yield return new WaitForSeconds(5.1f - 0.8f);
            announceText.text = "상태를 유지해라 존 글랜.";
            yield return new WaitForSeconds(8.2f - 5.1f);
            announceText.text = "좋아, 제군들. 날시간이야.";
            yield return new WaitForSeconds(3f);
            announceText.text = "모든 수치 이상 무.";
            yield return new WaitForSeconds(3f);
            PlayEffect(4);
            audioSource.volume = 1f;
            announceText.text = "그렇다면 바로 발사합니다.";
            //yield return new WaitForSeconds(length - (11.1f - 8.2f - 5.1f - 0.8f));

            yield return new WaitForSeconds(3f);
            announceText.text = "4.. 3... 2... 1...";
            yield return new WaitForSeconds(4);
            announceObject.SetActive(false);
            audioSource.volume = 0.2f;
            PlayEffect(0);
            CameraManager.Instance.FuncShakeVoid(2f, 5);
            particle.SetActive(true);
            particle.GetComponent<Renderer>().sortingLayerName = "CHARACTER";
            particle.GetComponent<Renderer>().sortingOrder = 6;

            yield return new WaitForSeconds(0.2f);

            tower.transform.DOMoveY(12.5f, 5f);

            yield return new WaitForSeconds(5f);

            titleText.SetActive(false);
            PlayEffect(1);
            boomAni.SetActive(true);
            Logo.SetActive(true);

            yield return new WaitForSeconds(0.5f);

            boomAni.SetActive(false);


            framePanel.transform.DOMoveX(0, 0.25f);
            yield return new WaitForSeconds(0.5f);
            PlayEffect(2);
            frame1.transform.DOMoveX(-5, 0.25f);
            yield return new WaitForSeconds(0.5f);
            PlayEffect(2);
            frame2.transform.DOMoveX(0, 0.25f);
            yield return new WaitForSeconds(0.5f);
            PlayEffect(2);
            frame3.transform.DOMoveX(5, 0.25f);
            ClickToStartText.transform.DOMoveX(5.75f, 0.25f);
            yield return new WaitForSeconds(0.5f);

            isCanStart = true;
            PlayerSkillSettingManager.Instance.isFirstStart = true;
        }
        else
        {

        }
    }

    IEnumerator DG()
    {
        while (true)
        {
            startButton.transform.DOPunchScale(new Vector3(0.1f, 0.1f), 0.9f);
            yield return new WaitForSeconds(1f);
        }
    }

    private List<T> ShuffleList<T>(List<T> list)
    {
        int random1, random2;
        T temp;

        for (int i = 0; i < list.Count; ++i)
        {
            random1 = Random.Range(0, list.Count);
            random2 = Random.Range(0, list.Count);

            temp = list[random1];
            list[random1] = list[random2];
            list[random2] = temp;
        }

        return list;
    }

    private void OnDisable()
    {
        StopAllCoroutines();
    }
}
