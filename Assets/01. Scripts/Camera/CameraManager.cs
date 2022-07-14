using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManager : MonoBehaviour
{

    private static CameraManager instance = null;

    public static CameraManager Instance
    {
        get
        {
            if (null == instance)
            {
                return null;
            }
            return instance;
        }

    }

    void Awake()
    {
        if (null == instance)
        {
            instance = this;
        }
        else
        {
            Destroy(this.gameObject);
        }
    }
    public GameObject target;

    bool istest;

    void Start()
    {
        originPos = transform.localPosition;
        //transform.position = target.transform.position + new Vector3(0f, 2f, -1f);
    }

    void Update()
    {
        
    }

    Vector3 originPos;

    public void ShakeVoid(float _amount, float _duration)
    {
        Debug.Log("카메라 피드백");
        Shake(_amount, _duration);
    }

    public IEnumerator Shake(float _amount, float _duration)
    {
        float timer = 0;
        while (timer <= _duration)
        {
            transform.localPosition = (Vector3)Random.insideUnitCircle * _amount + originPos;

            timer += Time.deltaTime;
            yield return null;
        }

        transform.localPosition = originPos;

    }
}
