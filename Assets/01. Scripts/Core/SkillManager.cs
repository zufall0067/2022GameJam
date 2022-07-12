using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class SkillManager : MonoBehaviour
{
    #region 싱글톤
    private static SkillManager instance = null;

    public static SkillManager Instance
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

    public GameObject skillPanel;
    public bool isSkill;

    public Skill[] skillArr;

    public Tower tower;

    void Awake()
    {
        if (null == instance)
        {
            instance = this;
        }
    }

    void Start()
    {
        
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(1) && !isSkill)
        {
            Time.timeScale = 1f;
            isSkill = true;
            skillPanel.transform.DOComplete();
            skillPanel.transform.DOMoveY(0, 0.02f).OnComplete(() => { });
            Time.timeScale = 0.05f;
        }
        if (Input.GetMouseButtonUp(1))
        {
            //skillPanel.transform.DOComplete();
            Time.timeScale = 1f;
            skillPanel.transform.DOMoveY(-2, 0.2f);  
            isSkill = false;
        }


        if(Input.GetKeyDown(KeyCode.Q) && isSkill) // 첫번째 스킬
        {
            tower.GetComponent<Tower>().isSkilling = true;
            skillArr[0].Select();
        }

        if(Input.GetKeyDown(KeyCode.W)) // 두번째 스킬
        {
            tower.GetComponent<Tower>().isSkilling = true;
            skillArr[1].Select();
        }

        if (Input.GetKeyDown(KeyCode.E)) //세번째 스킬
        {
            tower.isSkilling = true;
        }

    }


}
