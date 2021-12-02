using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeState : MonoBehaviour
{
    public List<GameObject> front = new List<GameObject>();
    public List<GameObject> back = new List<GameObject>();
    public List<GameObject> up = new List<GameObject>();
    public List<GameObject> down= new List<GameObject>();
    public List<GameObject> left = new List<GameObject>();
    public List<GameObject> right = new List<GameObject>();
    public static bool autoRotating = false;
    public static bool started = false;
    public static bool dragging = false;
    public GameObject player;
    
    public void PickUp(List<GameObject> cubeSide)
    {
        foreach(GameObject face in cubeSide)
        {
            //Attach the parent of each face(小方塊)
            //to the parent of the middle face(index=4)
            //中間那塊不要設因為自己不能當自己的parent
            //why parent?->因為是偵測face layer ,face layer上的是小方塊上的各個面 所以要找到那個方塊本身 要看parent
            if(face!=cubeSide[4])
            {
                face.transform.parent.transform.parent = cubeSide[4].transform.parent;
            }
        }
        //player.transform.parent = cubeSide[4].transform.parent;
        //Start rotating
        //cubeSide[4].transform.parent.GetComponent<PivotRotation>().Rotate(cubeSide);
    }
    public void PutDown(List<GameObject> littleCubes,Transform pivot)
    {
        //player.transform.parent = null;
        foreach(GameObject littleCube in littleCubes)
        {
            if(littleCube!=littleCubes[4])
            {
                littleCube.transform.parent.transform.parent = pivot;
            }
        }
    }

}
