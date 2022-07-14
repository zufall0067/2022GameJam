using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireballBullet : Bullet
{
    public Transform firePos;

    public GameObject bombAni;

    public override void Reset()
    {
        transform.position = new Vector3(0, -1, 0);//��ġ
        rig.velocity = Vector2.zero;
    }

    public override void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.CompareTag("ENEMY"))
        {
            //collision.transform.GetComponent<Enemy>().hp -= atk;
            CameraManager.Instance.ShakeVoid(1f, 0.3f);
            GameObject ani = Instantiate(bombAni, transform.position, Quaternion.identity);
            DestroyThis();
        }
        else if (collision.transform.CompareTag("OUTLINE"))
        {
            DestroyThis();
        }
    }
    private void OnTriggerEnter2D(Collider2D other)
    {

    }
}
