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

    void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
    }

    void Start()
    {
        
    }

    void Set()
    {
        randomSetManager = GameObject.Find("StartRandomSetManager").GetComponent<StartRandomSetManager>();

        Debug.Log(randomSetManager);

        towerSprite = randomSetManager.towerGameObject[randomSetManager.towerRandomIndex].gameObject.GetComponent<SpriteRenderer>().sprite;

        Debug.Log(towerSprite.name);
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
