using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeStop : Skill
{
    public override void Select()
    {
        price = 2;
        isReady = true;
        SetCurrentSkill(icon, title);
        //price = 25;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
