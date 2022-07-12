using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Enemy : PoolableMono
{
    public int hp; //프로퍼티로 빼야될듯..41번줄
    public int atk;
    public float giveFuel; // 죽였을때 주는 연료량

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
            //이거 fuel 못찾음 고치셈 //////////////////////////////////////////////////////////////////////////////////////
            targetTrm.GetComponent<Tower>().fuel += giveFuel;
            gameObject.SetActive(false);
            Reset();
            //PoolManager.Instance.Push(this);
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
        hp = 4; //존나귀찮네
        //
    }

    public virtual void Shooting()
    {
        
    }

    public virtual void Fire()
    {
        
    }
}
