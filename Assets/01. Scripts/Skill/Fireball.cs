using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fireball : Skill
{
    public override void Select()
    {
        price = 2;
        isReady = true;
        SetCurrentSkill(icon, title);
        Debug.Log("파이어볼 장착");
        //price = 25;
    }

    void Update()
    {
        if (isReady && Input.GetMouseButtonDown(0))
        {
            SkillManager.Instance.SkillPanelQuit();

            isReady = false;
            mousePos = Input.mousePosition;
            mousePos = Camera.ScreenToWorldPoint(mousePos);

            Vector2 dir = mousePos - new Vector2(0, -1); //�Ѿ� �߻� ��ġ /*(Vector2)transform.position*/;
            dir.Normalize();

            SetCurrentSkill(temp, " ");
            Bullet bullet = PoolManager.Instance.Pop("Fireball") as Bullet;
            bullet.dir = dir;
            bullet.Shoot();
            tower.isSkilling = false;


        }
    }
}
