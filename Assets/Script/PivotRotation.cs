using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PivotRotation : MonoBehaviour
{
    private List<GameObject> activeSide;
    private Vector3 localForward;
    private Vector3 mouseRef;
    private bool dragging=false;
    private ReadCube readCube;
    private CubeState cubeState;
    private float sensitivity = 0.4f;
    private float speed = 300f;
    private Vector3 rotation;
    private bool autoRotating = false;
    private Quaternion targetQuaternion;
    private GameObject face;
    private bool dirfix = false;
    public GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        readCube = FindObjectOfType<ReadCube>();
        cubeState = FindObjectOfType<CubeState>();
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void LateUpdate()
    {
        //print(dirfix);
        if(dragging&&!autoRotating)
        {
            CubeState.autoRotating = true;
            player.GetComponent<BoxCollider>().enabled = false;
            SpinSide();
            if(Input.GetMouseButtonUp(0))//not dragging anymore
            {
                player.GetComponent<BoxCollider>().enabled = true;
                dragging = false;
                dirfix=false;
                RotateToRightAngle();//fix the rotation angle
            }
        }
        if(autoRotating)
        {
            CubeState.autoRotating = true;
            AutoRotate();
        }
    }
    private void SpinSide()
    {
        //reset the rotation
        rotation = Vector3.zero;
        //看滑鼠移動多少來決定要轉多少
        Vector3 mouseOffset = (Input.mousePosition - mouseRef);
        //List<GameObject> side=new List<GameObject>();
        if (cubeState.back.Contains(face))//click back side
        {            
            for (int i = 0; i < 9; i++)
            {
                if (face == cubeState.back[i])
                {
                    if(i==4)
                    {
                        cubeState.PickUp(cubeState.back);
                        activeSide = cubeState.back;
                    }
                    if (i == 5)
                    {
                        cubeState.PickUp(cubeState.left);
                        activeSide = cubeState.left;
                    }
                    if (i == 7)
                    {
                        cubeState.PickUp(cubeState.down);
                        activeSide = cubeState.down;
                    }
                    if (i == 3)
                    {
                        cubeState.PickUp(cubeState.right);
                        activeSide = cubeState.right;
                    }
                    if (i == 1)
                    {
                        cubeState.PickUp(cubeState.up);
                        activeSide = cubeState.up;
                    }
                    if (i==0)
                    {
                        if (Mathf.Abs(mouseOffset.x) > Mathf.Abs(mouseOffset.y) && !dirfix)
                        {
                            cubeState.PickUp(cubeState.up);
                            activeSide = cubeState.up;
                            dirfix = true;
                        }
                        else if (Mathf.Abs(mouseOffset.x) < Mathf.Abs(mouseOffset.y) && !dirfix)
                        {
                            cubeState.PickUp(cubeState.right);
                            activeSide = cubeState.right;
                            dirfix = true;
                        }
                    }
                    if (i == 2)
                    {
                        if (Mathf.Abs(mouseOffset.x) > Mathf.Abs(mouseOffset.y) && !dirfix)
                        {
                            cubeState.PickUp(cubeState.up);
                            activeSide = cubeState.up;
                            dirfix = true;
                        }
                        else if (Mathf.Abs(mouseOffset.x) < Mathf.Abs(mouseOffset.y) && !dirfix)
                        {
                            cubeState.PickUp(cubeState.left);
                            activeSide = cubeState.left;
                            dirfix = true;
                        }
                    }
                    if(i==6)
                    {
                        if (Mathf.Abs(mouseOffset.x) > Mathf.Abs(mouseOffset.y) && !dirfix)
                        {
                            cubeState.PickUp(cubeState.down);
                            activeSide = cubeState.down;
                            dirfix = true;
                        }
                        else if (Mathf.Abs(mouseOffset.x) < Mathf.Abs(mouseOffset.y) && !dirfix)
                        {
                            cubeState.PickUp(cubeState.right);
                            activeSide = cubeState.right;
                            dirfix = true;
                        }
                    }
                    if (i == 8)
                    {
                        if (Mathf.Abs(mouseOffset.x) > Mathf.Abs(mouseOffset.y) && !dirfix)
                        {
                            cubeState.PickUp(cubeState.down);
                            activeSide = cubeState.down;
                            dirfix = true;
                        }
                        else if (Mathf.Abs(mouseOffset.x) < Mathf.Abs(mouseOffset.y) && !dirfix)
                        {
                            cubeState.PickUp(cubeState.left);
                            activeSide = cubeState.left;
                            dirfix = true;
                        }
                    }
                }
            }
        }
        if (cubeState.left.Contains(face))//click back side
        {
            for (int i = 0; i < 9; i++)
            {
                if (face == cubeState.left[i])
                {
                    if (i == 4)
                    {
                        cubeState.PickUp(cubeState.left);
                        activeSide = cubeState.left;
                    }
                    if (i == 5)
                    {
                        cubeState.PickUp(cubeState.front);
                        activeSide = cubeState.front;
                    }
                    if (i == 7)
                    {
                        cubeState.PickUp(cubeState.down);
                        activeSide = cubeState.down;
                    }
                    if (i == 3)
                    {
                        cubeState.PickUp(cubeState.back);
                        activeSide = cubeState.back;
                    }
                    if (i == 1)
                    {
                        cubeState.PickUp(cubeState.up);
                        activeSide = cubeState.up;
                    }
                    if (i == 0)
                    {
                        if (Mathf.Abs(mouseOffset.x) > Mathf.Abs(mouseOffset.y) && !dirfix)
                        {
                            cubeState.PickUp(cubeState.up);
                            activeSide = cubeState.up;
                            dirfix = true;
                        }
                        else if (Mathf.Abs(mouseOffset.x) < Mathf.Abs(mouseOffset.y) && !dirfix)
                        {
                            cubeState.PickUp(cubeState.back);
                            activeSide = cubeState.back;
                            dirfix = true;
                        }
                    }
                    if (i == 2)
                    {
                        if (Mathf.Abs(mouseOffset.x) > Mathf.Abs(mouseOffset.y) && !dirfix)
                        {
                            cubeState.PickUp(cubeState.up);
                            activeSide = cubeState.up;
                            dirfix = true;
                        }
                        else if (Mathf.Abs(mouseOffset.x) < Mathf.Abs(mouseOffset.y) && !dirfix)
                        {
                            cubeState.PickUp(cubeState.front);
                            activeSide = cubeState.front;
                            dirfix = true;
                        }
                    }
                    if (i == 6)
                    {
                        if (Mathf.Abs(mouseOffset.x) > Mathf.Abs(mouseOffset.y) && !dirfix)
                        {
                            cubeState.PickUp(cubeState.down);
                            activeSide = cubeState.down;
                            dirfix = true;
                        }
                        else if (Mathf.Abs(mouseOffset.x) < Mathf.Abs(mouseOffset.y) && !dirfix)
                        {
                            cubeState.PickUp(cubeState.back);
                            activeSide = cubeState.back;
                            dirfix = true;
                        }
                    }
                    if (i == 8)
                    {
                        if (Mathf.Abs(mouseOffset.x) > Mathf.Abs(mouseOffset.y) && !dirfix)
                        {
                            cubeState.PickUp(cubeState.down);
                            activeSide = cubeState.down;
                            dirfix = true;
                        }
                        else if (Mathf.Abs(mouseOffset.x) < Mathf.Abs(mouseOffset.y) && !dirfix)
                        {
                            cubeState.PickUp(cubeState.front);
                            activeSide = cubeState.front;
                            dirfix = true;
                        }
                    }
                }
            }
        }

        if (cubeState.up.Contains(face))//click back side
        {
            for (int i = 0; i < 9; i++)
            {
                if (face == cubeState.up[i])
                {
                    if (i == 4)
                    {
                        cubeState.PickUp(cubeState.up);
                        activeSide = cubeState.up;
                    }
                    if (i == 5)
                    {
                        cubeState.PickUp(cubeState.left);
                        activeSide = cubeState.left;
                    }
                    if (i == 7)
                    {
                        cubeState.PickUp(cubeState.back);
                        activeSide = cubeState.back;
                    }
                    if (i == 3)
                    {
                        cubeState.PickUp(cubeState.right);
                        activeSide = cubeState.right;
                    }
                    if (i == 1)
                    {
                        cubeState.PickUp(cubeState.front);
                        activeSide = cubeState.front;
                    }
                    if (i == 0)
                    {
                        if (Mathf.Abs(mouseOffset.x) > Mathf.Abs(mouseOffset.y) && !dirfix)
                        {
                            cubeState.PickUp(cubeState.front);
                            activeSide = cubeState.front;
                            dirfix = true;
                        }
                        else if (Mathf.Abs(mouseOffset.x) < Mathf.Abs(mouseOffset.y) && !dirfix)
                        {
                            cubeState.PickUp(cubeState.right);
                            activeSide = cubeState.right;
                            dirfix = true;
                        }
                    }
                    if (i == 2)
                    {
                        if (Mathf.Abs(mouseOffset.x) > Mathf.Abs(mouseOffset.y) && !dirfix)
                        {
                            cubeState.PickUp(cubeState.front);
                            activeSide = cubeState.front;
                            dirfix = true;
                        }
                        else if (Mathf.Abs(mouseOffset.x) < Mathf.Abs(mouseOffset.y) && !dirfix)
                        {
                            cubeState.PickUp(cubeState.left);
                            activeSide = cubeState.left;
                            dirfix = true;
                        }
                    }
                    if (i == 6)
                    {
                        if (Mathf.Abs(mouseOffset.x) > Mathf.Abs(mouseOffset.y) && !dirfix)
                        {
                            cubeState.PickUp(cubeState.back);
                            activeSide = cubeState.back;
                            dirfix = true;
                        }
                        else if (Mathf.Abs(mouseOffset.x) < Mathf.Abs(mouseOffset.y) && !dirfix)
                        {
                            cubeState.PickUp(cubeState.right);
                            activeSide = cubeState.right;
                            dirfix = true;
                        }
                    }
                    if (i == 8)
                    {
                        if (Mathf.Abs(mouseOffset.x) > Mathf.Abs(mouseOffset.y) && !dirfix)
                        {
                            cubeState.PickUp(cubeState.back);
                            activeSide = cubeState.back;
                            dirfix = true;
                        }
                        else if (Mathf.Abs(mouseOffset.x) < Mathf.Abs(mouseOffset.y) && !dirfix)
                        {
                            cubeState.PickUp(cubeState.left);
                            activeSide = cubeState.left;
                            dirfix = true;
                        }
                    }
                }
            }
        }

        if (activeSide == cubeState.front)
        {
            rotation.x = (mouseOffset.x + mouseOffset.y) * sensitivity;
            if(cubeState.up.Contains(face))
            {
                rotation.x *= -1;
            }
        }
        if (activeSide == cubeState.back)
        {
            rotation.x = (mouseOffset.x + mouseOffset.y) * sensitivity;
            if (cubeState.up.Contains(face))
            {
                rotation.x *= -1;
            }
        }
        if (activeSide == cubeState.up)
        {
            rotation.y = (mouseOffset.x + mouseOffset.y) * sensitivity*-1;
        }
        if (activeSide == cubeState.down)
        {
            rotation.y = (mouseOffset.x + mouseOffset.y) * sensitivity*-1;
        }
        if (activeSide == cubeState.left)
        {
            rotation.z = (mouseOffset.x + mouseOffset.y) * sensitivity*-1 ;
        }
        if (activeSide == cubeState.right)
        {
            rotation.z = (mouseOffset.x + mouseOffset.y) * sensitivity *-1;
        }


        //rotate
        transform.parent.transform.Rotate(rotation, Space.World);
        //store mouse position for next rotation
        mouseRef = Input.mousePosition;
    }
    public void Rotate(GameObject clickedFace)
    {
        //activeSide = side;
        face = clickedFace;
        mouseRef = Input.mousePosition;
        dragging = true;
        //create a vector to rotate around
        //localForward = Vector3.zero - face.transform.parent.transform.localPosition;
    }

    //避免轉一半的狀況發生
    public void RotateToRightAngle()
    {
        Vector3 vec = transform.parent.transform.localEulerAngles;
        //round vec to the nearest 90 degrees
        //轉一半的話強迫他轉到最靠近的90度
        vec.x = Mathf.Round(vec.x / 90) * 90;
        vec.y = Mathf.Round(vec.y / 90) * 90;
        vec.z = Mathf.Round(vec.z / 90) * 90;
        targetQuaternion.eulerAngles = vec;
        autoRotating = true;
    }
    public void StartAutoRotate(List<GameObject> side,float angle)
    {
        cubeState.PickUp(side);
        Vector3 localForward = Vector3.zero - side[4].transform.parent.transform.localPosition;
        targetQuaternion = Quaternion.AngleAxis(angle, localForward)*transform.parent.transform.localRotation;
        activeSide = side;
        autoRotating = true;
    }
    private void AutoRotate()
    {
        dragging = false;//避免同時旋轉
        var step = speed * Time.deltaTime;
        transform.parent.transform.localRotation = Quaternion.RotateTowards(transform.parent.transform.localRotation, targetQuaternion, step);
        //如果轉到了(誤差1度內)就停止旋轉
        if(Quaternion.Angle(transform.parent.transform.localRotation,targetQuaternion)<=1)
        {
            transform.parent.transform.localRotation = targetQuaternion;
            cubeState.PutDown(activeSide, cubeState.transform);
            readCube.ReadState();
            CubeState.autoRotating = false;
            autoRotating = false;
            dragging = false;
        }
    }
}
