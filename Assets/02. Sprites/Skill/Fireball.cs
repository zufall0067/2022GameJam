using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fireball : Skill
{
    public override void Select()
    {
        isReady = true;
        Debug.Log("파이어볼 장착");
    }

    void Update()
    {
        if(isReady && Input.GetMouseButtonDown(0))
        {
            isReady = false;
            mousePos = Input.mousePosition;
            mousePos = Camera.ScreenToWorldPoint(mousePos);

            Vector2 dir = mousePos - new Vector2(0, -1); //총알 발사 위치 /*(Vector2)transform.position*/;
            dir.Normalize();

            Bullet bullet = PoolManager.Instance.Pop("Fireball") as Bullet;
            bullet.dir = dir;
            bullet.Shoot();
            tower.isSkilling = false;
        }
    }
}
