using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;

public class Enemy : PoolableMono
{
    public SpriteRenderer hpBar;

    public int hp; //프로퍼티로 빼야될듯..41번줄
    public int atk;

    public float movingX = 0;
    public float movingY = 0;

    public Transform targetTrm;


    void Start()
    {
        hpBar = transform.GetChild(0).gameObject.GetComponent<SpriteRenderer>();
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
        CancelInvoke();
        hp = 100; //존나귀찮네
    }

    public virtual void Shooting()
    {
        
    }

    public virtual void Fire()
    {

    }

    public virtual void HPBar()
    {

    }
}
