using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour
{
    public float fuel;

    bool isGameStart;

    Vector2 mousePos;
    public Camera Camera;

    void Start()
    {
        
    }

    void Update()
    {

        if(Input.GetMouseButtonDown(0))
        {
            mousePos = Input.mousePosition;
            mousePos = Camera.ScreenToWorldPoint(mousePos);

            Vector2 dir = mousePos - (Vector2)transform.position;
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
