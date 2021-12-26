using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DokodemoDoor : MonoBehaviour
{
    public GameObject sate;
    public GameObject cube;
    public GameObject player;
    public GameObject mainCam;
    public GameObject sateCam;
    public Transform playerRubikTrans;
    public GameObject msg;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(msg.activeSelf)
        {
            if(Input.GetKeyDown(KeyCode.D))
            {
                back();
            }
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        //StartCoroutine(back());
        msg.SetActive(true);
    }
    private void OnTriggerExit(Collider other)
    {
        msg.SetActive(false);
    }
    //IEnumerator back()
    public void back()
    {
        
        sate.transform.rotation = Quaternion.Euler(0, 0, 0);
        cube.transform.parent.transform.parent = null;
        cube.GetComponent<CubeState>().enabled = true;
        cube.GetComponent<ReadCube>().enabled = true;
        cube.GetComponent<RotateBigCube>().enabled = true;
        cube.GetComponent<SelectFace>().enabled = true;
        for (int i = 1; i < cube.transform.childCount; i++)
        {
            cube.transform.GetChild(i).gameObject.GetComponent<PivotRotation>().enabled = true;
        }
        sate.GetComponent<CubeState>().enabled = false;
        sate.GetComponent<ReadCube>().enabled = false;
        sate.GetComponent<RotateBigCube>().enabled = false;
        sate.GetComponent<SelectFaceSate>().enabled = false;
        for (int i = 1; i < sate.transform.childCount; i++)
        {
            sate.transform.GetChild(i).gameObject.GetComponent<PivotRotationSate>().enabled = false;
        }

        sate.transform.parent.transform.parent = cube.transform;
        //yield return new WaitUntil(cube.GetComponent<RotateBigCube>().RotateToTrail);
        player.transform.localScale = new Vector3(0.001f, 0.001f, 0.001f);
        player.transform.position = playerRubikTrans.position;
        player.transform.rotation = playerRubikTrans.rotation;
        player.transform.localScale = new Vector3(10, 10, 10);
        player.GetComponent<FaceUp>().cubeRotator = cube.GetComponent<RotateBigCube>();
        player.GetComponent<FaceUp>().rubik = true;
        player.GetComponent<CharacterMoving>().cubeState = cube.GetComponent<CubeState>();
        cube.GetComponent<CubeState>().leftDragging = false;
        cube.GetComponent<RotateBigCube>().rubik = 1;

        sateCam.SetActive(false);
        mainCam.SetActive(true);
    }
}
