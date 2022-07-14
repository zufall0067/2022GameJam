using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class SettingButtonTween : MonoBehaviour
{

    public PlayerSkillSettingManager playerSkillSettingManager;

    private void Awake()
    {
        
    }

    void Start()
    {
        if(playerSkillSettingManager.isSettingButtonFirstPush == false)
        {
            StartCoroutine(DGTween());
        }
    }

    public IEnumerator DGTween()
    {
        while(true)
        {
            this.gameObject.transform.DOPunchScale(this.gameObject.transform.position, 2);
            this.gameObject.transform.DOPunchRotation(this.gameObject.transform.position, 2);
            this.gameObject.transform.DOPunchPosition(this.gameObject.transform.position, 2);

            yield return new WaitForSeconds(2.1f);
        }
    }

    private void OnDisable()
    {
        StopAllCoroutines();
        this.gameObject.transform.DOKill();
    }
}
