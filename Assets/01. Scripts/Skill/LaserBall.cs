using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserBall : Skill
{
    public GameObject lineRenderer;
    public Transform laserFirePoint;

    public float laserDamage;

    public override void Select()
    {
        isReady = true;
        Invoke("IsReadyfalse", 4f);
        Debug.Log("∑π¿Ã¿˙ ¿Â¬¯");
    }


    void Update()
    {
        if (isReady && Input.GetMouseButtonDown(0))
        {
            SkillManager.Instance.SkillPanelQuit();
            lineRenderer.SetActive(true);
            MeshCollider meshCollider = lineRenderer.AddComponent<MeshCollider>();
            Mesh mesh = new Mesh();
            lineRenderer.GetComponent<LineRenderer>().BakeMesh(mesh, true);
            meshCollider.sharedMesh = mesh;
        }

        if(isReady && Input.GetMouseButton(0))
        {
            mousePos = Input.mousePosition;
            mousePos = Camera.ScreenToWorldPoint(mousePos);
            //Vector2 dir = mousePos - (Vector2)transform.position; // /*(Vector2)transform.position*/;
            //dir.Normalize();

            Draw2DRay(lineRenderer.transform.position, mousePos * 80);


            //tower.isSkilling = false;
        }
        
        if(!isReady && Input.GetMouseButton(0) || Input.GetMouseButtonUp(0))
        {
            lineRenderer.SetActive(false);
        }

    }

    private void Draw2DRay(Vector2 position, Vector2 point)
    {
        lineRenderer.GetComponent<LineRenderer>().SetPosition(0,new Vector3(0,-1,0));
        lineRenderer.GetComponent<LineRenderer>().SetPosition(1, point);
    }

    private void IsReadyfalse()
    {
        isReady = false;
        tower.isSkilling = false;
    }

    void OnCollisionStay2D(Collision2D collision)
    {
        if(collision.transform.CompareTag("ENEMY"))
        {

        }
    }
}
