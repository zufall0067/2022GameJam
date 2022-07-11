using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : PoolableMono
{
    public int hp;
    public int atk;

    public Transform targetTrm;

    void Start()
    {
        targetTrm = GameObject.Find("Tower").transform;
        Shooting();
    }

    public override void Reset()
    {
        throw new System.NotImplementedException();
    }

    public virtual void Shooting()
    {
        
    }

    public virtual void Fire()
    {
        
    }
}
