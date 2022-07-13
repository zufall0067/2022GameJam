using System.Collections;
using System.Collections.Generic;
using UnityEngine;
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

    public List<int> skillList;

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
}