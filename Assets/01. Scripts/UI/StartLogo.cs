using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class StartLogo : MonoBehaviour
{
    [SerializeField]
    private GameObject TMPro;


    void Start()
    {
        TMPro.transform.DOScale(new Vector3(1, 1, 1), 0.5f).SetDelay(0.5f);
        StartCoroutine(DG());
    }

    private IEnumerator DG()
    {
        while (true)
        {

            TMPro.transform.DOLocalJump(new Vector3(0, 1.5f), 1, 1, 1f);

            TMPro.transform.DOPunchRotation(new Vector3(Random.Range(-60f, 60), 0), 1f);

            yield return new WaitForSeconds(1f);
        }
    }

    public void DestroyText()
    {
        Destroy(TMPro);
    }
}
