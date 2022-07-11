using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnergyBall : Skill
{
    private float ChageEnegry = 0;

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

                Vector2 dir = mousePos - new Vector2(0, -1); //총알 발사 위치 /*(Vector2)transform.position*/;
                dir.Normalize();

                Bullet bullet = PoolManager.Instance.Pop("EnergyBall") as Bullet;
                bullet.dir = dir;
                bullet.Shoot();
            }
        }
    }
}
