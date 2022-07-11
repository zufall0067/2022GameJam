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

    }

    void OnEnable()
    {
        Invoke("DestroyThis", 10f);
    }

    void Awake()
    {
        rig = GetComponent<Rigidbody2D>();
    }

    public void Shoot()
    {
        rig.AddForce(dir * force);

        //�׽�Ʈ �ڵ� �ƴ�����~~
    }

    //�׽�Ʈ �ڵ�
    public void DestroyThis()
    {
        PoolManager.Instance.Push(this);
    }

    public virtual void OnCollisionEnter2D(Collision2D collision)
    {
        
    }

}
