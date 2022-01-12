using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectBattery : MonoBehaviour
{
    public Animator anim;
    public GameObject pickedBattery;
    public GameObject player;
    public GameObject net;
    private void OnTriggerEnter(Collider other)
    {
        Level4.battery = true;
        anim.SetBool("IsBattery", true);
        anim.SetTrigger("PickupBattery");
        pickedBattery.SetActive(true);
        
        net.SetActive(false);
        player.GetComponent<UsingNet>().enabled = false;
        gameObject.SetActive(false);
    }
}
