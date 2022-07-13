using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Background : MonoBehaviour
{
    private MeshRenderer _renderer;

    //��� �����̴� �ӵ�
    public float speed;
    public float offset;
    private Tower tower;
    private void Awake()
    {
        _renderer = GetComponent<MeshRenderer>();
        _renderer.sortingLayerName = "Default";
        tower = FindObjectOfType<Tower>();
        _renderer.sortingOrder = 0;
    }

    private void Update()
    {
        speed = tower.fuel / 35;
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

