using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class laser : MonoBehaviour
{
    public float defDistanceRay = 100;
    public Transform laserFirePoint;
    public LineRenderer lineRenderer;
    Transform trm;

    private void Awake()
    {
        trm = GetComponent<Transform>();
    }

    void Update()
    {
        ShootLaser();
    }

    void ShootLaser()
    {
        if(Physics2D.Raycast(trm.position, transform.right))
        {
            RaycastHit2D _hit = Physics2D.Raycast(laserFirePoint.position, transform.right);
            Draw2DRay(laserFirePoint.position, _hit.point);
        }
    }

    private void Draw2DRay(Vector2 position, Vector2 point)
    {
        Debug.Log(point);
        lineRenderer.SetPosition(0, position);
        lineRenderer.SetPosition(1, point);
    }
}
