using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class BackgroundManager : MonoBehaviour
{
    [SerializeField] // 배경을 변경하는데 걸리는 시간
    private float[] floorChangeDelay;
    //위 배열 크기 받는 애
    private int floorCount;

    [SerializeField] //배경 게임 오브젝트 
    private GameObject[] backgroundGameObject;
    //위 배열 크기 받는 애
    private int backgroundGameObjectCount;

    //지나간 시간
    private float nowTime;
    //지금 켜져있는 배경 오브젝트
    private int nowActiveBackgroundObject;
    



    private void Start()
    {
        nowTime = 0f;
        nowActiveBackgroundObject = 0;
        floorCount = floorChangeDelay.Length;
        backgroundGameObjectCount = backgroundGameObject.Length;
        Instantiate(backgroundGameObject[0], this.gameObject.transform);
        
    }

    private void Update()
    {
        nowTime += Time.deltaTime;

        if(nowTime > floorChangeDelay[nowActiveBackgroundObject] && backgroundGameObjectCount > nowActiveBackgroundObject)
        {
            nowActiveBackgroundObject++;
            nowTime = 0f;

            Instantiate(backgroundGameObject[nowActiveBackgroundObject], this.gameObject.transform);
            this.gameObject.transform.GetChild(0).gameObject.SetActive(false);
        }
    }
}
