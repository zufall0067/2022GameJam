using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Background : MonoBehaviour
{
    private MeshRenderer renderer;

    //배경 움직이는 속도
    public float speed;
    public float offset;

    private void Awake()
    {
        renderer = GetComponent<MeshRenderer>();
        renderer.sortingLayerName = "BACKGROUND";
        renderer.sortingOrder = 0;
    }

    private void Update()
    {
        offset += Time.deltaTime * speed;
        renderer.material.mainTextureOffset = new Vector2(0, offset);
    }
    public void OnValidate()
    {
        renderer = GetComponent<MeshRenderer>();
        renderer.sortingLayerName = "BACKGROUND";
        renderer.sortingOrder = 0;
    }
}

