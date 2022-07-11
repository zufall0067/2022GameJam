using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundManager : MonoBehaviour
{
    //배경 게임 오브젝트 
    public GameObject[] backgroundGameObject;

    private void Start()
    {
        backgroundGameObject[1].transform.position = Vector2.zero;
    }

    private void Update()
    {
        
    }
}
