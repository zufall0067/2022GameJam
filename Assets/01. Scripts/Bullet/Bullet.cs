using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : PoolableMono
{
    public int atk;

    public Vector2 dir;

    protected Rigidbody2D rig;


    public override void Reset()
    {

    }

    void Awake()
    {
        rig = GetComponent<Rigidbody2D>();
    }

    public void Shoot()
    {
        rig.AddForce(dir * 1250);

        //테스트 코드 아닐지도~~
        Invoke("DestroyThis", 10f);
    }

    //테스트 코드
    public void DestroyThis()
    {
        PoolManager.Instance.Push(this);
    }

    public virtual void OnCollisionEnter2D(Collision2D collision)
    {
        
    }

}
