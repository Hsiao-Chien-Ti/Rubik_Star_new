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
        if (Input.GetMouseButtonDown(0)||Input.GetMouseButtonDown(1))
        {
            dragging = true;
        }
        else if(Input.GetMouseButtonUp(0)||Input.GetMouseButtonUp(1))
        {
            dragging = false;
        }
        if ((transform.up - Vector3.right).magnitude < 0.05 && !dragging)
        {
            dragging = true;
            cubeRotator.xRotate();
        }
        if ((transform.up - Vector3.forward).magnitude < 0.05 && !dragging)
        {
            dragging = true;
            cubeRotator.zRotate();
        }
        if ((transform.up - Vector3.down).magnitude < 0.05 && !dragging)
        {
            dragging = true;
            cubeRotator.myRotate();
        }
    }

}
