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
        price = 2;
        CancelInvoke("IsReadyfalse");
        isReady = true;
        SetCurrentSkill(icon, title);
        Invoke("IsReadyfalse", 5f);
    }


    void Update()
    {
        if (isReady && Input.GetMouseButtonDown(0))
        {
            SkillManager.Instance.SkillPanelQuit();
            lineRenderer.SetActive(true);
            CameraManager.Instance.isLaser = true;
        }

        if (isReady && Input.GetMouseButton(0))
        {
            mousePos = Input.mousePosition;
            mousePos = Camera.ScreenToWorldPoint(mousePos);
            Vector2 dir = mousePos - new Vector2(0, -1); //*(Vector2)transform.position*/;
            dir.Normalize();

            //Vector2 dir = mousePos - (Vector2)transform.position; // /*(Vector2)transform.position*/;
            //dir.Normalize();

            Draw2DRay(tower.transform.position, dir * 80);

            RaycastHit2D[] hits = Physics2D.RaycastAll(tower.transform.position, dir, 30);
            Debug.DrawRay(tower.transform.position, dir * 30, Color.red);
            //Debug.Log(hit.collider);
            for (int i = 0; i < hits.Length; i++)
            {
                RaycastHit2D hit = hits[i];
                if (hit.collider.transform.CompareTag("ENEMY"))
                {
                    //if(hit.collider.GetComponent<Enemy>().isHitted == false)
                    //{
                    //    hit.collider.GetComponent<Enemy>().isHitted = true;
                    //}
                    
                    Debug.Log("레이저 스크립트 에너미 레이캐스트 함");
                    Debug.Log(hit.collider.GetComponent<Enemy>().hp);
                    hit.collider.GetComponent<Enemy>().hp -= 1f;
                }
            }
            //tower.isSkilling = false;
        }

        if (!isReady && Input.GetMouseButton(0) || Input.GetMouseButtonUp(0))
        {
            CameraManager.Instance.isLaser = false;
            lineRenderer.SetActive(false);
        }

    }

    private void Draw2DRay(Vector2 position, Vector2 point)
    {
        lineRenderer.GetComponent<LineRenderer>().SetPosition(0, position);
        lineRenderer.GetComponent<LineRenderer>().SetPosition(1, point);
    }

    private void IsReadyfalse()
    {
        SetCurrentSkill(temp, " ");
        isReady = false;
        tower.isSkilling = false;
    }

    void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.transform.CompareTag("ENEMY"))
        {

        }
    }
}
