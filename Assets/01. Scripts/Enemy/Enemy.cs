using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;
using UnityEngine.Events;
using Random = UnityEngine.Random;

public class Enemy : PoolableMono
{
    public SpriteRenderer hpBar;
    public SpriteRenderer spriteRenderer;
    //�ѱ��Դϴ�
    public float fullhp;
    public float hp; //????????? ??????..41????
    public int atk;
    public float giveFuel; // ??????? ??? ????

    public float movingX = 0;
    public float movingY = 0;

    public float speed = 3f;

    public Transform targetTrm;
    public GameObject fuelPiece;

    public Color hitColor;

    private Rigidbody2D _rigid;

    private Vector3 dir;

    public UnityEvent hitEvent;

    //public bool isHitted = false;

    public GameObject DeadParticle;

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
        //if (!isHitted)
        //{
        //    hp = fullhp;
        //}
        if (isMoving)
        {
            transform.position += dir * speed * Time.deltaTime;
        }

        if (hp <= 0)
        {
            //??? fuel ????? ????? //////////////////////////////////////////////////////////////////////////////////////
            //targetTrm.GetComponent<Tower>().fuel += giveFuel;
            int random = Random.Range(0, 180);
            GameObject deadParticle = Instantiate(DeadParticle, transform.position, Quaternion.Euler(0, 0, random));
            deadParticle.transform.DORotate(new Vector3(0, 0, random), 5).OnComplete(() => { Destroy(deadParticle); });

            GameObject _fuelPiece = fuelPiece;
            _fuelPiece = Instantiate(_fuelPiece, transform.position, Quaternion.identity);
            _fuelPiece.GetComponent<FuelPiece>().SetGiveFuel(giveFuel);
            gameObject.SetActive(false);
            Reset();
            PoolManager.Instance.Push(this);
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
            Debug.Log("레이저 맞고있어용!");
            hp -= collision.transform.GetComponent<LaserBall>().laserDamage;
        }

        if (collision.transform.CompareTag("OUTLINE"))
        {
            isMoving = false;
            PoolManager.Instance.Push(this);
        }

        if (collision.transform.CompareTag("BULLET"))
        {

            //collision.transform.GetComponent<Enemy>().hp -= atk;
            //Debug.Log("총알 맞음");
            //StartCoroutine(ChangeColorFeedback());
            //tower.nowPower += tower.recoveryPower;
            //DestroyThis();
        }
    }

    public void StartChangeColorCor()
    {
        StartCoroutine(ChangeColorFeedback());
    }

    public IEnumerator ChangeColorFeedback()
    {
        //isHitted = true;
        CameraManager.Instance.ShakeVoid(0.35f, 0.075f);
        SpriteRenderer renderer = transform.GetComponent<SpriteRenderer>();
        renderer.color = Color.red;

        yield return new WaitForSeconds(0.06f);

        renderer.color = Color.white;
    }

}