using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectFace : MonoBehaviour
{
    CubeState cubeState;
    ReadCube readCube;
    int layerMask = 1 << 8;//raycast只偵測face layer
    // Start is called before the first frame update
    void Start()
    {
        readCube = FindObjectOfType<ReadCube>();
        cubeState = FindObjectOfType<CubeState>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0)&&!CubeState.autoRotating)
        {
            //read the current of the cube
            readCube.ReadState();
            //從滑鼠位置發送ray，看碰到哪個面就知道是要轉哪個面
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if(Physics.Raycast(ray,out hit,100.0f,layerMask))
            {
                GameObject face = hit.collider.gameObject;
                //make a list of all sides
                //side是單一一塊(GameObject)的list
                //整個cube是sides的list
                //List<List<GameObject>> cubeSides = new List<List<GameObject>>()
                //{
                //    cubeState.up,
                //    cubeState.down,
                //    cubeState.right,
                //    cubeState.left,
                //    cubeState.front,
                //    cubeState.back
                //};
                //看剛剛點的那塊是屬於哪個面
                //foreach(List<GameObject> cubeSide in cubeSides)
                //{
                //    if(cubeSide.Contains(face))
                //    {
                //        cubeState.PickUp(cubeSide);
                //        cubeSide[4].transform.parent.GetComponent<PivotRotation>().Rotate(cubeSide);
                //    }
                //}
                if(cubeState.back.Contains(face))//click back side
                {
                    for(int i=0;i<9;i++)
                    {
                        if(face==cubeState.back[i])
                        {
                            if(i==5)
                            {
                                cubeState.PickUp(cubeState.left);
                                cubeState.left[4].transform.parent.GetComponent<PivotRotation>().Rotate(cubeState.left);
                            }
                            if (i == 0 || i == 3 || i == 6)
                            {
                                cubeState.PickUp(cubeState.right);
                                cubeState.right[4].transform.parent.GetComponent<PivotRotation>().Rotate(cubeState.right);
                            }
                        }
                    }
                }

            }
        }
    }
}
