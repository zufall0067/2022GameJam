using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
public class Tower : MonoBehaviour
{
    public SpriteRenderer sprite;

    public Image bulletBar_Bg;
    public Image bulletBar_Icon;
    public Image bulletBar_Text;
    public Text bulletText;
    public Image fuelBar;
    public Image powerBar;

    public float fuel = 100;
    public float fullFuel = 100;
    public float nowPower = 0;
    public float fullPower = 100;
    public float recoveryPower = 2;
    public float height = 0;
    public Text heightText;
    bool isGameStart;
    public bool isSkilling;

    Vector2 mousePos;
    public Camera Camera;

    public int bulletCount = 0;
    public bool isReloading = false;
    public float reloadCount = 0;
    public float overReloadCount = 0.25f;

    void Awake()
    {
        sprite.sprite = PlayerSkillSettingManager.Instance.towerSprite;
    }

    void Start()
    {

    }

    void Update()
    {
        if (nowPower > fullPower)
        {
            nowPower = fullPower;
        }
        if (fuel > fullFuel)
        {
            fuel = fullFuel;
        }
        FuelDecrease();

        if (Input.GetMouseButtonDown(0) && !isSkilling && !isReloading)
        {
            if (SkillManager.Instance.isSkill == true) return;
            mousePos = Input.mousePosition;
            mousePos = Camera.ScreenToWorldPoint(mousePos);

            Vector2 dir = mousePos - new Vector2(0, -1); // 쏘는 포지션 //�Ѿ� �߻� ��ġ /*(Vector2)transform.position*/;
            dir.Normalize();

            Bullet bullet = PoolManager.Instance.Pop("Bullet") as Bullet;
            bullet.transform.position = new Vector2(0, -1); //얘도 쏘는 포지션으로 변경
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
        //UIManager.Instance.fuelText.text = fuel.ToString();

        SetBar(fuelBar, fuel);
        SetBar(powerBar, nowPower);
        SetBar(bulletBar_Bg, (10 - bulletCount) * 10);
        SetBar(bulletBar_Text, (10 - bulletCount) * 10);
        SetBar(bulletBar_Icon, (10 - bulletCount) * 10);
        height += Time.deltaTime * 415;
        heightText.text = ((int)height).ToString() + "m";
        bulletText.text = (10 - bulletCount).ToString();
    }

    private void SetBar(Image _image, float value)
    {
        _image.transform.localScale =
                new Vector3(_image.transform.localScale.x, value * 0.01f, _image.transform.localScale.z);
    }

    private void FuelDecrease()
    {
        if (fuel < 0) return;
        fuel -= Time.deltaTime * 20f;


        //if (fuel < 0) Die();
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
