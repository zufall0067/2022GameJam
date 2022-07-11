using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour
{
    public float fuel;

    bool isGameStart;
    public bool isSkilling;

    Vector2 mousePos;
    public Camera Camera;
    

    void Start()
    {
        
    }

    void Update()
    {

        if(Input.GetMouseButtonDown(0) && !isSkilling)
        {
            mousePos = Input.mousePosition;
            mousePos = Camera.ScreenToWorldPoint(mousePos);

            Vector2 dir = mousePos - new Vector2(0, -1); //총알 발사 위치 /*(Vector2)transform.position*/;
            dir.Normalize();

            Bullet bullet = PoolManager.Instance.Pop("Bullet") as Bullet;
            bullet.dir = dir;
            bullet.Shoot();
        }
    }

    private void Fire()
    {

    }

}
