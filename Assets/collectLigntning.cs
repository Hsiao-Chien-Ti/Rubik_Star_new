using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class collectLigntning : MonoBehaviour
{
    float hitTime=0;
    float exitTime=0;
    bool outTrigger=true;
    public int power=0;
    public List<Sprite> imgs;
    public GameObject img;
    bool used=false;
    private void Update()
    {
        if(Time.time-hitTime>1f&&!outTrigger&&!used&&LightningCombine.finish)
        {
            if(power<4)
            {
                exitTime = 0;
                hitTime = 0;
                power++;
                used = true;
                img.GetComponent<SpriteRenderer>().sprite = imgs[power];
            }
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        //print(other.gameObject.name);
        if(other.gameObject.name=="L_Wall")
        {
            hitTime = Time.time;
            outTrigger = false;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.name == "L_Wall")
        {
            exitTime = Time.time;
            outTrigger = true;
            used = false;
        }
    }
}
