using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerNormalBullet : Bullet
{
    public Transform firePos;
    private Tower tower = null;
    public override void Reset()
    {
        transform.gameObject.SetActive(false);
        //transform.localPosition = new Vector3(1, 1, 1);
        tower = FindObjectOfType<Tower>();
        //transform.position = new Vector3(0, -1, 0);//��ġ
        rig.velocity = Vector2.zero;
    }

    public override void OnCollisionEnter2D(Collision2D collision)
    {
       
        if (collision.gameObject.transform.CompareTag("OUTLINE"))
        {
            DestroyThis();
        }

        if (collision.gameObject.transform.CompareTag("ENEMY"))
        {
            collision.transform.GetComponent<Enemy>().hp -= atk;
            collision.transform.GetComponent<Enemy>().StartChangeColorCor();
            
            //StartCoroutine(ChangeColorFeedback(collision));
            tower.nowPower += tower.recoveryPower;
            DestroyThis();
        }
    }

    
     
    
}
