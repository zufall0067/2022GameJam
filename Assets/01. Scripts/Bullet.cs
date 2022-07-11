using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : PoolableMono
{
    public Vector2 dir;

    Rigidbody2D rig;

    public Transform firePos;

    public override void Reset()
    {
        transform.position = new Vector3(0,-1,0);//위치
    }

    void Awake()
    {
        rig = GetComponent<Rigidbody2D>();
    }

    public void Shoot()
    {
        rig.AddForce(dir * 1500);

        //테스트 코드
        Invoke("DestroyThis", 5f);
    }

    //테스트 코드
    public void DestroyThis()
    {
        PoolManager.Instance.Push(this);
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        
    }
}
