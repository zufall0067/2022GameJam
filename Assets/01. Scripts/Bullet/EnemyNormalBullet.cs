using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyNormalBullet : Bullet
{
    public override void Reset()
    {
        rig.velocity = Vector2.zero;
    }

    public override void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.CompareTag("TOWER"))
        {
            collision.transform.GetComponent<Tower>().fuel -= atk;
            DestroyThis();
        }
    }
}
