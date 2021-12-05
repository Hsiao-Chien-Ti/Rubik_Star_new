using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HelmetDefend : MonoBehaviour
{
    public GameObject helmet;
    public Animator anim;
    public bool defending=false;
    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Tab))
        {
            StartCoroutine(hatOn());
        }
    }
    IEnumerator hatOn()
    {
        helmet.SetActive(true);
        anim.SetTrigger("HatOn");
        defending = true;
        yield return new WaitForSeconds(1f);
        anim.SetTrigger("HatOff");
        yield return new WaitForSeconds(0.1f);
        helmet.SetActive(false);
        defending = false;
    }
}
