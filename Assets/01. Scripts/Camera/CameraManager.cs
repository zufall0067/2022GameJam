using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManager : MonoBehaviour
{
    public GameObject target;

    bool istest;

    void Start()
    {
        transform.position = target.transform.position + new Vector3(0f, 0f, -1f);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            istest = true;
        }
        if(istest == true)
        {
            transform.position = Vector3.Lerp(transform.position, target.transform.position + new Vector3(2f, 0f, -1f), 7f );
        }
    }
}
