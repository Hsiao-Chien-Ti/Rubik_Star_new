using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wall : MonoBehaviour
{
    public GameObject wall1;
    public GameObject wall2;
    public GameObject wall3;
    public GameObject wall4;
    public GameObject wall5;
    public GameObject wall6;
    CubeState cubeState;
    private void Start()
    {
        cubeState = transform.parent.gameObject.GetComponent<CubeState>();
    }
    private void FixedUpdate()
    {
        if(cubeState.autoRotating)
        {
            wall1.SetActive(false);
            wall2.SetActive(false);
            wall3.SetActive(false);
            wall4.SetActive(false);
            wall5.SetActive(false);
            wall6.SetActive(false);
        }
        else
        {
            wall1.SetActive(true);
            wall2.SetActive(true);
            wall3.SetActive(true);
            wall4.SetActive(true);
            wall5.SetActive(true);
            wall6.SetActive(true);
        }
    }

}
