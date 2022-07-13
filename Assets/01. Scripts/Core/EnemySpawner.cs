using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class EnemySpawner : MonoBehaviour
{
    public Transform[] spawnPos;
    public Transform[] finalPos;

    public Enemy[] enemys;

    Tower tower;

    int beforeCase = 0;
    void Start()
    {
        tower = FindObjectOfType<Tower>();
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
            randomNum = Random.Range(0, 4);
            if (randomNum == beforeCase)
            { }
            else
                break;
        } // ����ȭ �ؼ� ��ų ������ŭ ���� ��
        beforeCase = randomNum;
        switch (randomNum)
        {
            case 0: //���� ������ ���� �Ʒ���
                Enemy enemy0 = PoolManager.Instance.Pop(enemyMode) as Enemy;
                EnemySetting(enemy0);
                enemy0.transform.position = spawnPos[0].position;
                enemy0.transform.DOMoveY(-8, 7f).OnComplete(() => { PoolManager.Instance.Push(enemy0); });
                break;

            case 1:
                Enemy enemy1 = PoolManager.Instance.Pop(enemyMode) as Enemy;
                EnemySetting(enemy1);
                enemy1.transform.position = spawnPos[1].position;
                enemy1.transform.DOMoveY(-8, 7f).OnComplete(() => { PoolManager.Instance.Push(enemy1); });
                break;

            case 2:
                Enemy enemy2 = PoolManager.Instance.Pop(enemyMode) as Enemy;
                EnemySetting(enemy2);
                enemy2.transform.position = spawnPos[2].position;
                enemy2.transform.DOMoveX(11f, 7f).OnComplete(() => { PoolManager.Instance.Push(enemy2); });
                break;//���� �ڵ忡 �ѹ� ���� 
                      //���� 
                      //��¿�ؼ� (�̰� Ŀ�� �� ���ּ���) - ��ä��

            case 3:
                Enemy enemy3 = PoolManager.Instance.Pop(enemyMode) as Enemy;
                EnemySetting(enemy3);
                enemy3.transform.position = spawnPos[3].position;
                enemy3.transform.DOMoveX(12, 5f).SetEase(Ease.OutQuad);
                enemy3.transform.DOMoveY(10, 5f).SetEase(Ease.InQuad).OnComplete(() => { PoolManager.Instance.Push(enemy3); });
                break;

            case 4:
                Enemy enemy4 = PoolManager.Instance.Pop(enemyMode) as Enemy;
                EnemySetting(enemy4);
                enemy4.transform.position = spawnPos[4].position;
                enemy4.transform.DOMoveX(-12, 5f).SetEase(Ease.OutQuad);
                enemy4.transform.DOMoveY(10, 5f).SetEase(Ease.InQuad).OnComplete(() => { PoolManager.Instance.Push(enemy4); });
                break;

            default:
                break;
        }
    }

    public void EnemySetting(Enemy enemy)//���ʹ̰� �� (�����ǰ�) �ؾ�����
    {
        if (tower.height > 52500)
        {
            enemy.hp += 100;
        }
        else if (tower.height > 9250)
        {
            enemy.hp += 75;
        }
        else if (tower.height > 3750)
        {
            enemy.hp += 25;
        }
        else { }
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
