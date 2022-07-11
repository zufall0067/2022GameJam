using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class SkillManager : MonoBehaviour
{

    public GameObject skillPanel;
    public bool isSkill;

    public Skill[] skillArr;

    public Tower tower;

    void Awake()
    {
       // tower = GetComponent<Tower>();
    }

    void Start()
    {
        
    }
    

    void Update()
    {
        if (Input.GetMouseButtonDown(1))
        {
            //skillPanel.transform.DOComplete();
            skillPanel.transform.DOMoveY(0, 0.25f);
            isSkill = true;
        }
        if (Input.GetMouseButtonUp(1))
        {
            //skillPanel.transform.DOComplete();
            skillPanel.transform.DOMoveY(-2, 0.25f);
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
