using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WantRocket : MonoBehaviour
{
    public Slider slider;
    public Text collectTxt;
    public Text highTxt;
    public Ticket levelController;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    //void Update()
    //{
    //    if(slider.value==slider.maxValue&&CollectWithTrash.trash==0)
    //    {
    //        GetComponent<BoxCollider>().isTrigger = true;
    //    }
    //}
    //private void OnTriggerEnter(Collider other)
    //{
    //    if(other.gameObject.CompareTag("Player"))
    //    {
    //        other.gameObject.GetComponent<Animator>().SetTrigger("WantRocket");
    //    }
    //}
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            if (slider.value == slider.maxValue && CollectWithTrash.trash == 0)
            {
                collision.gameObject.GetComponent<Animator>().SetTrigger("WantRocket");
                FadeIn(highTxt,2.5f);
                StartCoroutine(levelController.show(3.5f));
                //levelController.show();
            }
                
            else
            {
                collectTxt.text = "Collect More!!!!!";
                FadeIn(collectTxt,0);
            }
        }
    }
    void FadeIn(Text txt,float delay)
    {
        LeanTween.alphaCanvas(txt.GetComponent<CanvasGroup>(), 1, 0.5f).setDelay(delay).setOnComplete(()=>FadeOut(txt));
    }
    void FadeOut(Text txt)
    {
        LeanTween.alphaCanvas(txt.GetComponent<CanvasGroup>(), 0, 0.5f).setDelay(1f);
    }
}
