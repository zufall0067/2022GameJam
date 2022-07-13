using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireballBullet : Bullet
{
    public Transform firePos;

    public override void Reset()
    {
        transform.position = new Vector3(0, -1, 0);//위치
        rig.velocity = Vector2.zero;
    }

    public override void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("부딪침");
        if (collision.transform.CompareTag("ENEMY"))
        {
            collision.transform.GetComponent<Enemy>().hp -= atk;
            ///collision.transform.GetComponent<Enemy>().
            DestroyThis();
        }
        if (collision.transform.CompareTag("OUTLINE"))
        {
            Debug.Log("벽당했다.");
            DestroyThis();
        }
    }
}
