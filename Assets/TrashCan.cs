using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrashCan : MonoBehaviour
{
    Animator anim;

    public GameObject msg;
    bool active;
    private void Start()
    {
        anim = GetComponent<Animator>();
    }
    private void OnTriggerEnter(Collider other)
    {
        msg.SetActive(true);
    }
    private void OnTriggerExit(Collider other)
    {
        msg.SetActive(false);
    }
    private void OnTriggerStay(Collider other)
    {
        if(Input.GetKeyDown(KeyCode.D))
        {
            if(CollectWithTrash.trash>0)
            {
                anim.SetTrigger("Trash");
            }
            else
            {
                anim.SetTrigger("noTrash");
            }
        }
    }
}
