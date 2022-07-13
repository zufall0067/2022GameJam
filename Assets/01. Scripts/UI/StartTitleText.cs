using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using DG.Tweening;

public class StartTitleText : MonoBehaviour
{
    [SerializeField]
    private GameObject TMPro;

    Sequence sequence;

    void Start()
    {
        StartCoroutine(DG());
    }

    private IEnumerator DG()
    {
        while(true)
        {
            Debug.Log("WKFKDSK");

            sequence.Append(TMPro.transform.DOMove(new Vector3(0, 200, 0), 3));


            yield return new WaitForSeconds(2.2f);
        }
    }

    public void DestroyText()
    {
        Destroy(TMPro);
    }
}
