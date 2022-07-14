using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class StartUIManager : MonoBehaviour
{
    public Button SettingButton;
    public GameObject SettingPanel;

    public Button SettingQuitButton; //세팅 패널에서 돌아가는 버튼

    public Button CouponButton; //쿠폰 패널 여는 버튼
    public GameObject CouponPanel;

    public Button CouponQuitButton; //쿠폰 패널 닫는 버튼

    public Button HighscoreButton;
    public GameObject HighscorePanel;

    public Button HightscoreQuitButton;

    public Text TopOneScore;
    public Text TopTwoScore;
    public Text TopThreeScore;

    public InputField Coupon;
    public Text CouponCheckText;
    public string CouponName;
    

    private void Start()
    {
        
    }

    public void CouponButtonPush()
    {
        CouponName = Coupon.text;

        Debug.Log(CouponName);

        switch (CouponName)
        {
            case "좀비연시":
                StartCoroutine(TextInOut("야... 너 뭔... 그런 게임하냐?"));
                break;

            case "미개한사람들":
                StartCoroutine(TextInOut("김희수님이 말하시길 미개해져라~ 사람들이 미개해졌다."));
                break;

            case "유정빈":
                StartCoroutine(TextInOut("목소리 미남"));
                break;

            case "권준서":
                StartCoroutine(TextInOut("킹갓제네럴울트라하이퍼초고교급슈퍼노바개발자"));
                break;

            case "심규영":
                StartCoroutine(TextInOut("누나들 도망쳐요 aka. 누나킬러"));
                break;

            case "박서준":
                StartCoroutine(TextInOut("씹게이새끼"));
                break;

            case "정정배":
                StartCoroutine(TextInOut("맹주영꼬"));
                break;

            default:
                StartCoroutine(TextInOut("없는 쿠폰 번호입니다."));
                break;
        }
    }

    public IEnumerator TextInOut(string text)
    {
        Debug.Log(text);

        CouponCheckText.DOText(text, 1.5f);

        yield return new WaitForSeconds(3f);

        CouponCheckText.text = " ";
    }

    public void PutSettingButton()
    {
        SettingPanel.transform.DOMoveY(0, 1f);
        SettingButton.gameObject.SetActive(false);
        HighscoreButton.gameObject.SetActive(false);
    }

    public void PutSettingQuitButton()
    {
        SettingPanel.transform.DOMoveY(10, 1f).OnComplete(() => { HighscoreButton.gameObject.SetActive(true); SettingButton.gameObject.SetActive(true); });
    }

    public void PutCouponButton()
    {
        CouponPanel.SetActive(true);
    }

    public void PutCouponQuitButton()
    {
        CouponPanel.SetActive(false);
    }

    public void PutHighscoreButton()
    {

        HighscorePanel.transform.DOMoveY(0, 1f);
        float top1, top2, top3;
        
        top1 = PlayerPrefs.GetFloat("Top1");
        top2 = PlayerPrefs.GetFloat("Top2");
        top3 = PlayerPrefs.GetFloat("Top3");

        

        TopOneScore.text = ((int)top1).ToString();
        TopTwoScore.text = ((int)top2).ToString();
        TopThreeScore.text = ((int)top3).ToString();

        SettingButton.gameObject.SetActive(false);
        HighscoreButton.gameObject.SetActive(false);
    }

    public void PutHighscoreQuitButton()
    {
        HighscorePanel.transform.DOMoveY(10, 1f).OnComplete(() => { HighscoreButton.gameObject.SetActive(true); SettingButton.gameObject.SetActive(true); });
    }

    public void CouponButtonClick()
    {
        PlayerPrefs.DeleteAll();
    }
}
