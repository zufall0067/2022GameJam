using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserBall : Skill
{
    public LineRenderer lineRenderer;
    public Transform laserFirePoint;

    public override void Select()
    {
        isReady = true;
        Invoke("IsReadyfalse", 4f);
        Debug.Log("������ ����");
    }


    void Update()
    {
        if (isReady && Input.GetMouseButtonDown(0))
        {
            lineRenderer.gameObject.SetActive(true);
        }

        if(isReady && Input.GetMouseButton(0))
        {
            mousePos = Input.mousePosition;
            mousePos = Camera.ScreenToWorldPoint(mousePos);
            Vector2 dir = mousePos - (Vector2)transform.position; // /*(Vector2)transform.position*/;
            dir.Normalize();

            Draw2DRay(laserFirePoint.position, dir * 20);
            //tower.isSkilling = false;
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

    private void IsReadyfalse()
    {
        isReady = false;
        tower.isSkilling = false;
    }
}
