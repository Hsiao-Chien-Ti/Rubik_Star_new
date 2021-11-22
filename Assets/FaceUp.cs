using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FaceUp : MonoBehaviour
{
    public RotateBigCube cubeRotator;
    bool dragging=false;
    private void Start()
    {
        cubeRotator = FindObjectOfType<RotateBigCube>();
    }
    private void Update()
    {
        //print((transform.up - Vector3.right).magnitude);
        if ((transform.up - Vector3.right).magnitude < 0.05 && !dragging)
        {
            cubeRotator.xRotate();
            //transform.localRotation = new Quaternion(transform.localRotation.x, transform.localRotation.y, 0, transform.localRotation.w);
            dragging = true;
            //rotating = true;
        }
        if ((transform.up - Vector3.left).magnitude < 0.05 && !dragging)
        {
            cubeRotator.mxRotate();
            //transform.localRotation = new Quaternion(transform.localRotation.x, transform.localRotation.y, 0, transform.localRotation.w);
            dragging = true;
            //rotating = true;
        }
        if ((transform.up - Vector3.forward).magnitude < 0.05 && !dragging)
        {
            cubeRotator.zRotate();
            //transform.localRotation = new Quaternion(transform.localRotation.x, transform.localRotation.y, 0, transform.localRotation.w);
            dragging = true;
            //rotating = true;
        }
        if ((transform.up - Vector3.back).magnitude < 0.05 && !dragging)
        {
            cubeRotator.mzRotate();
            //transform.localRotation = new Quaternion(transform.localRotation.x, transform.localRotation.y, 0, transform.localRotation.w);
            dragging = true;
            //rotating = true;
        }
        if ((transform.up - Vector3.down).magnitude < 0.05 && !dragging)
        {
            cubeRotator.myRotate();
            //transform.localRotation = new Quaternion(transform.localRotation.x, transform.localRotation.y, 0, transform.localRotation.w);
            dragging = true;
            //rotating = true;
        }
        //print((transform.up - Vector3.up).magnitude);
        if (Input.GetMouseButtonDown(0))
        {
            dragging = true;
        }
        else if(Input.GetMouseButtonUp(0))
        {
            dragging = false;
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        print(collision.gameObject.name);
    }
}
