using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerNormalBullet : Bullet
{
    public Transform firePos;
    private Tower tower = null;
    public override void Reset()
    {
        //transform.localPosition = new Vector3(1, 1, 1);
        tower = FindObjectOfType<Tower>();
        //transform.position = new Vector3(0, -1, 0);//��ġ
        rig.velocity = Vector2.zero;
    }

    public override void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.CompareTag("ENEMY"))
        {
            collision.transform.GetComponent<Enemy>().hp -= atk;
            StartCoroutine(ChangeColorFeedback(collision));
            tower.nowPower += tower.recoveryPower;
            DestroyThis();
        }
        if (collision.transform.CompareTag("OUTLINE"))
        {
            Debug.Log("�����ߴ�.");
            DestroyThis();
        }
    }

    public IEnumerator ChangeColorFeedback(Collision2D collision)
    {
        SpriteRenderer renderer = collision.transform.GetComponent<SpriteRenderer>();
        renderer.color = Color.red;
        Debug.Log("asd");
        yield return new WaitForSecondsRealtime(0.2f);
        Debug.Log(renderer);
        //renderer.color = Color.white;
    }
}
