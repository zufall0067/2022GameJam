using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnergyBall : Skill
{
    private float ChargeEnegry = 0;

    public override void Select()
    {
        isReady = true;
        Debug.Log("에너지볼 장착");
    }

    public void Update()
    {
        if((Input.GetMouseButton(0) || Input.GetMouseButtonUp(0)) && isReady )
        {
            if(ChargeEnegry < 2.5f)
            {
                ChargeEnegry += Time.deltaTime;
            }
            Debug.Log(ChargeEnegry);
            if(Input.GetMouseButtonUp(0))
            {
                isReady = false;
                mousePos = Input.mousePosition;
                mousePos = Camera.ScreenToWorldPoint(mousePos);

                Vector2 dir = mousePos - new Vector2(0, -1); //총알 발사 위치 /*(Vector2)transform.position*/;
                dir.Normalize();

                Bullet bullet = PoolManager.Instance.Pop("EnergyBullet") as Bullet;
                bullet.dir = dir;
                bullet.gameObject.transform.localScale = new Vector3(ChargeEnegry / 3, ChargeEnegry / 3, ChargeEnegry / 3);
                bullet.atk = (int)(ChargeEnegry * 36 + 5);
                bullet.Shoot();
            }
        }
        else
            ChargeEnegry = 0;
    }
}
