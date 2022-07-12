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
    


    void Start()
    {
        
    }

    void Update()
    {
        FuelDecrease();

        if (Input.GetMouseButtonDown(0) && !isSkilling)
        {
            if (SkillManager.Instance.isSkill == true) return;
            mousePos = Input.mousePosition;
            mousePos = Camera.ScreenToWorldPoint(mousePos);

            Vector2 dir = mousePos - new Vector2(0, -1); //ÃÑ¾Ë ¹ß»ç À§Ä¡ /*(Vector2)transform.position*/;
            dir.Normalize();

            Bullet bullet = PoolManager.Instance.Pop("Bullet") as Bullet;
            bullet.dir = dir;
            bullet.Shoot();
        }

        UIManager.Instance.fuelText.text = fuel.ToString();
    }

    private void FuelDecrease()
    {
        if (fuel < 0) return;
        fuel -= Time.deltaTime * 30f;

        if (fuel < 0) Debug.Log("µÚÁü");
    }

    private void Fire()
    {

    }

}
