using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;
using UnityEngine.Events;

public class Enemy : PoolableMono
{
    public SpriteRenderer hpBar;
    //�ѱ��Դϴ�
    public float hp; //????????? ??????..41????
    public int atk;
    public float giveFuel; // ??????? ??? ????

    public float movingX = 0;
    public float movingY = 0;

    public float speed;

    public Transform targetTrm;
    public GameObject fuelPiece;

    public Color hitColor;

    public UnityEvent BulletHitFeedback;

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
            //targetTrm.GetComponent<Tower>().fuel += giveFuel;
            GameObject _fuelPiece = fuelPiece;
            _fuelPiece = Instantiate(_fuelPiece, transform.position, Quaternion.identity);
            _fuelPiece.GetComponent<FuelPiece>().SetGiveFuel(giveFuel);
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
            Debug.Log("??��????����");
            hp -= collision.transform.GetComponent<LaserBall>().laserDamage;
        }
    }
}
