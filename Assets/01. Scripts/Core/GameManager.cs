using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using DG.Tweening;

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

    public void LoadStartScene()
    {
        DOTween.KillAll();
        SceneManager.LoadScene("Start");
    }
}
