using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupLadder : MonoBehaviour
{
    public GameObject ladder;
    public GameObject head;
    public GameObject RArm;
    public GameObject net;
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.name=="SateLadder")
        {
            ladder.transform.parent = RArm.transform;
            Destroy(other.gameObject);
            ladder.SetActive(true);
            net.SetActive(false);
            StartCoroutine(anim());
        }
    }
    IEnumerator anim()
    {
        GetComponent<Animator>().SetBool("FinishPickLadder", false);
        GetComponent<Animator>().Play("PickupLadder");
        yield return new WaitForSeconds(1.1f);
        ladder.transform.parent = head.transform;
        GetComponent<Animator>().SetBool("FinishPickLadder",true);
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //if(GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).length >
        //    GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).normalizedTime&& GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).IsName("PickupLadder"))
        //{

        //}
        //if (GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).IsName("PickupLadder"))
        //{
        //    ladder.transform.parent =RArm.transform;
        //}
        //else
        //{
        //    
        //}
    }
}
