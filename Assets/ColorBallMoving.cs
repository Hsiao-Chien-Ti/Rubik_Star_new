using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorBallMoving : MonoBehaviour
{
    Rigidbody rb;
    public Vector3 vel;
    // Start is called before the first frame update
    private void OnEnable()
    {
        rb = GetComponent<Rigidbody>();
        rb.velocity = vel;
    }


    // Update is called once per frame
    void Update()
    {
        rb.AddRelativeForce(0,0, -10);
    }
}
