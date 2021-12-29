using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TrashCan : MonoBehaviour
{
    Animator anim;
    public Slider slider;
    public GameObject msg;
    public GameObject msgNPC;
    public ParticleSystem bubble;
    public bool isLevel7=false;
    
    private void Start()
    {
        anim = GetComponent<Animator>();
    }
    private void OnTriggerEnter(Collider other)
    {
        //msg.transform.forward = Vector3.forward;
        msg.SetActive(true);
        msgNPC.SetActive(true);
    }
    private void OnTriggerExit(Collider other)
    {
        msg.SetActive(false);
        msgNPC.SetActive(false);
    }
    private void Update()
    {
        if(msg.activeSelf)
        {
            if(Input.GetKeyDown(KeyCode.R))
            {
                if(CollectWithTrash.trash>0)
                {

                    if(isLevel7)
                    {
                        anim.SetTrigger("Bubble");
                        slider.value -= CollectWithTrash.trash;
                        CollectWithTrash.trash = 0;
                    }                    
                    else
                    {
                        anim.SetTrigger("Trash");
                        slider.value -= CollectWithTrash.trash;
                        CollectWithTrash.trash = 0;
                    }

                }
                else
                {
                    anim.SetTrigger("noTrash");
                }
            }
        }
    }
    public void playBubble()
    {
        bubble.Play();
    }

}
