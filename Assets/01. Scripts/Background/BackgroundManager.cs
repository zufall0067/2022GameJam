using UnityEngine;

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

    private Background background;


    private void Start()
    {
        nowTime = 0f;
        nowActiveBackgroundObject = 0;
        floorCount = floorChangeDelay.Length;
        backgroundGameObjectCount = backgroundGameObject.Length;
        Instantiate(backgroundGameObject[0], this.gameObject.transform);
        background = GetComponent<Background>();
    }

    private void Update()
    {
        nowTime += Time.deltaTime;

        Debug.Log(nowActiveBackgroundObject);
        Debug.Log(backgroundGameObjectCount);

        if (backgroundGameObjectCount != nowActiveBackgroundObject + 1)
        {
            if (nowTime > floorChangeDelay[nowActiveBackgroundObject])
            {
                nowActiveBackgroundObject++;
                nowTime = 0f;
                Instantiate(backgroundGameObject[nowActiveBackgroundObject], this.gameObject.transform);
                this.gameObject.transform.GetChild(nowActiveBackgroundObject - 1).gameObject.SetActive(false);
            }
        }
    }
}
