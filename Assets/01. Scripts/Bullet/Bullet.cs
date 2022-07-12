using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : PoolableMono
{
    public int atk;
    public int force = 1250;
    public Vector2 dir;

    protected Rigidbody2D rig;


    public override void Reset()
    {
        //CancelInvoke("DestroyThis");
    }

    void OnEnable()
    {
        //Invoke("DestroyThis", 0.5f);
    }

    void Awake()
    {
        rig = GetComponent<Rigidbody2D>();
    }

    public void Shoot()
    {
        rig.AddForce(dir * force);

        //테스트 코드 아닐지도~~
    }

    //테스트 코드
    public void DestroyThis()
    {
        //if(gameObject.activeSelf)
        PoolManager.Instance.Push(this);
    }

    public virtual void OnCollisionEnter2D(Collision2D collision)
    {
        
    }

}
