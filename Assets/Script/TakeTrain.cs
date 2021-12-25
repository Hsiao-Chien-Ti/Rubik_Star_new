using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TakeTrain : MonoBehaviour
{
    public GameObject train;
    public GameObject trainAnim;
    public GameObject mainCam;
    public GameObject trainCam;
    public GameObject sateCam;
    public GameObject player;
    public Transform playerTrans;
    public GameObject cube;
    public GameObject sate;
    // Start is called before the first frame update
    private void OnTriggerEnter(Collider other)
    {
        StartCoroutine(takeTrain());
    }
    IEnumerator takeTrain()
    {
        player.transform.localScale = new Vector3(0.001f, 0.001f, 0.001f);
        gameObject.transform.localScale = new Vector3(0.001f, 0.001f, 0.001f);
        yield return new WaitUntil(cube.GetComponent<RotateBigCube>().RotateToTrail);
        train.SetActive(true);
        yield return new WaitForSeconds(5f);
        trainAnim.GetComponent<Animator>().enabled = true;
        mainCam.SetActive(false);
        trainCam.SetActive(true);
        yield return new WaitForSeconds(4f);
        player.transform.position = playerTrans.position;
        player.transform.localScale = new Vector3(10, 10, 10);

        sate.transform.parent.transform.parent = null;
        sate.GetComponent<CubeState>().enabled = true;
        sate.GetComponent<ReadCube>().enabled = true;
        sate.GetComponent<RotateBigCube>().enabled = true;
        sate.GetComponent<SelectFaceSate>().enabled = true;
        for (int i = 1; i < sate.transform.childCount; i++)
        {
            sate.transform.GetChild(i).gameObject.GetComponent<PivotRotationSate>().enabled = true;
        }

        cube.GetComponent<CubeState>().enabled = false;
        cube.GetComponent<ReadCube>().enabled = false;
        cube.GetComponent<RotateBigCube>().enabled = false;
        cube.GetComponent<SelectFace>().enabled = false;
        for (int i = 1; i < cube.transform.childCount; i++)
        {
            cube.transform.GetChild(i).gameObject.GetComponent<PivotRotation>().enabled = false;
        }

        cube.transform.parent.transform.parent = sate.transform;

        player.GetComponent<FaceUp>().cubeRotator = sate.GetComponent<RotateBigCube>();
        player.GetComponent<FaceUp>().rubik = false;
        player.GetComponent<CharacterMoving>().cubeState = sate.GetComponent<CubeState>();
        sate.GetComponent<CubeState>().leftDragging = false;
        sate.GetComponent<RotateBigCube>().rubik = -1;
       
        trainCam.SetActive(false);
        train.SetActive(false);
        sateCam.SetActive(true);
        
    }
}
