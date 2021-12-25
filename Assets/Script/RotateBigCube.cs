//code for rotating the whole cube
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateBigCube : MonoBehaviour
{
    Vector2 firstPressPos;
    Vector2 secondPressPos;
    Vector2 currentSwipe;
    Vector3 previousMousePosition;
    Vector3 mouseDelta;
    public GameObject targetCube;
    float speed = 200f;
    ReadCube readCube;
    CubeState cubeState;
    public int rubik = 1;
    // Start is called before the first frame update
    void Start()
    {
        readCube = GetComponent<ReadCube>();
        cubeState = GetComponent<CubeState>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Automate.finishAuto)
        {
            Swipe();
            Drag();
        }

    }

    //while the mouse button is held down, the cube can be moved around its central axis
    void Drag()
    {
        if(Input.GetMouseButton(1) && !cubeState.leftDragging)//check whether the mouse button is held / while the mouse button is held down, the cube can be moved around its central axis
        {
            cubeState.rightDragging = true;
            mouseDelta = Input.mousePosition - previousMousePosition;
            mouseDelta *= 0.15f;//reduction of the rotstion speed
            transform.rotation = Quaternion.Euler(mouseDelta.y*rubik, -mouseDelta.x , 0) * transform.rotation;
        }
        else //automatically move to the target position
        {
            cubeState.rightDragging = false;
            if (transform.rotation != targetCube.transform.rotation)
            {
                //move to the target position by steps
                //rotate a few steps per frame
                var step = speed * Time.deltaTime;
                transform.rotation = Quaternion.RotateTowards(transform.rotation, targetCube.transform.rotation, step);
            }
        }
        previousMousePosition = Input.mousePosition;
    }
    void Swipe()
    {
        if(Input.GetMouseButtonDown(1))//right click on the mouse
        {
            //get the position of the first mouse click
            firstPressPos = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
        }
        if(Input.GetMouseButtonUp(1))
        {
            secondPressPos = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
            currentSwipe = new Vector2(secondPressPos.x - firstPressPos.x, secondPressPos.y - firstPressPos.y);
            currentSwipe.Normalize();
            if(LeftSwipe(currentSwipe))
            {
                targetCube.transform.Rotate(0, 90, 0,Space.World);
            }
            else if(RightSwipe(currentSwipe))
            {
                targetCube.transform.Rotate(0, -90, 0,Space.World);
            }
            else if(UpLeftSwipe(currentSwipe))
            {
                targetCube.transform.Rotate(90 * rubik, 0, 0, Space.World);
            }
            else if (UpRightSwipe(currentSwipe))
            {
                targetCube.transform.Rotate(0, 0, -90 * rubik, Space.World);
            }
            else if (DownLeftSwipe(currentSwipe))
            {
                targetCube.transform.Rotate(0, 0, 90 * rubik, Space.World);
            }
            else if (DownRightSwipe(currentSwipe))
            {
                targetCube.transform.Rotate(-90 * rubik, 0, 0, Space.World);
            }
            readCube.ReadState();
        }

    }
    bool LeftSwipe(Vector2 swipe)
    {
        return currentSwipe.x < 0 && currentSwipe.y > -0.5f && currentSwipe.y < 0.5f;
    }
    bool RightSwipe(Vector2 swipe)
    {
        return currentSwipe.x > 0f && currentSwipe.y > -0.5f && currentSwipe.y < 0.5f;
    }
    bool UpLeftSwipe(Vector2 swipe)
    {
        return currentSwipe.y > 0f && currentSwipe.x < 0f;
    }
    bool UpRightSwipe(Vector2 swipe)
    {
        return currentSwipe.y > 0f && currentSwipe.x > 0f;
    }
    bool DownLeftSwipe(Vector2 swipe)
    {
        return currentSwipe.y < 0f && currentSwipe.x < 0f;
    }
    bool DownRightSwipe(Vector2 swipe)
    {
        return currentSwipe.y < 0f && currentSwipe.x > 0f;
    }
    public void xRotate()
    {
        targetCube.transform.Rotate(0, 0, 90, Space.World);
    }
    public void mxRotate()
    {
        targetCube.transform.Rotate(0, 0, 270, Space.World);
    }
    public void zRotate()
    {
        targetCube.transform.Rotate(-90, 0, 0, Space.World);
    }
    public void mzRotate()
    {
        targetCube.transform.Rotate(-270, 0, 0, Space.World);
    }
    public void myRotate()
    {
        targetCube.transform.Rotate(-180, 0, 0, Space.World);
    }
    public bool RotateToTrail()
    {
        GameObject trailDir = GameObject.Find("TrailDirection");
        targetCube.transform.rotation = Quaternion.RotateTowards(targetCube.transform.rotation,trailDir.transform.rotation,5f);
        //print(Quaternion.Angle(targetCube.transform.rotation, trailDir.transform.rotation));
        return Quaternion.Angle(targetCube.transform.rotation, trailDir.transform.rotation) <= 1;
    }

}
