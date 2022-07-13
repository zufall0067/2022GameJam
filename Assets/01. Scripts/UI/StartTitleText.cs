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

            TMPro.transform.DOLocalJump(new Vector3(0, 200f), 40, 1, 1f);

            TMPro.transform.DOPunchRotation(new Vector3(Random.Range(-180f, 180), 0), 1f);

            yield return new WaitForSeconds(1f);
        }
    }

    public void DestroyText()
    {
        Destroy(TMPro);
    }
}
