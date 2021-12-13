using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NowPosition : MonoBehaviour
{
    public Transform feet;
    RaycastHit hit;
    public LayerMask cubeLayer;
    public LayerMask wallLayer;
    public GameObject nowFace;
    public GameObject nowWall;
    CubeMap cubeMap;
    public Rigidbody rb;
    List<Vector3> upFace=new List<Vector3>();
    public bool isGround; 
    private void Start()
    {
        cubeMap = FindObjectOfType<CubeMap>();
        for(int i=0;i<=2;i++)
        {
            for(int j=0;j<=2;j++)
            {
                upFace.Add(new Vector3(-1 + j, 1.5f, 1 - i));
                //print(new Vector3(-1 + i, 1.5f, 1 - j));
            }
        }
    }
    private void Update()
    {
        if(Physics.Raycast(feet.position,-transform.up,out hit,0.5f,cubeLayer))
        {
            nowFace = hit.collider.gameObject;
            transform.parent = nowFace.transform.parent;
        }
    }
}
