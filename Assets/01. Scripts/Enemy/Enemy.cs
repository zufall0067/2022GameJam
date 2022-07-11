using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Enemy : PoolableMono
{
    public int hp; //������Ƽ�� ���ߵɵ�..41����
    public int atk;

    public float movingX = 0;
    public float movingY = 0;

    public Transform targetTrm;

    void Start()
    {
        targetTrm = GameObject.Find("Tower").transform;
        Shooting();
        Moving();
    }

    void Update()
    {
        if(hp <= 0)
        {
            PoolManager.Instance.Push(this);
        }
    }

    protected void Moving()
    {
        //movingY += 0.1f;
        //transform.position = new Vector2(movingX, movingY);
    }

    public override void Reset()
    {
        transform.DOComplete();
        hp = 10; //����������
    }

    public virtual void Shooting()
    {
        
    }

    public virtual void Fire()
    {
        
    }
}
