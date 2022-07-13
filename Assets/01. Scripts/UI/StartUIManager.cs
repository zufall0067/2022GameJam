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

    public Button couponButton; //쿠폰 패널 여는 버튼
    public GameObject couponPanel;

    public Button couponQuitButton; //쿠폰 패널 닫는 버튼

    public Button HighscoreButton;
    public GameObject HighscorePanel;

    public Button HightscoreQuitButton;

    public Text TopOneScore;
    public Text TopTwoScore;
    public Text TopThreeScore;

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
        couponPanel.SetActive(true);
    }

    public void PutCouponQuitButton()
    {
        couponPanel.SetActive(false);
    }

    public void PutHighscoreButton()
    {
        HighscorePanel.transform.DOMoveY(0, 1f);
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
