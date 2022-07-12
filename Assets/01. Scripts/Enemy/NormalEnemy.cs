using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NormalEnemy : Enemy
{
    //�ʿ��Ѱ�  :  ���ݷ�, ü�� ��, ��ƮȮ��, �÷��̾���ġ, �׾����� ����
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
