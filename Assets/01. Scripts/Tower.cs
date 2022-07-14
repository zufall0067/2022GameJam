using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
public class Tower : MonoBehaviour
{
    public GameObject skillCountUI;
    public Text skillCountText;
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
    public float recoveryPower = 4f;
    public float height = 0;
    public Text heightText;
    bool isGameStart;
    public bool isSkilling;
    private float speed = 5f;
    Vector2 mousePos;
    public Camera Camera;

    bool isDieActionComplete;

    public int bulletCount = 0;
    public bool isReloading = false;
    public float reloadCount = 0;
    public float overReloadCount = 0.15f;

    public float TopScore1;
    public float TopScore2;
    public float TopScore3;

    public GameObject GameOverPanel;

    public Image grayPanel;


    bool isDead;

    public int nowSkillCount;
    public int fullSkillCount = 5;
    void Awake()
    {
        sprite.sprite = PlayerSkillSettingManager.Instance.towerSprite;
        skillCountText.text = nowSkillCount.ToString();
    }

    void Start()
    {
        TopScore1 = PlayerPrefs.GetFloat("Top1");
        TopScore2 = PlayerPrefs.GetFloat("Top2");
        TopScore3 = PlayerPrefs.GetFloat("Top3");
    }

    void Update()
    {

        SetFuelGrayPanel(); // 체력 ?�을???�색?�면 ?�는�?관리하???�수

        // if(Input.GetKeyDown(KeyCode.D))
        // {
        //     Die();
        // }
        if (nowPower >= fullPower)
        {
            nowPower = fullPower - nowPower;
            nowSkillCount++;
            if (nowSkillCount > fullSkillCount)
            {
                nowSkillCount = fullSkillCount;
            }
        }
        skillCountText.text = nowSkillCount.ToString();
        if (fuel > fullFuel)
        {
            fuel = fullFuel;
        }
        
        FuelDecrease();
        if (Input.GetMouseButtonDown(0) && !isSkilling && !isReloading && !isDead)
        {
            if (SkillManager.Instance.isSkill == true) return;
            mousePos = Input.mousePosition;
            mousePos = Camera.ScreenToWorldPoint(mousePos);

            Vector2 dir = mousePos - new Vector2(transform.position.x, transform.position.y - 1); // ?�는 ?��???//�Ѿ� �߻� ��ġ /*(Vector2)transform.position*/;
            dir.Normalize();

            Bullet bullet = PoolManager.Instance.Pop("Bullet") as Bullet;
            bullet.transform.position = new Vector2(transform.position.x, transform.position.y - 1); //?�도 ?�는 ?��??�으�?변�?
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
        height += Time.deltaTime * 215 * fuel / 100;
        heightText.text = ((int)height).ToString() + "m";
        bulletText.text = (10 - bulletCount).ToString();

        speed = fuel / 10f;
        if (Input.GetKey(KeyCode.W))
        {
            transform.Translate(Vector3.up * Time.deltaTime * speed);
        }
        if (Input.GetKey(KeyCode.S))
        {
            transform.Translate(Vector3.down * Time.deltaTime * speed);
        }
        if (Input.GetKey(KeyCode.A))
        {
            transform.Translate(Vector3.left * Time.deltaTime * speed);
        }
        if (Input.GetKey(KeyCode.D))
        {
            transform.Translate(Vector3.right * Time.deltaTime * speed);
        }
        Vector3 pos = Camera.main.WorldToViewportPoint(transform.position);
        if (pos.x < 0f) pos.x = 0f;
        if (pos.x > 1f) pos.x = 1f;
        if (pos.y < 0f && !isDead) pos.y = 0f;
        if (pos.y > 1f) pos.y = 1f;
        transform.position = Camera.main.ViewportToWorldPoint(pos);
    }

    private void SetFuelGrayPanel()
    {
        Color color = grayPanel.color;
        color.a = (101f / 255f) - (fuel / 255f);
        grayPanel.color = color;
    }

    private void SetBar(Image _image, float value)
    {
        _image.transform.localScale =
                new Vector3(_image.transform.localScale.x, value * 0.01f, _image.transform.localScale.z);
    }

    private void FuelDecrease()
    {
        if (fuel < 0 && !isDieActionComplete)
        {
            Die();
        }
        if (!isDieActionComplete)
        {
            fuel -= Time.deltaTime * 12.5f;
            return;
        }
        
        
        


        //if (fuel < 0) Die();
    }
    private void Fire()
    {

    }

    public void Die()
    {
        Time.timeScale = 0;
        HighScoreCheck();
        StartCoroutine(DieDGtween());
        isDieActionComplete = true;
    }

    public void HighScoreCheck()
    {
        if (height > TopScore1)
        {
            PlayerPrefs.SetFloat("Top1", height);
            PlayerPrefs.SetFloat("Top3", TopScore2);
            PlayerPrefs.SetFloat("Top2", TopScore1);
        }
        else if (height > TopScore2)
        {
            PlayerPrefs.SetFloat("Top2", height);
            PlayerPrefs.SetFloat("Top3", TopScore2);
        }
        else if (height > TopScore3)
        {
            PlayerPrefs.SetFloat("Top3", height);
        }

    }

    public IEnumerator DieDGtween()
    {
        //var dir = Quaternion.AngleAxis(60, Vector3.right) * Vector3.one;
        isDead = true;

        yield return new WaitForSecondsRealtime(1);
        Sequence seq = DOTween.Sequence();

        seq.Append(transform.DOMoveY(-10, 2f)).
            Join(transform.DORotateQuaternion(Quaternion.Euler(0, 0, -100), 2f)).SetUpdate(true);
        //seq.Join(transform.DORotateQuaternion(Quaternion.Euler(0, 0, -150), 0.4f)).
        //    Append(transform.DOMoveY(-10f, 0.8f)).SetUpdate(true);
        //Join(transform.DOMoveX(transform.position.x + 1, 0.8f)).SetUpdate(true);
        // Append(transform.DOMoveY(-10, 0.6f)).SetUpdate(true);



        //seq.Append(transform.DOJump(new Vector3(0, transform.position.y + 0.5f, 0), 1, 1, 0.7f)).
        //    Join(transform.DOMoveX(transform.position.x + 1, 0.8f)).

        //    Insert(0.3f, transform.DOMoveY(-10f, 0.5f)).SetUpdate(true);
        yield return new WaitForSecondsRealtime(0.5f);

        GameOverPanel.transform.DOMoveY(0, 0.5f).SetUpdate(true);


        Debug.Log("asd");
    }

}
