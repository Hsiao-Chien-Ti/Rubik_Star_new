using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarDrop : MonoBehaviour
{
    public Rigidbody rb;
    public AudioSource Audio;
    public AudioClip dropAudio;
    public AudioClip catchAudio;
    public List<Vector3> posList;
    float dropTime;
    bool dropFlag = false;
    public int dropMin;
    public int dropMax;
    float timeStamp;
    bool started = false;
    bool fly = false;
    GameObject aim;
    public GameObject aimPrefab;
    Transform t;
    int posidx;
    private void Start()
    {
        posList = new List<Vector3> { new Vector3(-1, 1.51f, 1), new Vector3(0, 1.51f, 1), new Vector3(1, 1.51f, 1), new Vector3(-1, 1.51f, 0), new Vector3(0, 1.51f, 0), new Vector3(1, 1.51f, 0), new Vector3(1, 1.51f, -1), new Vector3(0, 1.51f, -1), new Vector3(1, 1.51f, -1) };
        dropTime = Random.Range(dropMin, dropMax);

    }
    private void FixedUpdate()
    {
        if (FindObjectOfType<CharacterMoving>() != null && !started)
        {
            timeStamp = Time.time;
            started = true;
        }
        if (Time.time >= timeStamp + dropTime && dropFlag == false && started)
        {
            posidx = Random.Range(0, 9);
            Vector3 initpos = posList[posidx] + new Vector3(0, 11, 0);
            //aim = GameObject.Instantiate(aimPrefab, posList[posidx], Quaternion.Euler(90, 0, 0));
            rb.position = initpos;
            Audio.volume = 1.0f;
            Audio.clip = dropAudio;
            Audio.Play();
            fly = true;
            dropFlag = true;
            //rb.useGravity = true;
        }
        if (fly)
        {
            transform.position = Vector3.MoveTowards(transform.position, posList[posidx], 0.02f);
            if (transform.position == posList[posidx])
            {
                fly = false;
            }
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        
        Destroy(gameObject);
        if(other.gameObject.CompareTag("netQuad"))
        {
            Audio.clip = catchAudio;
            Audio.volume = 0.1f;
            Audio.Play();
            Audio.SetScheduledEndTime(AudioSettings.dspTime + 1f);
        }

    }
}
