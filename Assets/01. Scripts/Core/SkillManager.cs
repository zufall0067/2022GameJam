using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
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

    public Text titleText1;
    public Text priceText1;
    public Text explainText1;
    public GameObject iconSprite1;

    public Text titleText2;
    public Text priceText2;
    public Text explainText2;
    public GameObject iconSprite2;

    public Text titleText3;
    public Text priceText3;
    public Text explainText3;
    public GameObject iconSprite3;

    public GameObject skillPanel;
    public bool isSkill;

    public Skill[] skillArr;

    private Fireball fireballSkill;
    private EnergyBall energyballSkill;
    private LaserBall laserballSkill;

    public Tower tower;

    public Image redPanel; // ?�킬???�럿?�데 마나가 부족하�?0.3초정??보여�?

    void Awake()
    {
        fireballSkill = GetComponent<Fireball>();
        energyballSkill = GetComponent<EnergyBall>();
        laserballSkill = GetComponent<LaserBall>();

        if (null == instance)
        {
            instance = this;
        }

        for (int i = 0; i < 3; i++)
        {
            if (PlayerSkillSettingManager.Instance.skillList[i] == 0)
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
    //권�???바보
    void Start()
    {
        SetSkillInterface(titleText1, priceText1, explainText1, iconSprite1, 0);
        SetSkillInterface(titleText2, priceText2, explainText2, iconSprite2, 1);
        SetSkillInterface(titleText3, priceText3, explainText3, iconSprite3, 2);
    }

    public void RedPanel()
    {
    }

    public void SkillPanelQuit()
    {
        if (!isSkill) return;
        Time.timeScale = 1f;
        skillPanel.transform.DOMoveY(-2, 0.2f).OnComplete(()=> { isSkill = false; });
        
    }

    private void SetSkillInterface(Text titleText, Text priceText, Text explainText, GameObject iconSprite, int index)
    {
        titleText.text = skillArr[index].title;
        priceText.text = "[ " + skillArr[index].price + " �ڽ�Ʈ �ʿ� ]";
        explainText.text = skillArr[index].explain;
        iconSprite.GetComponent<Image>().sprite = skillArr[index].icon;
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(1))
        {
            if (!isSkill)
            {
                Time.timeScale = 1f;
                isSkill = true;
                //skillPanel.transform.DOComplete();
                skillPanel.transform.DOMoveY(0, 0.02f).OnComplete(() => { });
                Time.timeScale = 0.05f;
            }
            
        }
        if (Input.GetMouseButtonUp(1))
        {
            SkillPanelQuit();

        }


        if (Input.GetKeyDown(KeyCode.Q) && isSkill) // ù��° ��ų
        {
            
            if (tower.nowSkillCount >= skillArr[0].price)
            {
                tower.GetComponent<Tower>().isSkilling = true;
                tower.nowSkillCount -= skillArr[0].price;
                skillArr[0].Select();
            }
        }

        if (Input.GetKeyDown(KeyCode.E) && isSkill) // �ι�° ��ų
        {

            if (tower.nowSkillCount >= skillArr[1].price)
            {
                tower.GetComponent<Tower>().isSkilling = true;

                tower.nowSkillCount -= skillArr[1].price;
                skillArr[1].Select();
            }
        }

        if (Input.GetKeyDown(KeyCode.R) && isSkill) //����° ��ų
        {

            if (tower.nowSkillCount >= skillArr[2].price)
            {
                tower.GetComponent<Tower>().isSkilling = true;
                tower.nowSkillCount -= skillArr[2].price;
                skillArr[2].Select();
            }
        }

    }


}
