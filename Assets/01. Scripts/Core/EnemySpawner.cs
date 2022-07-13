using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class EnemySpawner : MonoBehaviour
{
    public Transform[] spawnPos;
    public Transform[] finalPos;

    public Enemy[] enemys;

    public Sprite stage1_BombEnemy = null;
    public Sprite stage1_NormalEnemy = null;
    public Sprite stage2_BombEnemy = null;
    public Sprite stage2_NormalEnemy = null;
    public Sprite stage3_BombEnemy = null;
    public Sprite stage3_NormalEnemy = null;
    public Sprite stage4_BombEnemy = null;
    public Sprite stage4_NormalEnemy = null;

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
                EnemySetting(enemy0, enemyMode);
                enemy0.transform.position = spawnPos[0].position;
                enemy0.transform.DOMoveY(-8, 7f).OnComplete(() => { PoolManager.Instance.Push(enemy0); });
                break;

            case 1:
                Enemy enemy1 = PoolManager.Instance.Pop(enemyMode) as Enemy;
                EnemySetting(enemy1, enemyMode);
                enemy1.transform.position = spawnPos[1].position;
                enemy1.transform.DOMoveY(-8, 7f).OnComplete(() => { PoolManager.Instance.Push(enemy1); });
                break;

            case 2:
                Enemy enemy2 = PoolManager.Instance.Pop(enemyMode) as Enemy;
                EnemySetting(enemy2, enemyMode);
                enemy2.transform.position = spawnPos[2].position;
                enemy2.transform.DOMoveX(11f, 7f).OnComplete(() => { PoolManager.Instance.Push(enemy2); });
                break;//���� �ڵ忡 �ѹ� ���� 
                      //���� 
                      //��¿�ؼ� (�̰� Ŀ�� �� ���ּ���) - ��ä��

            case 3:
                Enemy enemy3 = PoolManager.Instance.Pop(enemyMode) as Enemy;
                EnemySetting(enemy3, enemyMode);
                enemy3.transform.position = spawnPos[3].position;
                enemy3.transform.DOMoveX(12, 5f).SetEase(Ease.OutQuad);
                enemy3.transform.DOMoveY(10, 5f).SetEase(Ease.InQuad).OnComplete(() => { PoolManager.Instance.Push(enemy3); });
                break;

            case 4:
                Enemy enemy4 = PoolManager.Instance.Pop(enemyMode) as Enemy;
                EnemySetting(enemy4, enemyMode);
                enemy4.transform.position = spawnPos[4].position;
                enemy4.transform.DOMoveX(-12, 5f).SetEase(Ease.OutQuad);
                enemy4.transform.DOMoveY(10, 5f).SetEase(Ease.InQuad).OnComplete(() => { PoolManager.Instance.Push(enemy4); });
                break;

            default:
                break;
        }
    }

    public void EnemySetting(Enemy enemy, string mode)//���ʹ̰� �� (�����ǰ�) �ؾ�����
    {
        if (tower.height > 52500)
        {
            if (mode == "NormalEnemy")
                enemy.spriteRenderer.sprite = stage4_NormalEnemy;
            else
                enemy.spriteRenderer.sprite = stage4_BombEnemy;
            enemy.hp += 100;
        }
        else if (tower.height > 9250)
        {
            if (mode == "NormalEnemy")
                enemy.spriteRenderer.sprite = stage3_NormalEnemy;
            else
                enemy.spriteRenderer.sprite = stage3_BombEnemy;

            enemy.hp += 75;
        }
        else if (tower.height > 3750)
        {
            if (mode == "NormalEnemy")
                enemy.spriteRenderer.sprite = stage2_NormalEnemy;
            else
                enemy.spriteRenderer.sprite = stage2_BombEnemy;

            enemy.hp += 25;
        }
        else
        {
            if (mode == "NormalEnemy")
                enemy.spriteRenderer.sprite = stage1_NormalEnemy;
            else
                enemy.spriteRenderer.sprite = stage1_BombEnemy;
        }
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
