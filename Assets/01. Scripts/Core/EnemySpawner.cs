using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class EnemySpawner : MonoBehaviour
{
    public Transform[] spawnPos;
    //public Transform[] finalPos;

    public Enemy[] enemys;

    public Sprite stage1_BombEnemy = null;
    public Sprite stage1_NormalEnemy = null;
    public Sprite stage2_BombEnemy = null;
    public Sprite stage2_NormalEnemy = null;
    public Sprite stage3_BombEnemy = null;
    public Sprite stage3_NormalEnemy = null;
    public Sprite stage4_BombEnemy = null;
    public Sprite stage4_NormalEnemy = null;

    private Tower tower;
    public GameManager gameManager;

    int beforeCase = 0;
    void Start()
    {
        tower = FindObjectOfType<Tower>();
        gameManager = FindObjectOfType<GameManager>();
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
        int randomNum = 0;
        while (true)
        {
            randomNum = Random.Range(0, 5);
            if (randomNum == beforeCase)
            {

            }
            else
                break;
        } // ����ȭ �ؼ� ��ų ������ŭ ���� ��
        beforeCase = randomNum;
        switch (randomNum)
        {
            case 0: //���� ������ ���� �Ʒ���
                Enemy enemy0 = PoolManager.Instance.Pop(enemyMode) as Enemy;

                EnemySetting(enemy0, enemyMode);
                enemy0.transform.rotation = Quaternion.Euler(0, 180, 0);
                enemy0.Moving(spawnPos[0], Vector2.right);
                //enemy0.transform.position = spawnPos[0].position;
                //enemy0.transform.DOMoveY(-8, 7f).OnComplete(() => { PoolManager.Instance.Push(enemy0); });


                break;

            case 1:
                Enemy enemy1 = PoolManager.Instance.Pop(enemyMode) as Enemy;

                //enemy1.transform.position = spawnPos[1].position;
                //enemy1.transform.DOMoveY(-8, 7f).OnComplete(() => { PoolManager.Instance.Push(enemy1); });
                EnemySetting(enemy1, enemyMode);
                enemy1.transform.rotation = Quaternion.Euler(0, 0, 0);
                enemy1.Moving(spawnPos[1], -Vector2.right);
                break;

            case 2:
                Enemy enemy2 = PoolManager.Instance.Pop(enemyMode) as Enemy;


                //enemy2.transform.position = spawnPos[2].position;
                //enemy2.transform.DOMoveX(11f, 7f).OnComplete(() => { PoolManager.Instance.Push(enemy2); });

                EnemySetting(enemy2, enemyMode);
                enemy2.transform.rotation = Quaternion.Euler(0, 180, 0);
                enemy2.Moving(spawnPos[2], -Vector2.up);

                break;//���� �ڵ忡 �ѹ� ���� 
                      //���� 
                      //��¿�ؼ� (�̰� Ŀ�� �� ���ּ���) - ��ä��

            case 3:
                Enemy enemy3 = PoolManager.Instance.Pop(enemyMode) as Enemy;

                EnemySetting(enemy3, enemyMode);
                enemy3.transform.rotation = Quaternion.Euler(0, 0, 0);
                enemy3.Moving(spawnPos[3], -Vector2.up);
                //enemy3.transform.DOMoveX(12, 5f).SetEase(Ease.OutQuad);
                //enemy3.transform.DOMoveY(10, 5f).SetEase(Ease.InQuad).OnComplete(() => { PoolManager.Instance.Push(enemy3); });
                break;

            case 4:
                Enemy enemy4 = PoolManager.Instance.Pop(enemyMode) as Enemy;
                enemy4.transform.rotation = Quaternion.Euler(0, 180, 0);
                EnemySetting(enemy4, enemyMode);
                enemy4.Moving(spawnPos[4], Vector2.up);
                //enemy4.transform.DOMoveX(-12, 5f).SetEase(Ease.OutQuad);
                //enemy4.transform.DOMoveY(10, 5f).SetEase(Ease.InQuad).OnComplete(() => { PoolManager.Instance.Push(enemy4); });
                break;

            case 5:
                Enemy enemy5 = PoolManager.Instance.Pop(enemyMode) as Enemy;
                EnemySetting(enemy5, enemyMode);
                enemy5.transform.rotation = Quaternion.Euler(0, 0, 0);
                enemy5.Moving(spawnPos[5], Vector2.up);
                //enemy4.transform.DOMoveX(-12, 5f).SetEase(Ease.OutQuad);
                //enemy4.transform.DOMoveY(10, 5f).SetEase(Ease.InQuad).OnComplete(() => { PoolManager.Instance.Push(enemy4); });
                break;

            default:
                break;
        }
    }

    public void EnemySetting(Enemy enemy, string mode)//���ʹ̰� �� (�����ǰ�) �ؾ�����
    {
        if (tower.height > gameManager.stageHeight[3])
        {
            if (mode == "NormalEnemy")
                enemy.spriteRenderer.sprite = stage4_NormalEnemy;
            else
                enemy.spriteRenderer.sprite = stage4_BombEnemy;
            enemy.fullhp += 175;
            enemy.hp = enemy.fullhp;
        }
        else
        if (tower.height > gameManager.stageHeight[2])
        {
            if (mode == "NormalEnemy")
                enemy.spriteRenderer.sprite = stage4_NormalEnemy;
            else
                enemy.spriteRenderer.sprite = stage4_BombEnemy;
            enemy.fullhp += 150;
            enemy.hp = enemy.fullhp;
        }
        else if (tower.height > gameManager.stageHeight[1])
        {
            if (mode == "NormalEnemy")
                enemy.spriteRenderer.sprite = stage3_NormalEnemy;
            else
                enemy.spriteRenderer.sprite = stage3_BombEnemy;

            enemy.fullhp += 125;
            enemy.hp = enemy.fullhp;
        }
        else if (tower.height > gameManager.stageHeight[0])
        {
            if (mode == "NormalEnemy")
                enemy.spriteRenderer.sprite = stage2_NormalEnemy;
            else
                enemy.spriteRenderer.sprite = stage2_BombEnemy;

            enemy.fullhp += 50;
            enemy.hp = enemy.fullhp;
        }
        else
        {
            if (mode == "NormalEnemy")
                enemy.spriteRenderer.sprite = stage1_NormalEnemy;
            else
                enemy.spriteRenderer.sprite = stage1_BombEnemy;
            enemy.hp = enemy.fullhp;
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
