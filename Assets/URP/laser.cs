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
    Vector2 mousePos;
    public Camera Camera;
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

        //RaycastHit2D _hit = Physics2D.Raycast(laserFirePoint.position, transform.right);

        if(Input.GetMouseButtonDown(0))
        {
            lineRenderer.gameObject.SetActive(true);
        }

        if(Input.GetMouseButton(0))
        {
            mousePos = Input.mousePosition;
            mousePos = Camera.ScreenToWorldPoint(mousePos);
            Vector2 dir = mousePos - (Vector2)transform.position; // /*(Vector2)transform.position*/;
            dir.Normalize();

            Draw2DRay(laserFirePoint.position, dir * 20);
        }

        if (Input.GetMouseButtonUp(0))
        {
            lineRenderer.gameObject.SetActive(false);
        }

    }

    private void Draw2DRay(Vector2 position, Vector2 point)
    {
        Debug.Log(point);
        lineRenderer.SetPosition(0, position);
        lineRenderer.SetPosition(1, point);
    }
}
