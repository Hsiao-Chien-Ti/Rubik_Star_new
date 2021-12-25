using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveDish : MonoBehaviour
{
    Vector3 movement;
    Rigidbody rb;
    float speed=10f;
    float previousVelocity=0;
    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }
    private void FixedUpdate()
    {
        //rb.AddForce(Input.GetAxis("Horizontal")*speed, 0, 0);
        rb.velocity = new Vector3(Input.GetAxis("Horizontal") * speed, 0, 0);
        //movement = new Vector3(, Input.GetAxis("Vertical"), 0);
        //float magnitude = Mathf.Clamp01(movement.magnitude) * speed;
        //movement.Normalize();
        //rb.MovePosition(transform.position + movement * Time.deltaTime * magnitude);
    }

}
