using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
        randomSetManager = gameObject.transform.Find("StartRandomSetManager").GetComponent<StartRandomSetManager>();

        Debug.Log(randomSetManager);

        towerSprite = randomSetManager.towerGameObject[randomSetManager.towerRandomIndex].gameObject.GetComponent<SpriteRenderer>().sprite;

        Debug.Log(towerSprite.name);
    }

    void Update()
    {
       
    }
}
