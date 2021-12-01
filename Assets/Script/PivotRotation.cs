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
    // Start is called before the first frame update
    void Start()
    {
        readCube = FindObjectOfType<ReadCube>();
        cubeState = FindObjectOfType<CubeState>();
    }

    // Update is called once per frame
    void LateUpdate()
    {
        if(dragging&&!autoRotating)
        {
            CubeState.autoRotating = true;
            SpinSide(activeSide);
            if(Input.GetMouseButtonUp(0))//not dragging anymore
            {
                dragging = false;
                RotateToRightAngle();//fix the rotation angle
            }
        }
        if(autoRotating)
        {
            CubeState.autoRotating = true;
            AutoRotate();
        }
    }
    private void SpinSide(List<GameObject>side)
    {
        //reset the rotation
        rotation = Vector3.zero;
        //看滑鼠移動多少來決定要轉多少
        Vector3 mouseOffset = (Input.mousePosition - mouseRef);
        if(side==cubeState.front)
        {
            rotation.x = (mouseOffset.x + mouseOffset.y) * sensitivity*-1;
        }
        if (side == cubeState.back)
        {
            rotation.x = (mouseOffset.x + mouseOffset.y) * sensitivity;
        }
        if (side == cubeState.up)
        {
            rotation.y = (mouseOffset.x + mouseOffset.y) * sensitivity*-1;
        }
        if (side == cubeState.down)
        {
            rotation.y = (mouseOffset.x + mouseOffset.y) * sensitivity;
        }
        if (side == cubeState.left)
        {
            rotation.z = (mouseOffset.x + mouseOffset.y) * sensitivity*-1 ;
        }
        if (side == cubeState.right)
        {
            rotation.z = (mouseOffset.x + mouseOffset.y) * sensitivity *-1;
        }


        //rotate
        transform.Rotate(rotation, Space.World);
        //store mouse position for next rotation
        mouseRef = Input.mousePosition;
    }
    public void Rotate(List<GameObject> side)
    {
        activeSide = side;
        mouseRef = Input.mousePosition;
        dragging = true;
        //create a vector to rotate around
        localForward = Vector3.zero - side[4].transform.parent.transform.localPosition;
    }

    //避免轉一半的狀況發生
    public void RotateToRightAngle()
    {
        Vector3 vec = transform.localEulerAngles;
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
        targetQuaternion = Quaternion.AngleAxis(angle, localForward)*transform.localRotation;
        activeSide = side;
        autoRotating = true;
    }
    private void AutoRotate()
    {
        dragging = false;//避免同時旋轉
        var step = speed * Time.deltaTime;
        transform.localRotation = Quaternion.RotateTowards(transform.localRotation, targetQuaternion, step);
        //如果轉到了(誤差1度內)就停止旋轉
        if(Quaternion.Angle(transform.localRotation,targetQuaternion)<=1)
        {
            transform.localRotation = targetQuaternion;
            cubeState.PutDown(activeSide, transform.parent);
            readCube.ReadState();
            CubeState.autoRotating = false;
            autoRotating = false;
            dragging = false;
        }
    }
}
