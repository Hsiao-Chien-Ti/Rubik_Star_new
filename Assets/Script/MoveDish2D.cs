using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveDish2D : MonoBehaviour
{
    Rigidbody2D rb;
    public int speed;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        rb.velocity = new Vector3(Input.GetAxis("Horizontal")*speed,0,0);
    }
}
