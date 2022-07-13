using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skill : MonoBehaviour
{
    protected Vector2 mousePos;
    //private Camera _camera;
    public Camera Camera;
    //{
    //    get
    //    {
    //        if(_camera == null)
    //        {
    //            _camera = Camera.main;
    //        }
    //        return _camera;
    //    }
    //}
    protected bool isReady;
    public int price = 0;
    public Tower tower;
    public Sprite icon;
    public Sprite temp;
    public string title;
    public string explain;

    public Frame currentSkill;

    public virtual void SetCurrentSkill(Sprite sprite, string text)
    {
        currentSkill.sprite.sprite = sprite;
        currentSkill.text.text = text;
    }

    //void Awake()
    //{
    //    DontDestroyOnLoad(this.gameObject);
    //}

    public virtual void Select()
    {

    }

    public bool CheckPriceOver()
    {
        if (tower.GetComponent<Tower>().nowSkillCount < price)
        {
            return false;
        }
        else
        {
            tower.GetComponent<Tower>().nowSkillCount -= price;
            return true;
        }
    }
}
