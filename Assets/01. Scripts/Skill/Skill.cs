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
    public string title;
    public string explain;


    //void Awake()
    //{
    //    DontDestroyOnLoad(this.gameObject);
    //}

    public virtual void Select()
    {

    }

    public bool CheckPriceOver()
    {
        if (tower.GetComponent<Tower>().nowPower < price)
        {
            return false;
        }
        else
        {
            tower.GetComponent<Tower>().nowPower -= price;
            return true;
        }
    }
}
