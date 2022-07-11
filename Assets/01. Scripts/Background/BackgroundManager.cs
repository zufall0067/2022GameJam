using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class BackgroundManager : MonoBehaviour
{
    [SerializeField] // 배경을 변경하는데 걸리는 시간
    private float[] floorChangeDelay;

    //지나간 시간
    private float nowTime;
    //지금 켜져있는 배경 오브젝트
    private int nowActiveBackgroundObject;
    //배경 게임 오브젝트 
    public GameObject[] backgroundGameObject;



    private void Start()
    {
        Instantiate(backgroundGameObject[0], this.gameObject.transform);
        nowTime = 0f;
        nowActiveBackgroundObject = 0;
    }

    private void Update()
    {
        nowTime += Time.deltaTime;

        if(nowTime > floorChangeDelay[nowActiveBackgroundObject])
        {
            nowActiveBackgroundObject++;
            nowTime = 0f;

            Instantiate(backgroundGameObject[nowActiveBackgroundObject], this.gameObject.transform);
            this.gameObject.transform.GetChild(0).GetComponent<Material>().DOFade(0,1);
        }
    }
}
