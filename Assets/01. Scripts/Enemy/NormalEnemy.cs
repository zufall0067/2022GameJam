using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NormalEnemy : Enemy
{
    //�ʿ��Ѱ�  :  ���ݷ�, ü�� ��, ��ƮȮ��, �÷��̾���ġ, �׾����� ����
    public override void Shooting()
    {
        //InvokeRepeating("Fire", 1f, 2.5f);

        //Fire();
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

    public override void HPBar()
    {
        hpBar.transform.localScale = new Vector3(hp / fullhp / 2f, 0.07f, 1);
    }

    public override void Reset()
    {
        fullhp = 100;
        hp = fullhp;
        base.Reset();
    }

}
