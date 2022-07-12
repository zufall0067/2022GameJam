using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;

public class Enemy : PoolableMono
{
    public Scrollbar HPBar;

    public int hp; //������Ƽ�� ���ߵɵ�..41����
    public int atk;
    public float giveFuel; // �׿����� �ִ� ���ᷮ

    public float movingX = 0;
    public float movingY = 0;

    public Transform targetTrm;
    public Canvas canvas;


    void Start()
    {
        targetTrm = GameObject.Find("Tower").transform;
        Shooting();
        Moving();
        HPbar();
    }

    void Update()
    {
        HPbar();
        if(hp <= 0)
        {
            //�̰� fuel ��ã�� ��ġ�� //////////////////////////////////////////////////////////////////////////////////////
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
        hp = 100; //����������

    }

    public virtual void Shooting()
    {
        
    }

    public virtual void Fire()
    {
        
    }

    public virtual void HPbar()
    {
        canvas = GetComponent<Canvas>();
        canvas.worldCamera = Camera.main;
        HPBar.transform.position = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y + 5f, 0f);
        HPBar.image.fillAmount = hp / 100f;
    }
}
