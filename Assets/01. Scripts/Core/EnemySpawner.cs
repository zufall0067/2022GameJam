using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class EnemySpawner : MonoBehaviour
{
    public Transform[] spawnPos;

    void Start()
    {
        InvokeRepeating("SpawnEnemy", 1.5f, 1.25f);
    }

    public void SpawnEnemy()
    {
        int randomNum = Random.Range(0, 5); // 변수화 해서 스킬 갯수만큼 만들어도 됨
        switch(randomNum)
        {
            case 0: //왼쪽 위에서 왼쪽 아래로
                Enemy enemy0 = PoolManager.Instance.Pop("NormalEnemy") as Enemy;
                EnemySetting(enemy0);
                enemy0.transform.position = spawnPos[0].position;
                enemy0.transform.DOMoveY(-8, 7f).OnComplete(() => { PoolManager.Instance.Push(enemy0); });
                break;

            case 1:
                Enemy enemy1 = PoolManager.Instance.Pop("NormalEnemy") as Enemy;
                EnemySetting(enemy1);
                enemy1.transform.position = spawnPos[1].position;
                enemy1.transform.DOMoveY(-8, 7f).OnComplete(() => { PoolManager.Instance.Push(enemy1); });
                break;

            case 2:
                Enemy enemy2 = PoolManager.Instance.Pop("NormalEnemy") as Enemy;
                EnemySetting(enemy2);
                enemy2.transform.position = spawnPos[2].position;
                enemy2.transform.DOMoveX(11f, 7f).OnComplete(() => { PoolManager.Instance.Push(enemy2); });
                break;//남의 코드에 훼방 놓기 
                      //히히 
                      //어쩔준서 (이거 커밋 꼭 해주세요) - 김채연

            case 3:
                Enemy enemy3 = PoolManager.Instance.Pop("NormalEnemy") as Enemy;
                EnemySetting(enemy3);
                enemy3.transform.position = spawnPos[3].position;
                enemy3.transform.DOMoveX(12, 5f).SetEase(Ease.OutQuad);
                enemy3.transform.DOMoveY(10, 5f).SetEase(Ease.InQuad).OnComplete(() => { PoolManager.Instance.Push(enemy3); });
                break;

            case 4:
                Enemy enemy4 = PoolManager.Instance.Pop("NormalEnemy") as Enemy;
                EnemySetting(enemy4);
                enemy4.transform.position = spawnPos[4].position;
                enemy4.transform.DOMoveX(-12, 5f).SetEase(Ease.OutQuad);
                enemy4.transform.DOMoveY(10, 5f).SetEase(Ease.InQuad).OnComplete(() => { PoolManager.Instance.Push(enemy4); });
                break;


            default:
                break;
        }
    }

    public void EnemySetting(Enemy enemy)//에너미가 팝 (스폰되고) 해야할일
    {
        enemy.gameObject.SetActive(true);
        enemy.Shooting();
    }

}
