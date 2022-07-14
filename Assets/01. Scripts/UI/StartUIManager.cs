using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class StartUIManager : MonoBehaviour
{
    public Button SettingButton;
    public GameObject SettingPanel;

    public Button SettingQuitButton; //���� �гο��� ���ư��� ��ư

    public Button CouponButton; //���� �г� ���� ��ư
    public GameObject CouponPanel;

    public Button CouponQuitButton; //���� �г� �ݴ� ��ư

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
            case "���񿬽�":
                StartCoroutine(TextInOut("��... �� ��... �׷� �����ϳ�?"));
                break;

            case "�̰��ѻ����":
                StartCoroutine(TextInOut("��������� ���Ͻñ� �̰�������~ ������� �̰�������."));
                break;

            case "������":
                StartCoroutine(TextInOut("��Ҹ� �̳�"));
                break;

            case "���ؼ�":
                StartCoroutine(TextInOut("ŷ�����׷���Ʈ���������ʰ��޽��۳�ٰ�����"));
                break;

            case "�ɱԿ�":
                StartCoroutine(TextInOut("������ �����Ŀ� aka. ����ų��"));
                break;

            case "�ڼ���":
                StartCoroutine(TextInOut("�ð��̻���"));
                break;

            case "������":
                StartCoroutine(TextInOut("���ֿ���"));
                break;

            default:
                StartCoroutine(TextInOut("���� ���� ��ȣ�Դϴ�."));
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
