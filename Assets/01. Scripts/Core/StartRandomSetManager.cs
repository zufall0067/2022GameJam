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
    }

    void Update()
    {
        if (Input.GetKeyUp(KeyCode.Space))
        {
            AssetChange();
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
            StartCoroutine(MoveStructureAsset());
        }
        else if(backgroundGameObject[backgroundRandomIndex].CompareTag("WILD"))
        {
            StartCoroutine(MoveWildStructureAsset());
        }

    }

    public IEnumerator MoveStructureAsset()
    {
        while(true)
        {
            int XpositionMinus = 0;

            if (Random.Range(0, 2) == 0)
            {
                XpositionMinus = -1;
                Structure[structureRandomIndex].transform.rotation = Quaternion.Euler(0, 0, 0);
            }
            else
            {
                XpositionMinus = 1;
                Structure[structureRandomIndex].transform.rotation = Quaternion.Euler(0, 180, 0);
            }

            structureRandomIndex = Random.Range(0, 6);
            Structure[structureRandomIndex].transform.position = new Vector2(XpositionMinus * 10, Random.Range(0.3f, 4f));
            Structure[structureRandomIndex].SetActive(true);

            yield return new WaitForSeconds(Random.Range(1.5f, 4f));
        }
    }

    public IEnumerator MoveWildStructureAsset()
    {
        //Structure[7].gameObject.SetActive(true);
        //Structure[8].gameObject.SetActive(true);
        //Structure[9].gameObject.SetActive(true);
        while (true)
        {
            int XpositionMinus = 0;

            if (Random.Range(0, 2) == 0)
            {
                XpositionMinus = -1;
                Structure[structureRandomIndex].transform.rotation = Quaternion.Euler(0, 0, 0);
            }
            else
            {
                XpositionMinus = 1;
                Structure[structureRandomIndex].transform.rotation = Quaternion.Euler(0, 180, 0);
            }

            structureRandomIndex = 6;
            Structure[structureRandomIndex].transform.position = new Vector2(XpositionMinus * 10, Random.Range(0.3f, 4f));
            Instantiate(Structure[structureRandomIndex], new Vector3(XpositionMinus * 10, Random.Range(2f, 5f), 0f), Quaternion.identity);

            yield return new WaitForSeconds(Random.Range(1f, 2.5f));
        }
    }
}
