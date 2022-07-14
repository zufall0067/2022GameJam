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
        //price = 25;
    }

    void Update()
    {
        if (isReady && Input.GetMouseButtonDown(0))
        {
            isReady = false;
            PlayEffect(0);
            SkillManager.Instance.SkillPanelQuit();

            mousePos = Input.mousePosition;
            mousePos = Camera.ScreenToWorldPoint(mousePos);

            Vector2 dir = mousePos - (Vector2)tower.transform.position; //�Ѿ� �߻� ��ġ /*(Vector2)transform.position*/;
            dir.Normalize();

            SetCurrentSkill(temp, " ");
            Bullet bullet = PoolManager.Instance.Pop("Fireball") as Bullet;
            bullet.transform.position = (Vector2)tower.transform.position;
            bullet.dir = dir;
            bullet.Shoot();
            tower.isSkilling = false;
        }
    }
}
