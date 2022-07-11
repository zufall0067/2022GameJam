using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour
{
    public float fuel;

    bool isGameStart;
    
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            isGameStart = true;
        }
        if(isGameStart)
        {
            GameStart();
        }
    }

    private void GameStart()
    {
        transform.position += new Vector3(0.1f, 0f, 0);
    }
}
