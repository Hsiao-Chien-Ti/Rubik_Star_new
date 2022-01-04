using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarDrop : MonoBehaviour
{
    public Rigidbody rb;
    public AudioSource Audio;
    public AudioClip dropAudio;
    public AudioClip catchAudio;
    public CubeState cubeState;
    public GameObject[] posList;
    float dropTime;
    bool dropFlag = false;
    public int dropMin;
    public int dropMax;
    float timeStamp;
    bool started = false;
    bool fly = false;
    int posidx;
    string face;
    private void Start()
    {
        cubeState = transform.parent.transform.parent.transform.parent.transform.parent.GetComponent<CubeState>();
        face = transform.parent.parent.parent.name;
        dropTime = Random.Range(dropMin, dropMax);

    }
    private void FixedUpdate()
    {
        if (FindObjectOfType<CharacterMoving>() != null && !started)
        {
            timeStamp = Time.time;
            started = true;
        }
        if (Time.time >= timeStamp + dropTime && Time.time <= timeStamp + dropTime + 1f && dropFlag == false && started)
        {
            //dropFlag = true;
            //posidx = Random.Range(0, 9);
            //switch (face)
            //{
            //    case "L":
            //        posList = cubeState.left.ToArray();
            //        break;
            //    case "R":
            //        posList = cubeState.right.ToArray();
            //        break;
            //    case "U":
            //        posList = cubeState.up.ToArray();
            //        break;
            //    case "D":
            //        posList = cubeState.down.ToArray();
            //        break;
            //    case "F":
            //        posList = cubeState.front.ToArray();
            //        break;
            //    case "B":
            //        posList = cubeState.back.ToArray();
            //        break;
            //}
            //Vector3 initpos = posList[posidx].transform.position + new Vector3(0, 18, 0);
            //gameObject.transform.localScale *= 300;
            //gameObject.GetComponent<MeshCollider>().enabled = true;
            //Audio.volume = 1.0f;
            //Audio.clip = dropAudio;
            //Audio.Play();
            //fly = true;
            StartCoroutine(calculate());
        }
        if (fly)
        {

            transform.position = Vector3.MoveTowards(transform.position, posList[posidx].transform.position, 0.1f);
            if (transform.position == posList[posidx].transform.position)
            {
                fly = false;
            }
        }
    }
    IEnumerator calculate()
    {
        dropFlag = true;
        posidx = Random.Range(0, 9);
        switch (face)
        {
            case "L":
                posList = cubeState.left.ToArray();
                break;
            case "R":
                posList = cubeState.right.ToArray();
                break;
            case "U":
                posList = cubeState.up.ToArray();
                break;
            case "D":
                posList = cubeState.down.ToArray();
                break;
            case "F":
                posList = cubeState.front.ToArray();
                break;
            case "B":
                posList = cubeState.back.ToArray();
                break;
        }
        Vector3 initpos = posList[posidx].transform.position + new Vector3(0, 18, 0);
        gameObject.transform.localScale *= 300;
        gameObject.GetComponent<MeshCollider>().enabled = true;
        Audio.volume = 1.0f;
        Audio.clip = dropAudio;
        Audio.Play();
        fly = true;
        yield return null;
    }
    private void OnTriggerEnter(Collider other)
    {
        
        if(other.gameObject.CompareTag("netQuad"))
        {
            print("catch");
            Audio.clip = catchAudio;
            Audio.volume = 0.1f;
            Audio.Play();
            Audio.SetScheduledEndTime(AudioSettings.dspTime + 1f);
        }
        Destroy(gameObject.transform.parent.gameObject);

    }
    IEnumerator playAudio()
    {
        yield return new WaitForSeconds(2.7f);
            Audio.volume = 1.0f;
            Audio.clip = dropAudio;
            Audio.Play();
    }
}
