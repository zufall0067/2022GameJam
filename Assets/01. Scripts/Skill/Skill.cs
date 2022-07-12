using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skill : MonoBehaviour
{
    protected Vector2 mousePos;
    public Camera Camera;
    protected bool isReady;

    public Tower tower;

    public virtual void Select()
    {
       
    }
}
