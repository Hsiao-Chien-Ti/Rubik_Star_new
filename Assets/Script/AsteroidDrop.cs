using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidDrop : MonoBehaviour
{
    public Rigidbody rb;
    public AudioSource Audio;
    public AudioClip dropAudio;
    public AudioClip boomAudio;
    public CubeState cubeState;
    public GameObject[] posList;
    float dropTime;
    bool dropFlag=false;
    public int dropMin;
    public int dropMax;
    float timeStamp;
    bool started = false;
    bool fly = false;
    GameObject aim;
    public GameObject aimPrefab;
    Vector3 rotation;
    Transform ray;
    int posidx;
    string face;
    //public Transform tUp;
    //public Transform tDown;
    //public Transform tLeft;
    //public Transform tRight;
    //public Transform tFront;
    //public Transform tBack;
    private void Start()
    {
        gameObject.transform.localScale = new Vector3(0.001f, 0.001f, 0.001f);
        //posList= new List<Vector3> { new Vector3(-1, 1.52f, 1), new Vector3(0, 1.52f, 1), new Vector3(1, 1.52f, 1), new Vector3(-1, 1.52f, 0), new Vector3(0, 1.52f, 0), new Vector3(1, 1.52f, 0), new Vector3(1, 1.52f, -1), new Vector3(0, 1.52f, -1), new Vector3(1, 1.52f, -1) };
        cubeState = GameObject.FindObjectOfType<CubeState>();
        face = transform.parent.parent.name;
        dropTime = Random.Range(dropMin, dropMax);
    }
    private void FixedUpdate()
    {
        switch (face)
        {
            case "L":
                posList = cubeState.left.ToArray();
                //rotation = new Vector3(0, 0, 0);
                //ray = tLeft;
                break;
            case "R":
                posList = cubeState.right.ToArray();
                //rotation = new Vector3(0, 180, 0);
                //ray = tRight;
                break;
            case "U":
                posList = cubeState.up.ToArray();
                //rotation = new Vector3(90, 90, 0);
                //ray = tUp;
                break;
            case "D":
                posList = cubeState.down.ToArray();
                //rotation = new Vector3(270, 90, 0);
                //ray = tDown;
                break;
            case "F":
                posList = cubeState.front.ToArray();
                //rotation = new Vector3(0, 270, 0);
                //ray = tFront;
                break;
            case "B":
                posList = cubeState.back.ToArray();
                //rotation = new Vector3(0, 90, 0);
                //ray = tBack;
                break;
        }
        if (FindObjectOfType<CharacterMoving>() != null && !started)
        {
            timeStamp = Time.time;
            started = true;
        }
        if(Time.time>=timeStamp+dropTime&&dropFlag==false&&started)
        {
            dropFlag = true;
            posidx = Random.Range(0, 9);
            Vector3 initpos = posList[posidx].transform.position + new Vector3(0, 18, 0);
            //aim = GameObject.Instantiate(aimPrefab, posList[posidx].transform.position,Quaternion.identity,ray);
            //aim.transform.localPosition += ray.right.normalized*0.05f;
            gameObject.transform.localScale = new Vector3(0.3f, 0.3f, 0.3f);
            gameObject.GetComponent<MeshCollider>().enabled = true;
            Audio.volume = 1.0f;
            Audio.clip = dropAudio;
            Audio.Play();
            fly = true;

            //StartCoroutine(flyIE());

            
            //rb.useGravity = true;
        }
        if (fly)
        {

            transform.position = Vector3.MoveTowards(transform.position, posList[posidx].transform.position, 0.4f);
            if (transform.position == posList[posidx].transform.position)
            {
                fly = false;
            }
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        //print(collision.gameObject.name);
        Audio.clip = boomAudio;
        Audio.volume = 0.1f;
        Audio.Play();
        //Destroy(aim);
        Audio.SetScheduledEndTime(AudioSettings.dspTime + 0.8f);
        GetComponent<Fracture>().FractureObject();
    }
    IEnumerator flyIE()
    {
       while(!(transform.position == posList[posidx].transform.position))
        {
           transform.position = Vector3.MoveTowards(transform.position, posList[posidx].transform.position, 13f*Time.deltaTime);
           yield return null;
        }
      
    }
}
