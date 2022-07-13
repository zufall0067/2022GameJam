using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireballExplosionBullet : MonoBehaviour
{
    // Start is called before the first frame update
    private float colCount = 0.1f;
    private float nowCount = 0;
    int atk;
    Collider2D col;
    void Start()
    {
        col = GetComponent<Collider2D>();
        atk = 75;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.transform.CompareTag("ENEMY"))
        {
            Debug.Log("Fireball Damaaged");
            other.transform.GetComponent<Enemy>().hp -= atk;
            //Destroy(gameObject);
        }
    }

    private void Update()
    {
        nowCount += Time.deltaTime;
        if (nowCount >= colCount) { ColliderFalse(); }
        if (nowCount >= 1) { Destroy(gameObject); }
    }

    public void ColliderFalse()
    {
        col.enabled = false;
    }
}
