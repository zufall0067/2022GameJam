using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Background : MonoBehaviour
{
    private MeshRenderer renderer;

    public float speed;
    public float offset;

    private void Start()
    {
        renderer = GetComponent<MeshRenderer>();
    }

    private void Update()
    {
        offset += Time.deltaTime * speed;
        renderer.material.mainTextureOffset = new Vector2(0, offset);
    }
}

