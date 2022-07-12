using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
public class Tower : MonoBehaviour
{
    public float fuel = 200;
    public float nowPower = 0;
    public float fullPower = 100;
    public float recoveryPower = 2;
    bool isGameStart;
    public bool isSkilling;

    Vector2 mousePos;
    public Camera Camera;

    public int bulletCount = 0;
    public bool isReloading = false;
    public float reloadCount = 0;
    public float overReloadCount = 1f;
    void Start()
    {

    }

    void Update()
    {
        if (nowPower > fullPower)
        {
            nowPower = fullPower;
        }

        FuelDecrease();

        if (Input.GetMouseButtonDown(0) && !isSkilling && !isReloading)
        {
            if (SkillManager.Instance.isSkill == true) return;
            mousePos = Input.mousePosition;
            mousePos = Camera.ScreenToWorldPoint(mousePos);

            Vector2 dir = mousePos - new Vector2(0, -1); //�Ѿ� �߻� ��ġ /*(Vector2)transform.position*/;
            dir.Normalize();

            Bullet bullet = PoolManager.Instance.Pop("Bullet") as Bullet;
            bullet.dir = dir;
            bullet.Shoot();
            bulletCount++;
        }

        if (bulletCount >= 10 || Input.GetKeyDown(KeyCode.R))
        {
            if (!isReloading)
            {
                Debug.Log("Reload Start");
                isReloading = true;
            }
        }

        if (isReloading)
        {
            reloadCount += Time.deltaTime;
            if (reloadCount >= overReloadCount)
            {
                Debug.Log("Reload end");
                bulletCount = 0;
                reloadCount = 0;
                isReloading = false;
            }
        }
        UIManager.Instance.fuelText.text = fuel.ToString();
    }

    private void FuelDecrease()
    {
        if (fuel < 0) return;
        fuel -= Time.deltaTime * 30f;


        if (fuel < 0) Die();
    }
    private void Fire()
    {

    }



    public void Die()
    {
        Time.timeScale = 0;
        StartCoroutine(DieDGtween());
    }

    public IEnumerator DieDGtween()
    {
        var dir = Quaternion.AngleAxis(60, Vector3.right) * Vector3.one;
        Sequence seq = DOTween.Sequence();
        seq.Append(transform.DOJump(new Vector3(0, 0.5f, 0), 1, 1, 0.7f)).
            Join(transform.DOMoveX(2, 0.8f)).
            Join(transform.DOLocalRotateQuaternion(Quaternion.Euler(0, 0, -150), 0.7f)).
            Insert(0.3f, transform.DOMoveY(-7, 0.5f)).SetUpdate(true);
        yield return new WaitForSecondsRealtime(1.5f);
        UIManager.Instance.GameOverPanel.transform.DOMoveY(1f, 1f).SetEase(Ease.InOutBack).SetUpdate(true);
        Debug.Log("asd");
    }

}
