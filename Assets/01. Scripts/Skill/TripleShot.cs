using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TripleShot : Skill
{
    public override void Select()
    {
        isReady = true;
        Debug.Log("Ʈ���� ��");
    }

    void Update()
    {
        if (isReady && Input.GetMouseButtonDown(0))
        {
            if (CheckPriceOver())
            {
                isReady = false;
                mousePos = Input.mousePosition;
                mousePos = Camera.ScreenToWorldPoint(mousePos);

                Vector2 dir = mousePos - new Vector2(0, -1); //�Ѿ� �߻� ��ġ /*(Vector2)transform.position*/;
                dir.Normalize();

                Bullet bullet = PoolManager.Instance.Pop("") as Bullet;
                bullet.dir = dir;
                bullet.Shoot();
                tower.isSkilling = false;
            }
        }
    }
}
