using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skill : MonoBehaviour
{
    protected Vector2 mousePos;
    public Camera Camera;
    //protected bool immediately; //��ùߵ��Ǵ� ��ų�ΰ�? (���� ���� ����)
    //protected bool isAttackSkill; //������ ��ų�ΰ�?
    protected bool isReady;

    //public override void Reset()
    //{
    //    //throw new System.NotImplementedException();
    //}

    public virtual void Select()
    {

    }
}
