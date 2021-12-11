using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroy : MonoBehaviour
{
    private Rigidbody rb;
    private BoxCollider boxCollider;
    private bool isFirst = false;

    private bool totalDestruction = false;

    private float timer = 1f;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        boxCollider = GetComponent<BoxCollider>();
    }

    private void Update()
    {
        if (boxCollider.size != Vector3.one)
        {
            if (timer <= 0)
            {
                boxCollider.size = Vector3.one;
                timer = 1;
            }
            timer -= 1 * Time.deltaTime;
        }
        if (totalDestruction && Input.GetMouseButtonDown(0))
        {
            boxCollider.size = new Vector3(1.2f, 1.2f, 1.2f);
            rb.isKinematic = false;
        }
    }

    private void OnMouseDown()
    {
        if (!totalDestruction)
        {
            rb.isKinematic = false;
            boxCollider.size = new Vector3(.2f, 0, .2f) + boxCollider.size;
            isFirst = true;
        }        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Cube" && isFirst && !totalDestruction)
        {
            collision.gameObject.GetComponent<Rigidbody>().isKinematic = false;
            collision.gameObject.GetComponent<BoxCollider>().size = new Vector3(.2f, 0, .2f) + boxCollider.size;
        }
    }

    public void TotalDestructionModeOn()
    {
        totalDestruction = true;
    }
    public void TotalDestructionModeOff()
    {
        totalDestruction = false;
    }
}
