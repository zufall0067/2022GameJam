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

    void Start()
    {
        StartCoroutine(DG());
    }

    private IEnumerator DG()
    {
        while(true)
        {
            Debug.Log("WKFKDSK");

            TMPro.transform.DOPunchPosition(TMPro.transform.position, 2);

            yield return new WaitForSeconds(2.2f);
        }
    }

    public void DestroyText()
    {
        Destroy(TMPro);
    }
}
