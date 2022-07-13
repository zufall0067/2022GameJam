using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireballAni : MonoBehaviour
{
    public void DestroyThis()
    {
        Destroy(this.gameObject);
    }

    public void ColliderFalse()
    {
        Collider2D col;
        col = transform.parent.GetComponent<Collider2D>();
        col.enabled = false;
    }
}
