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

        //this.gameObject.transform.Domove
        
        yield return null;
    }

    void Update()
    {
        
    }
}
