using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skill : MonoBehaviour
{
    protected Vector2 mousePos;
    public Camera Camera;
    //protected bool immediately; //즉시발동되는 스킬인가? (예로 연료 충전)
    //protected bool isAttackSkill; //공격형 스킬인가?
    protected bool isReady;

    //public override void Reset()
    //{
    //    //throw new System.NotImplementedException();
    //}

    public virtual void Select()
    {

    }
}
