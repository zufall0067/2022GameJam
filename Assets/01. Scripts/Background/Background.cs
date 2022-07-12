using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Background : MonoBehaviour
{
    private MeshRenderer renderer;

    //��� �����̴� �ӵ�
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

