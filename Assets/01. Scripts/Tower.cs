using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
public class Tower : MonoBehaviour
{
    public float fuel = 200;

    bool isGameStart;
    public bool isSkilling;

    Vector2 mousePos;
    public Camera Camera;
    


    void Start()
    {
        
    }

    void Update()
    {
        FuelDecrease();                                                                                                     

        if (Input.GetMouseButtonDown(0) && !isSkilling)
        {
            if (SkillManager.Instance.isSkill == true) return;
            mousePos = Input.mousePosition;
            mousePos = Camera.ScreenToWorldPoint(mousePos);

            Vector2 dir = mousePos - new Vector2(0, -1); //총알 발사 위치 /*(Vector2)transform.position*/;
            dir.Normalize();

            Bullet bullet = PoolManager.Instance.Pop("Bullet") as Bullet;
            bullet.dir = dir;
            bullet.Shoot();
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
        seq.Append(transform.DOJump(new Vector3(0, 0.5f, 0), 3, 1, 0.7f)).
            Join(transform.DOMoveX(2, 0.8f)).
            Join(transform.DOLocalRotateQuaternion(Quaternion.Euler(0, 0, -150), 0.7f)).
            Insert(0.3f, transform.DOMoveY(-7, 0.5f)).SetUpdate(true);
        yield return new WaitForSecondsRealtime(2);
        Debug.Log("asd");
    }

}
