using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;

public class Enemy : PoolableMono
{
    public SpriteRenderer hpBar;
    //한글입니다
    public float hp; //????????? ??????..41????
    public int atk;
    public float giveFuel; // ??????? ??? ????

    public float movingX = 0;
    public float movingY = 0;

    public Transform targetTrm;


    protected void Awake()
    {
        hpBar = transform.GetChild(0).gameObject.GetComponent<SpriteRenderer>();
        targetTrm = GameObject.Find("Tower").transform;
        Moving();
    }

    public virtual void Update()
    {
        HPBar();
        if (hp <= 0)
        {
            //??? fuel ????? ????? //////////////////////////////////////////////////////////////////////////////////////
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

    public void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.transform.CompareTag("LASER"))
        {
            Debug.Log("??너????격중");
            hp -= collision.transform.GetComponent<LaserBall>().laserDamage;
        }
    }
}
