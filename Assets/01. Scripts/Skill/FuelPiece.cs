using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FuelPiece : MonoBehaviour
{
    private float giveFuel;
    private float speed = 3;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.down * Time.deltaTime * speed);
    }
    public void SetGiveFuel(float _givefuel)
    {
        giveFuel = _givefuel;
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.transform.CompareTag("TOWER"))
        {
            other.transform.GetComponent<Tower>().fuel += giveFuel;
            Destroy(gameObject);
        }
        else if (other.transform.CompareTag("OUTLINE"))
        {
            Destroy(gameObject);
        }
    }
}
