using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class StartRandomSetManager : MonoBehaviour
{
    public int backgroundRandomIndex = 0;
    public int towerRandomIndex = 0;
    public int structureRandomIndex = 0;

    [SerializeField]
    public GameObject[] towerGameObject;

    [SerializeField]
    public GameObject[] backgroundGameObject;

    [SerializeField]
    public GameObject[] Structure;

    void Start()
    {
        AssetChange();
        MoveTowerAsset();
    }

    void Update()
    {
        if (Input.GetKeyUp(KeyCode.Space))
        {
            AssetChange();
            MoveTowerAsset();
        }
    }

    public void AssetChange()
    {
        towerGameObject[towerRandomIndex].gameObject.SetActive(false);
        backgroundGameObject[backgroundRandomIndex].gameObject.SetActive(false);

        backgroundRandomIndex = Random.Range(0, backgroundGameObject.Length);
        towerRandomIndex = Random.Range(0, towerGameObject.Length);

        towerGameObject[towerRandomIndex].gameObject.SetActive(true);
        backgroundGameObject[backgroundRandomIndex].gameObject.SetActive(true);

        
           
            
        
        if (backgroundGameObject[backgroundRandomIndex].CompareTag("SPACE"))
        {
            Debug.Log("태그가 아노디요");
            if (towerGameObject[towerRandomIndex].gameObject.activeSelf == false)
            {
                Debug.Log("스폰이 안되요");
                int XpositionMinus = 0;

                if (Random.Range(0, 1) == 0)
                {
                    XpositionMinus = -1;
                    Structure[structureRandomIndex].transform.rotation = Quaternion.Euler(0, 0, 0);
                }
                else
                {
                    XpositionMinus = 1;
                    Structure[structureRandomIndex].transform.rotation = Quaternion.Euler(0, 180, 0);
                }

                structureRandomIndex = Random.Range(0, 5);
                Structure[structureRandomIndex].transform.position = new Vector2(XpositionMinus * 10, Random.Range(0.3f, 4f));
                Structure[structureRandomIndex].SetActive(true);
            }
        }
                
    }

    public void MoveTowerAsset()
    {
        
    }
}
