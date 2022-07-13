using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public float[] stageHeight;

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
}
