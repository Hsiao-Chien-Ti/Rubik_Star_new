using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidDrop : MonoBehaviour
{
    public Rigidbody rb;
    public AudioSource Audio;
    public AudioClip dropAudio;
    public AudioClip boomAudio;
    float dropTime;
    bool dropFlag=false;
    public int dropMin;
    public int dropMax;
    float timeStamp;
    bool started = false;
    private void Start()
    {
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
        rb.AddForce(Random.Range(-50, 50), 0, Random.Range(-50, 50));
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
        Audio.SetScheduledEndTime(AudioSettings.dspTime + 1f);
        GetComponent<Fracture>().FractureObject();
    }
}
