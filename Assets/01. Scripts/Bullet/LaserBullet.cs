using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserBullet : Bullet
{
    private Collision2D raserCollision = null;

    public override void Reset()
    {
        transform.position = new Vector3(0, -1, 0);//��ġ
        rig.velocity = Vector2.zero;
    }

    public void OnEnable()
    {
        StartCoroutine(LaserAtk());
        StartCoroutine(LaserAge());
    }

    public override void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("�ε�ħ");
        if (collision.transform.CompareTag("ENEMY"))
        {
            raserCollision = collision;
        }
    }

    public void OnCollisionExit2D(Collision2D collision)
    {
        Debug.Log("������");
        if (collision.transform.CompareTag("ENEMY"))
        {
            raserCollision = null;
        }
    }

    public IEnumerator LaserAtk()
    {
        while (true)
        {
            if (raserCollision == null)
            {
                yield return 0;
            }
            else
            {
                raserCollision.transform.GetComponent<Enemy>().hp -= atk;
                yield return new WaitForSeconds(0.2f);
            }
        }
    }

    public IEnumerator LaserAge()
    {
        yield return new WaitForSeconds(1.5f);
        DestroyThis();
    }
}
