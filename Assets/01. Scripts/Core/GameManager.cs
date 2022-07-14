using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using DG.Tweening;

public class GameManager : MonoBehaviour
{
    public float[] stageHeight;

    [SerializeField] private PoolingListSO _initList = null;
    public GameObject BlackImage;

    void Awake()
    {

        PoolManager.Instance = new PoolManager(transform);
        CreatePool();
    }


    void Update()
    {
        
    }
    void Start()
    {

        Invoke("PanelUP",1f);
    }

    public void PanelUP()
    {
        Time.timeScale = 0f;
        BlackImage.transform.DOMoveY(12, 0.5f).SetUpdate(true).OnComplete(() => { Time.timeScale = 1f; Destroy(BlackImage); });
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
