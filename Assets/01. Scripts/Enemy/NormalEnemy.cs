using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NormalEnemy : Enemy
{
    //필요한것  :  공격력, 체력 바, 히트확인, 플레이어위치, 죽었을때 연료
    public override void Shooting()
    {
        InvokeRepeating("Fire", 1f, 1f);
    }

    public override void Fire()
    {
        Vector2 dir = targetTrm.position - transform.position;
        dir.Normalize();
        if (!this.gameObject.activeSelf) return;
        Bullet bullet = PoolManager.Instance.Pop("EnemyBullet") as Bullet;
        bullet.transform.position = transform.position;
        bullet.dir = dir;
        
        bullet.Shoot();
    }
    public override void HPbar()
    {
        base.HPbar();
    }
}
