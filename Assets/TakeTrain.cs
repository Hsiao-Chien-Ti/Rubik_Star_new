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
    public RotateBigCube cubeRotator;
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
        yield return new WaitUntil(cubeRotator.RotateToTrail);
        train.SetActive(true);
        yield return new WaitForSeconds(5f);
        trainAnim.GetComponent<Animator>().enabled = true;
        mainCam.SetActive(false);
        trainCam.SetActive(true);
        yield return new WaitForSeconds(4f);
        player.transform.position = playerTrans.position;
        player.transform.localScale = new Vector3(10, 10, 10);
        trainCam.SetActive(false);
        sateCam.SetActive(true);
        player.GetComponent<FaceUp>().cubeRotator = sate.GetComponent<RotateBigCube>();
        
    }
}
