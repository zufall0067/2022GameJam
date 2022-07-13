using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class SkillManager : MonoBehaviour
{
    #region �̱���
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

    private Fireball fireballSkill;
    private EnergyBall energyballSkill;
    private LaserBall laserballSkill;

    public Tower tower;

    void Awake()
    {
        fireballSkill = GetComponent<Fireball>();
        energyballSkill = GetComponent<EnergyBall>();
        laserballSkill = GetComponent<LaserBall>();

        if (null == instance)
        {
            instance = this;
        }
        
        for(int i = 0; i < 3; i++)
        {
            if(PlayerSkillSettingManager.Instance.skillList[i] == 0)
            {
                skillArr[i] = fireballSkill; 
            }
            if (PlayerSkillSettingManager.Instance.skillList[i] == 1)
            {
                skillArr[i] = energyballSkill;
            }
            if (PlayerSkillSettingManager.Instance.skillList[i] == 2)
            {
                skillArr[i] = laserballSkill;
            }
        }
        
    }

    void Start()
    {

    }

    public void SkillPanelQuit()
    {
        Time.timeScale = 1f;
        skillPanel.transform.DOMoveY(-2, 0.2f);
        isSkill = false;
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(1))
        {
            if (!isSkill)
            {
                Time.timeScale = 1f;
                isSkill = true;
                skillPanel.transform.DOComplete();
                skillPanel.transform.DOMoveY(0, 0.02f).OnComplete(() => { });
                Time.timeScale = 0.05f;
            }
            else
            {
                SkillPanelQuit();
            }
        }
        // if (Input.GetMouseButtonUp(1))
        // {
        //     //skillPanel.transform.DOComplete();

        // }


        if (Input.GetKeyDown(KeyCode.Q) && isSkill) // ù��° ��ų
        {
            tower.GetComponent<Tower>().isSkilling = true;
            skillArr[0].Select();
        }

        if (Input.GetKeyDown(KeyCode.W) && isSkill) // �ι�° ��ų
        {
            tower.GetComponent<Tower>().isSkilling = true;
            skillArr[1].Select();
        }

        if (Input.GetKeyDown(KeyCode.E) && isSkill) //����° ��ų
        {
            tower.GetComponent<Tower>().isSkilling = true;
            skillArr[2].Select();
        }

    }


}
