using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FaceUp : MonoBehaviour
{
    public RotateBigCube cubeRotator;
    public bool rubik = true;
    bool dragging=false;
    private void Start()
    {
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
        if (rubik)
        {
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
        else
        {
            if ((transform.up - Vector3.left).magnitude < 0.05 && !dragging)
            {
                dragging = true;
                cubeRotator.mxRotate();
            }
            if ((transform.up - Vector3.back).magnitude < 0.05 && !dragging)
            {
                dragging = true;
                cubeRotator.mzRotate();
            }
            if ((transform.up - Vector3.down).magnitude < 0.05 && !dragging)
            {
                dragging = true;
                cubeRotator.myRotate();
            }
        }

    }

}
