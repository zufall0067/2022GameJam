using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnergyBall : Skill
{
    private float ChargeEnegry = 0;

    public override void Select()
    {
        price = 25;
        isReady = true;
        Debug.Log("에너르기파~");
    }

    public void Update()
    {
        if ((Input.GetMouseButton(0) || Input.GetMouseButtonUp(0)) && isReady)
        {
            SkillManager.Instance.SkillPanelQuit();
            if (ChargeEnegry < 2.5f)
            {
                ChargeEnegry += Time.deltaTime;
            }
            if (Input.GetMouseButtonUp(0))
            {
                isReady = false;
                mousePos = Input.mousePosition;
                mousePos = Camera.ScreenToWorldPoint(mousePos);

                Vector2 dir = mousePos - new Vector2(0, -1); //�Ѿ� �߻� ��ġ /*(Vector2)transform.position*/;
                dir.Normalize();

                Bullet bullet = PoolManager.Instance.Pop("EnergyBullet") as Bullet;
                bullet.dir = dir;
                bullet.gameObject.transform.localScale = new Vector3(ChargeEnegry / 3, ChargeEnegry / 3, ChargeEnegry / 3);
                bullet.atk = (int)(ChargeEnegry * 36 + 5);
                bullet.Shoot();
                tower.isSkilling = false;
            }
        }
        else
            ChargeEnegry = 0;
    }
}
