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
        while(true)
        {
            Debug.Log("·çÇÁ µÊ");

            Transform nowRotate = this.gameObject.transform;

            gameObject.transform.DORotate(new Vector3(0, 180 + nowRotate.rotation.y, 0), 1).OnComplete(()
                => { this.gameObject.transform.DOMoveX(nowRotate.position.x + Random.Range(-1.5f, 1.5f), Random.Range(6f, 8f)); });

            yield return new WaitForSeconds(Random.Range(3f, 5f));
        }
    }

    void Update()
    {
        
    }
}
