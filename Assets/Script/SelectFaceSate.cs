using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectFaceSate : MonoBehaviour
{
    CubeState cubeState;
    ReadCube readCube;

    int layerMask = 1 << 8;//raycast只偵測face layer
    // Start is called before the first frame update
    void Start()
    {
        readCube = GetComponent<ReadCube>();
        cubeState = GetComponent<CubeState>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0) && !cubeState.autoRotating)
        {
            //cubeState.leftDragging = true;
            //read the current of the cube
            readCube.ReadState();
            //從滑鼠位置發送ray，看碰到哪個面就知道是要轉哪個面
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out hit, 100.0f, layerMask))
            {
                GameObject face = hit.collider.gameObject;
                //print(face.transform.parent.name);
                if(face.transform.parent.GetComponent<PivotRotationSate>()!=null)
                    face.transform.parent.GetComponent<PivotRotationSate>().Rotate(face);
            }
        }
    }
}
