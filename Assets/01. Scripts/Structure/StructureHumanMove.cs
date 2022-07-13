using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class StructureHumanMove : MonoBehaviour
{
    void Start()
    {
        StartCoroutine(Move());
    }

    private IEnumerator Move()
    {
        Transform nowRotate = this.gameObject.transform;

        this.gameObject.transform.DORotate(new Vector3(0, nowRotate.rotation.y * -1), 0);

        this.gameObject.transform.DOMoveX(this.gameObject.transform.forward.x * 1.2f, Random.Range(6f, 8f));
        
        yield return null;
    }

    void Update()
    {
        
    }
}
