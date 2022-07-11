using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class BackgroundManager : MonoBehaviour
{
    [SerializeField] // ����� �����ϴµ� �ɸ��� �ð�
    private float[] floorChangeDelay;

    //������ �ð�
    private float nowTime;
    //���� �����ִ� ��� ������Ʈ
    private int nowActiveBackgroundObject;
    //��� ���� ������Ʈ 
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
