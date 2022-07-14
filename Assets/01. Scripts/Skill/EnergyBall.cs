using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnergyBall : Skill
{
    private float ChargeEnegry = 0;
    private bool chargeStart = false;
    public override void Select()
    {
        price = 1;
        isReady = true;
        SetCurrentSkill(icon, title);
    }

    public void Update()
    {
        if (isReady)
        {
            if (Input.GetMouseButtonDown(0))
            {
                chargeStart = true;
            }
            if (chargeStart)
            {
                ChargeEnegry += Time.deltaTime;
            }

            if (Input.GetMouseButtonUp(0))
            {
                PlayEffect(0);
                Debug.Log("Charge End");
                SkillManager.Instance.SkillPanelQuit();
                chargeStart = false;
                if (ChargeEnegry > 1)
                {
                    ChargeEnegry = 1;
                }
                ChargeEnegry *= 2.5f;
                isReady = false;
                mousePos = Input.mousePosition;
                mousePos = Camera.ScreenToWorldPoint(mousePos);

                Vector2 dir = mousePos - (Vector2)tower.transform.position; //�Ѿ� �߻� ��ġ /*(Vector2)transform.position*/;
                dir.Normalize();
                SetCurrentSkill(temp, " ");
                Bullet bullet = PoolManager.Instance.Pop("EnergyBullet") as Bullet;
                bullet.transform.position = (Vector2)tower.transform.position;
                bullet.dir = dir;
                bullet.gameObject.transform.localScale = new Vector3(ChargeEnegry * 2 + 1, ChargeEnegry * 2 + 1, ChargeEnegry * 3);

                bullet.atk = (int)(ChargeEnegry * 48 + 5);
                bullet.Shoot();
                ChargeEnegry = 0;
                isReady = false;
                tower.isSkilling = false;
            }
        }


        // if ((Input.GetMouseButton(0) || Input.GetMouseButtonUp(0)) && isReady)
        // {
        //     SkillManager.Instance.SkillPanelQuit();
        //     if (ChargeEnegry <= 1f)
        //     {
        //         ChargeEnegry += Time.deltaTime;
        //     }
        //     else if (ChargeEnegry > 1f)
        //     {
        //         ChargeEnegry = 1f;
        //     }

        //     if (Input.GetMouseButtonUp(0))
        //     {
        //         ChargeEnegry *= 2.5f;
        //         isReady = false;
        //         mousePos = Input.mousePosition;
        //         mousePos = Camera.ScreenToWorldPoint(mousePos);

        //         Vector2 dir = mousePos - new Vector2(0, -1); //�Ѿ� �߻� ��ġ /*(Vector2)transform.position*/;
        //         dir.Normalize();

        //         Bullet bullet = PoolManager.Instance.Pop("EnergyBullet") as Bullet;
        //         bullet.transform.position = new Vector2(0, -1);
        //         bullet.dir = dir;
        //         bullet.gameObject.transform.localScale =

        //         new Vector3(bullet.gameObject.transform.localScale.x * ChargeEnegry, bullet.gameObject.transform.localScale.y * ChargeEnegry, bullet.gameObject.transform.localScale.z * ChargeEnegry);

        //         bullet.atk = (int)(ChargeEnegry * 36 + 5);
        //         bullet.Shoot();
        //     }
        // }
        // else
        //     ChargeEnegry = 0;
    }
}
