using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NormalEnemy : Enemy
{
    //�ʿ��Ѱ�  :  ���ݷ�, ü�� ��, ��ƮȮ��, �÷��̾���ġ, �׾����� ����
    public override void Shooting()
    {
        InvokeRepeating("Fire", 3f, 1f);
    }

    public override void Fire()
    {
        Debug.Log("�븻���ʹ����̾�");
        Debug.Log(targetTrm.position);
        Debug.Log(transform.position);
        Vector2 dir = targetTrm.position - transform.position;
        dir.Normalize();
        Bullet bullet = PoolManager.Instance.Pop("EnemyBullet") as Bullet;
        bullet.transform.position = transform.position;
        bullet.dir = dir;
        bullet.Shoot();
    }

}
