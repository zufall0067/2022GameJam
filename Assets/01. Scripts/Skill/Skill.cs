using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skill : MonoBehaviour
{
    protected Vector2 mousePos;
    public Camera Camera;
    protected bool isReady;
    public int price = 0;
    public Tower tower;
    public string title;
    public Sprite icon;
    public string explain;

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
