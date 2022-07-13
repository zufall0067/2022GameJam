using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireballExplosionBullet : Bullet
{
    // Start is called before the first frame update
    private float colCount = 0.1f;
    private float nowCount = 0;
    Collider2D col;
    void Start()
    {
        col = GetComponent<Collider2D>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.transform.CompareTag("ENEMY"))
        {
            Debug.Log("Fireball Damaaged");
            other.transform.GetComponent<Enemy>().hp -= atk;
            DestroyThis();
        }
    }

    private void Update()
    {
        if (nowCount >= colCount) { ColliderFalse(); }
    }

    public void ColliderFalse()
    {
        col.enabled = false;
    }
}
