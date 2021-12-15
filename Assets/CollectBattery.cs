using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectBattery : MonoBehaviour
{
    public Animator anim;
    public GameObject pickedBattery;
    public GameObject player;
    public GameObject net;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        Level3.battery = true;
        pickedBattery.SetActive(true);
        anim.SetTrigger("PickupBattery");
        net.SetActive(false);
        player.GetComponent<UsingNet>().enabled = false;
        Destroy(gameObject);
    }
}
