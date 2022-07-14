using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TutorialManager : MonoBehaviour
{
    [SerializeField]
    public GameObject[] tutorialGameObject;
    public Button tutorialRightButton;
    public Button tutorialLeftButton;
    public GameObject TutorialPanel;
    public Button tutorialButton;
    public Button tutorialQuitButton;

    int i = 0;

    public void PutTutorialQuitButton()
    {
        TutorialPanel.SetActive(false);
    }

    public void PutTutorialButton()
    {
        TutorialPanel.SetActive(true);
    }

    public void PutTutorialRightButton()
    {
        ++i;
        if (i == 10)
        {
            tutorialGameObject[9].SetActive(false);
            i = 0;
        }
        else if(i >= 0)
        {
            tutorialGameObject[i - 1].SetActive(false);
        }
    }

    public void PutTutorialLeftButton()
    {
        --i;
        if (i <= 0)
        {
            i = 9;
        }
        else if (i > 0)
        {
            tutorialGameObject[i + 1].SetActive(false);
        }
    }

    void Update()
    {
        tutorialGameObject[i].gameObject.SetActive(true);
    }
}
