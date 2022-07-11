using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireballBullet : Bullet
{
    public Transform firePos;

    public override void Reset()
    {
        transform.position = new Vector3(0, -1, 0);//À§Ä¡
        rig.velocity = Vector2.zero;
    }

    public override void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("ºÎµúÄ§");
        if (collision.transform.CompareTag("ENEMY"))
        {
            collision.transform.GetComponent<Enemy>().hp -= atk;
            DestroyThis();
        }
    }
}
