using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour
{
    public float fuel = 200;

    bool isGameStart;
    public bool isSkilling;

    Vector2 mousePos;
    public Camera Camera;

    public int bulletCount = 0;
    public bool isReloading = false;
    public float reloadCount = 0;
    public float overReloadCount = 1f;
    void Start()
    {

    }

    void Update()
    {
        FuelDecrease();

        if (Input.GetMouseButtonDown(0) && !isSkilling && !isReloading)
        {
            if (SkillManager.Instance.isSkill == true) return;
            mousePos = Input.mousePosition;
            mousePos = Camera.ScreenToWorldPoint(mousePos);

            Vector2 dir = mousePos - new Vector2(0, -1); //�Ѿ� �߻� ��ġ /*(Vector2)transform.position*/;
            dir.Normalize();

            Bullet bullet = PoolManager.Instance.Pop("Bullet") as Bullet;
            bullet.dir = dir;
            bullet.Shoot();
            bulletCount++;
        }

        if (bulletCount >= 10 || Input.GetKeyDown(KeyCode.R))
        {
            if (!isReloading)
            {
                Debug.Log("Reload Start");
                isReloading = true;
            }
        }

        if (isReloading)
        {
            reloadCount += Time.deltaTime;
            if (reloadCount >= overReloadCount)
            {
                Debug.Log("Reload end");
                bulletCount = 0;
                reloadCount = 0;
                isReloading = false;
            }
        }

        UIManager.Instance.fuelText.text = fuel.ToString();
    }

    private void FuelDecrease()
    {
        if (fuel < 0) return;
        fuel -= Time.deltaTime * 30f;

        if (fuel < 0) Debug.Log("����");
    }

    private void Fire()
    {

    }

}
