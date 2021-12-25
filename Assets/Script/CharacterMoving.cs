using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMoving : MonoBehaviour
{
    public Animator anim;
    float speed = 3f;
    float rotationSpeed = 700f;
    float gravity = 100;
    bool onGround = false;
    private Rigidbody rb;
    float distanceToGround;
    Vector3 Groundnormal;
    public CubeState cubeState;

    private void Start()
    {
        //charCon = GetComponent<CharacterController>();
        rb = GetComponent<Rigidbody>();
        rb.freezeRotation = true;
        
    }
    private void FixedUpdate()
    {
        Vector3 movement=Vector3.zero;
        if(cubeState.gameObject.GetComponent<RotateBigCube>().rubik==1)
        {
            if((transform.up-Vector3.up).magnitude<0.05)
            {
                 movement= new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
            }

            if ((transform.up- Vector3.left).magnitude < 0.05)
            {
                movement = new Vector3(0, Input.GetAxis("Vertical"), -Input.GetAxis("Horizontal"));
            }
            if ((transform.up- Vector3.back).magnitude < 0.05)
            {
                movement = new Vector3(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"), 0);
            }
        }
        else
        {
            if ((transform.up - Vector3.right).magnitude < 0.05)
            {
                movement = new Vector3(0, Input.GetAxis("Vertical"),Input.GetAxis("Horizontal"));
            }
            if ((transform.up - Vector3.forward).magnitude < 0.05)
            {
                movement = new Vector3(-Input.GetAxis("Horizontal"),Input.GetAxis("Vertical"),0);
            }
            if ((transform.up - Vector3.up).magnitude < 0.05)
            {
                movement = new Vector3(-Input.GetAxis("Horizontal"), 0, -Input.GetAxis("Vertical"));
            }
        }



        float magnitude = Mathf.Clamp01(movement.magnitude) * speed;
        movement.Normalize();
        if (cubeState.autoRotating)
        {
            movement = Vector3.zero;
        }
        if (movement != Vector3.zero)
        {
            anim.SetBool("IsRunning", true);
        }
        else
        {
            rb.velocity = Vector3.zero;
            anim.SetBool("IsRunning", false);
        }
        //charCon.SimpleMove(movement * magnitude);
        Debug.DrawRay(transform.position, transform.position + 100 * transform.forward);
        //print(movement);
        //print(Vector3.Project(movement, transform.forward));
        //if (!GetComponent<NowPosition>().isGround)
        //{
        //    movement = movement - Vector3.Project(movement, transform.forward);
        //}
        rb.MovePosition(transform.position + movement * Time.deltaTime * magnitude);
        
        if (movement != Vector3.zero)
        {
            Quaternion toRotation = Quaternion.LookRotation(movement, transform.up);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, toRotation, rotationSpeed * Time.deltaTime);
        }
    }
    //private void OnCollisionEnter(Collision collision)
    //{
    //    print(collision.gameObject.name);
    //}
}
