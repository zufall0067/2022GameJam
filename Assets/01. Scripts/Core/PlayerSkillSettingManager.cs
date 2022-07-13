using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.SceneManagement;

public class PlayerSkillSettingManager : MonoBehaviour
{
    #region singleton

    private static PlayerSkillSettingManager instance = null;

    public static PlayerSkillSettingManager Instance
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
    #endregion

    StartRandomSetManager randomSetManager;

    public Sprite towerSprite;

    public List<Sprite> skillSprite;
    public List<string> skillText;
    public List<int> skillList;

    public Frame Frame;
    public Transform frameParent;
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

    void Start()
    {
        Set();
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.P))
        {
            SceneManager.LoadScene("SampleScene");
        }
        if(Input.GetKeyDown(KeyCode.L))
        {
            StartCoroutine(SetFrame());
        }
    }

    void Set()
    {
        randomSetManager = GameObject.Find("StartRandomSetManager").GetComponent<StartRandomSetManager>();

        towerSprite = randomSetManager.towerGameObject[randomSetManager.towerRandomIndex].gameObject.GetComponent<SpriteRenderer>().sprite;

        ShuffleList(skillList);

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

    public void LoadedsceneEvent(Scene scene, LoadSceneMode mode)
    {

        if(scene.name == "Start")
        {
            Set();
        }
        if(scene.name == "SampleScene")
        {

        }
    }

    public IEnumerator SetFrame()
    {
        Frame frame1 = Instantiate(Frame, new Vector3(50, 0, 0), Quaternion.identity, frameParent);
        Frame frame2 = Instantiate(Frame, new Vector3(50, 0, 0), Quaternion.identity, frameParent);
        Frame frame3 = Instantiate(Frame, new Vector3(50, 0, 0), Quaternion.identity, frameParent);
        frame1.sprite.sprite = skillSprite[skillList[0]];
        frame2.sprite.sprite = skillSprite[skillList[1]];
        frame3.sprite.sprite = skillSprite[skillList[2]];
        frame1.text.text = skillText[skillList[0]];
        frame2.text.text = skillText[skillList[1]];
        frame3.text.text = skillText[skillList[2]];

        frame1.transform.DOMoveX(-5, 0.25f);
        yield return new WaitForSeconds(0.5f);
        frame2.transform.DOMoveX(0, 0.25f);
        yield return new WaitForSeconds(0.5f);   
        frame3.transform.DOMoveX(5, 0.25f);
        yield return new WaitForSeconds(0.5f);
        Debug.Log("¾Àº¯°æ");
    }

}
