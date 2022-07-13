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
        SetSkillInterface(titleText1, priceText1, explainText1, iconSprite1, 0);
        SetSkillInterface(titleText2, priceText2, explainText2, iconSprite2, 1);
        SetSkillInterface(titleText3, priceText3, explainText3, iconSprite3, 2);
    }

    public void SkillPanelQuit()
    {
        Time.timeScale = 1f;
        skillPanel.transform.DOMoveY(-2, 0.2f);
        isSkill = false;
    }

    private void SetSkillInterface(Text titleText, Text priceText, Text explainText, GameObject iconSprite, int index)
    {
        titleText.text = skillArr[index].title;
        priceText.text = "[ 파워 " + skillArr[index].price + " 필요 ]";
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
