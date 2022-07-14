using UnityEngine;

public class BackgroundManager : MonoBehaviour
{
    //�� �迭 ũ�� �޴� ��
    private int floorCount;

    [SerializeField] //���?���� ������Ʈ 
    private GameObject[] backgroundGameObject;
    //�� �迭 ũ�� �޴� ��
    private int backgroundGameObjectCount;

    //������ �ð�
    private float nowTime;
    //���� �����ִ� ���?������Ʈ
    private int nowActiveBackgroundObject;

    private Background background;
    private GameManager gameManager;
    private Tower tower;
    private int idx = 0;
    private void Start()
    {
        nowTime = 0f;
        nowActiveBackgroundObject = 0;
        backgroundGameObjectCount = backgroundGameObject.Length;
        Instantiate(backgroundGameObject[0], this.gameObject.transform);
        background = GetComponent<Background>();
        gameManager = FindObjectOfType<GameManager>();
        tower = FindObjectOfType<Tower>();
    }

    private void Update()
    {
        //nowTime += Time.deltaTime;

        if (backgroundGameObjectCount != nowActiveBackgroundObject + 1)
        {
            if (tower.height >= gameManager.stageHeight[idx])
            {
                idx++;
                nowActiveBackgroundObject++;
                nowTime = 0f;
                Instantiate(backgroundGameObject[nowActiveBackgroundObject], this.gameObject.transform);
                this.gameObject.transform.GetChild(nowActiveBackgroundObject - 1).gameObject.SetActive(false);
            }
        }
    }
}
