using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class StructureMove : MonoBehaviour
{
    private void OnEnable()
    {
        if (this.gameObject.transform.position.x > 0f)
        {
            this.gameObject.transform.DOMoveX(-12f, Random.Range(4f, 8f)).OnComplete(() => { this.gameObject.SetActive(false); });
        }
        else
        {
            this.gameObject.transform.DOMoveX(12f, Random.Range(4f, 8f)).OnComplete(() => { this.gameObject.SetActive(false); });
        }
    }
}
