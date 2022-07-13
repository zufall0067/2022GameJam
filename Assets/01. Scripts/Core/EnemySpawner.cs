using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class EnemySpawner : MonoBehaviour
{
    public Transform[] spawnPos;
    //public Transform[] finalPos;

    public Enemy[] enemys;

    int beforeCase = 0;
    void Start()
    {
        InvokeRepeating("SpawnNormalEnemy", 1f, 1.6f);
        InvokeRepeating("SpawnBombEnemy", 2f, 2.3f);
    }

    public void SpawnNormalEnemy()
    {
        SpawnEnemy("NormalEnemy");
    }
    public void SpawnBombEnemy()
    {
        SpawnEnemy("BombEnemy");
    }

    public void SpawnEnemy(string enemyMode)
    {
        int randomNum = 100;
        while (true)
        {
            randomNum = Random.Range(0,5);
            if (randomNum == beforeCase)
            {
                
            }
            else
                break;
        } // ����ȭ �ؼ� ��ų ������ŭ ���� ��
        beforeCase = randomNum;
        Debug.Log(randomNum);
        switch (randomNum)
        {
            case 0: //���� ������ ���� �Ʒ���
                Enemy enemy0 = PoolManager.Instance.Pop(enemyMode) as Enemy;
                EnemySetting(enemy0);
                Debug.Log("에너미 세팅 완료");
                enemy0.Moving(spawnPos[0], Vector2.right);
                //enemy0.transform.position = spawnPos[0].position;
                //enemy0.transform.DOMoveY(-8, 7f).OnComplete(() => { PoolManager.Instance.Push(enemy0); });
                break;

            case 1:
                Enemy enemy1 = PoolManager.Instance.Pop(enemyMode) as Enemy;
                EnemySetting(enemy1);
                enemy1.Moving(spawnPos[1], -Vector2.right);
                //enemy1.transform.position = spawnPos[1].position;
                //enemy1.transform.DOMoveY(-8, 7f).OnComplete(() => { PoolManager.Instance.Push(enemy1); });
                break;

            case 2:
                Enemy enemy2 = PoolManager.Instance.Pop(enemyMode) as Enemy;
                EnemySetting(enemy2);
                enemy2.Moving(spawnPos[2], -Vector2.up);
                //enemy2.transform.position = spawnPos[2].position;
                //enemy2.transform.DOMoveX(11f, 7f).OnComplete(() => { PoolManager.Instance.Push(enemy2); });
                break;//���� �ڵ忡 �ѹ� ���� 
                      //���� 
                      //��¿�ؼ� (�̰� Ŀ�� �� ���ּ���) - ��ä��

            case 3:
                Enemy enemy3 = PoolManager.Instance.Pop(enemyMode) as Enemy;
                EnemySetting(enemy3);
                enemy3.Moving(spawnPos[3], -Vector2.up);
                //enemy3.transform.DOMoveX(12, 5f).SetEase(Ease.OutQuad);
                //enemy3.transform.DOMoveY(10, 5f).SetEase(Ease.InQuad).OnComplete(() => { PoolManager.Instance.Push(enemy3); });
                break;

            case 4:
                Enemy enemy4 = PoolManager.Instance.Pop(enemyMode) as Enemy;
                EnemySetting(enemy4);
                enemy4.Moving(spawnPos[4], Vector2.up);
                //enemy4.transform.DOMoveX(-12, 5f).SetEase(Ease.OutQuad);
                //enemy4.transform.DOMoveY(10, 5f).SetEase(Ease.InQuad).OnComplete(() => { PoolManager.Instance.Push(enemy4); });
                break;

            case 5:
                Enemy enemy5 = PoolManager.Instance.Pop(enemyMode) as Enemy;
                EnemySetting(enemy5);
                enemy5.Moving(spawnPos[5], Vector2.up);
                //enemy4.transform.DOMoveX(-12, 5f).SetEase(Ease.OutQuad);
                //enemy4.transform.DOMoveY(10, 5f).SetEase(Ease.InQuad).OnComplete(() => { PoolManager.Instance.Push(enemy4); });
                break;

            default:
                break;
        }
    }

    void Update()
    {
        
    }

    public void EnemySetting(Enemy enemy)//���ʹ̰� �� (�����ǰ�) �ؾ�����
    {
        enemy.gameObject.SetActive(true);
        enemy.Shooting();
    }
    // public Enemy GetRandomEnemy()
    // {
    //     int random = Random.Range(0, enemys.Length);
    //     Enemy enemy;
    //     switch (random)
    //     {
    //         case 0:
    //         case 1:
    //         case 2:
    //         case 3:
    //         case 4:
    //         case 5:
    //             enemy = PoolManager.Instance.Pop("NormalEnemy") as Enemy;
    //             break;

    //         case 6:
    //             enemy = PoolManager.Instance.Pop("BombEnemy") as Enemy;
    //             break;

    //         default:
    //             enemy = null;
    //             break;
    //     }
    //     return enemy;
    // }
}
