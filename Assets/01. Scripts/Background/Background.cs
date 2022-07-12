using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Background : MonoBehaviour
{
    private MeshRenderer _renderer;

    //배경 움직이는 속도
    public float speed;
    public float offset;

    private void Awake()
    {
        _renderer = GetComponent<MeshRenderer>();
        _renderer.sortingLayerName = "Default";
        _renderer.sortingOrder = 0;
    }

    private void Update()
    {
        offset += Time.deltaTime * speed;
        _renderer.material.mainTextureOffset = new Vector2(0, offset);
    }
    public void OnValidate()
    {
        _renderer = GetComponent<MeshRenderer>();
        _renderer.sortingLayerName = "Default";
        _renderer.sortingOrder = 0;
    }
}

