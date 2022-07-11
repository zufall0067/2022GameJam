using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class BackgroundManager : MonoBehaviour
{
    [SerializeField] // ����� �����ϴµ� �ɸ��� �ð�
    private float[] floorChangeDelay;
    //�� �迭 ũ�� �޴� ��
    private int floorCount;

    [SerializeField] //��� ���� ������Ʈ 
    private GameObject[] backgroundGameObject;
    //�� �迭 ũ�� �޴� ��
    private int backgroundGameObjectCount;

    //������ �ð�
    private float nowTime;
    //���� �����ִ� ��� ������Ʈ
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
