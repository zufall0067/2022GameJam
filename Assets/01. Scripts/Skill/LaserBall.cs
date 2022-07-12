using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserBall : Skill
{
    public override void Select()
    {
        isReady = true;
        Debug.Log("레이저 장착");
    }


    void Update()
    {
        if (isReady && Input.GetMouseButtonDown(0))
        {
            isReady = false;
            mousePos = Input.mousePosition;
            mousePos = Camera.ScreenToWorldPoint(mousePos);

            Vector2 dir = mousePos - new Vector2(0, -1); //총알 발사 위치 /*(Vector2)transform.position*/;
            dir.Normalize();

            Bullet bullet = PoolManager.Instance.Pop("Laser") as Bullet;
            bullet.dir = dir;
            bullet.transform.localRotation = Quaternion.Euler(0,0, (dir.y * dir.x));
            tower.isSkilling = false;
        }
    }
}
