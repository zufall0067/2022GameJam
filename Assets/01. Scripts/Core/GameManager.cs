using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public float[] stageHeight;

    public float height_Stage2 = 3750;

    public float height_Stage3 = 9750;

    public float height_Stage4 = 52500;

    [SerializeField] private PoolingListSO _initList = null;

    void Awake()
    {
        PoolManager.Instance = new PoolManager(transform);
        CreatePool();
    }

    private void CreatePool()
    {
        foreach (PoolingPair pair in _initList.list)
            PoolManager.Instance.CreatePool(pair.prefab, pair.poolCnt);
    }

    public void LoadStartScene()
    {
        SceneManager.LoadScene("Start");
    }
}
