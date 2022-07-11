using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class EnemySpawner : MonoBehaviour
{
    public Transform[] spawnPos;

    void Start()
    {
        InvokeRepeating("SpawnEnemy", 2, 5);
    }

    public void SpawnEnemy()
    {
        int randomNum = Random.Range(0, 3); // 변수화 해서 스킬 갯수만큼 만들어도 됨
        switch(randomNum)
        {
            case 0: //왼쪽 위에서 왼쪽 아래로
                Enemy enemy0 = PoolManager.Instance.Pop("NormalEnemy") as Enemy;
                enemy0.transform.position = spawnPos[0].position;
                enemy0.transform.DOMoveY(-7, 3f);
                break;

            case 1:
                Enemy enemy1 = PoolManager.Instance.Pop("NormalEnemy") as Enemy;
                enemy1.transform.position = spawnPos[1].position;
                enemy1.transform.DOMoveY(-7, 3f);
                break;

            case 2:
                Enemy enemy2 = PoolManager.Instance.Pop("NormalEnemy") as Enemy;
                enemy2.transform.position = spawnPos[2].position;
                enemy2.transform.DOMoveX(7, 4f);
                break;

            default:
                break;
        }
    }

}
