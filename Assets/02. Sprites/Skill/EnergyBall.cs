using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnergyBall : Skill
{
    private float ChargeEnegry = 0;

    public override void Select()
    {
        base.Select();
    }

    public void Update()
    {
        if(Input.GetMouseButton(0))
        {
            if(Input.GetMouseButtonUp(0))
            {
                mousePos = Input.mousePosition;
                mousePos = Camera.ScreenToWorldPoint(mousePos);

                Vector2 dir = mousePos - new Vector2(0, -1); //�Ѿ� �߻� ��ġ /*(Vector2)transform.position*/;
                dir.Normalize();

                Bullet bullet = PoolManager.Instance.Pop("EnergyBullet") as Bullet;
                bullet.dir = dir;
                bullet.gameObject.transform.localScale = new Vector3(ChargeEnegry / 2, ChargeEnegry / 2, ChargeEnegry / 2);
                bullet.Shoot();
            }
        }
    }
}
