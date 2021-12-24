using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class foodDrop : MonoBehaviour
{
    Rigidbody rb;
    public int speed = 5;
    public bool collided = false;
    public int point;
    bool added = false;
    public int collidingPlate=0;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (!collided)
        {
            rb.velocity = new Vector3(0, -1000f, 0);
        }
        else
        {
            rb.AddForce(0, -10, 0);
        }
        if (rb.velocity.x * Input.GetAxis("Horizontal") * speed < 0)
        {
            rb.AddForce(1000 * Input.GetAxis("Horizontal") * speed, 0, 0);
        }
        if (gameObject.tag == "Food" && added)
        {
            //FoodCount.score -= point;
            added = false;
        }
        if(collidingPlate==0)
        {
            gameObject.tag = "Food";
        }

    }
    private void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.CompareTag("plate") && !added)
        {
            gameObject.tag = "plate";
            if(collision.gameObject.name!= "Plate")
            {
collision.gameObject.GetComponent<foodDrop>().collidingPlate++;
            }
            
            //FoodCount.score += point;
            added = true;
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if(!collided)
        {
            FoodCount.score += point;
        }
        collided = true;
        if(collision.gameObject.tag=="Plate")
        {
            collidingPlate++;
        }
    }
    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.tag == "Plate")
        {
            collidingPlate--;
        }
    }
    //private void OnCollisionEnter(Collision collision)
    //{
    //    collided = true;
    //    if (collision.gameObject.CompareTag("plate"))
    //    {
    //        gameObject.tag = "plate";
    //        FoodCount.score += point;
    //    }
    //}
    //private void OnCollisionExit(Collision collision)
    //{
    //        if(gameObject.tag=="plate")
    //        {
    //            FoodCount.score -= point;
    //            gameObject.tag = "Food";
    //        }
    //}
}
