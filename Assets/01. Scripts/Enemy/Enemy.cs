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
    public SpriteRenderer spriteRenderer;
    //�ѱ��Դϴ�
    public float hp; //????????? ??????..41????
    public int atk;
    public float giveFuel; // ??????? ??? ????

    public float movingX = 0;
    public float movingY = 0;

    public float speed = 3f;

    public Transform targetTrm;
    public GameObject fuelPiece;

    public Color hitColor;

    public UnityEvent BulletHitFeedback;

    private Rigidbody2D _rigid;

    private Vector3 dir;


    Transform startTrm;
    Transform endTrm;
    bool isMoving;
    protected void Awake()
    {
        hpBar = transform.GetChild(0).gameObject.GetComponent<SpriteRenderer>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        targetTrm = GameObject.Find("Tower").transform;
        _rigid = GetComponent<Rigidbody2D>();
    }

    public virtual void Update()
    {

        HPBar();

        if (isMoving)
        {
            transform.position += dir * speed * Time.deltaTime;
        }

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

    public void Moving(Transform start, Vector2 getdir)
    {
        dir.Normalize();
        transform.position = start.position;
        dir.z = 0;
        dir = getdir;

        isMoving = true;
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

        if (collision.transform.CompareTag("OUTLINE"))
        {
            isMoving = false;
            PoolManager.Instance.Push(this);
        }

        if (collision.gameObject.transform.CompareTag("ENEMY"))
        {
            //collision.transform.GetComponent<Enemy>().hp -= atk;
            StartCoroutine(ChangeColorFeedback());
            //tower.nowPower += tower.recoveryPower;
            //DestroyThis();
        }
    }



    public IEnumerator ChangeColorFeedback()
    {
        SpriteRenderer renderer = transform.GetComponent<SpriteRenderer>();
        renderer.color = Color.red;
        Debug.Log("?�하");

        yield return new WaitForSeconds(0.2f);

        renderer.color = Color.white;

    }

}