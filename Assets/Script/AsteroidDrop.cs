using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidDrop : MonoBehaviour
{
    public Rigidbody rb;
    public AudioSource Audio;
    public AudioClip dropAudio;
    public AudioClip boomAudio;
    public List<Vector3> posList;
    float dropTime;
    bool dropFlag=false;
    public int dropMin;
    public int dropMax;
    float timeStamp;
    bool started = false;
    GameObject aim;
    public GameObject aimPrefab;
    Transform t;
    private void Start()
    {
        posList= new List<Vector3> { new Vector3(-1, 1.51f, 1), new Vector3(0, 1.51f, 1), new Vector3(1, 1.51f, 1), new Vector3(-1, 1.51f, 0), new Vector3(0, 1.51f, 0), new Vector3(1, 1.51f, 0), new Vector3(1, 1.51f, -1), new Vector3(0, 1.51f, -1), new Vector3(1, 1.51f, -1) };
        dropTime = Random.Range(dropMin, dropMax);
        
    }
    private void FixedUpdate()
    {
        if(FindObjectOfType<CharacterMoving>() != null && !started)
        {
            timeStamp = Time.time;
            started = true;
        }
        if(Time.time>=timeStamp+dropTime&&dropFlag==false&&started)
        {
            fly();
            dropFlag = true;
            rb.useGravity = true;
        }
    }
    public void fly()
    {
        int posidx = Random.Range(0, 9);
        Vector3 initpos = posList[posidx]+new Vector3(0, 11, 0);
        rb.position = initpos;
        transform.position=Vector3.MoveTowards(transform.position, posList[posidx],5);
        aim = GameObject.Instantiate(aimPrefab, posList[posidx],Quaternion.Euler(90,0,0));
        //rb.AddForce(Random.Range(-50, 50), 0, Random.Range(-50, 50));
        Audio.volume = 1.0f;
        Audio.clip = dropAudio;
        Audio.Play();
    }
    private void OnCollisionEnter(Collision collision)
    {
        //print(collision.gameObject.name);
        Audio.clip = boomAudio;
        Audio.volume = 0.1f;
        Audio.Play();
        Destroy(aim);
        Audio.SetScheduledEndTime(AudioSettings.dspTime + 1f);
        GetComponent<Fracture>().FractureObject();
    }
}
