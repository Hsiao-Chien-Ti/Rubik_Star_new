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
    public GameObject player;
    public GameObject playerNew;
    public GameObject ladder;
    public GameObject ladderNew;
    bool first = true;
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            player = collision.gameObject;
            if(PickupLadder.picked&first)
            {
                StartCoroutine(putDown());
                first = false;
            }
            else if (slider.value == slider.maxValue && CollectWithTrash.trash == 0&&first)
            {
                player.GetComponent<Animator>().SetTrigger("WantRocket");
                FadeIn(highTxt,2.5f);
                StartCoroutine(levelController.show(3.5f));
                //levelController.show();
            }
            else if(!first)
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
    //IEnumerator hidePlayer()
    //{
    //    yield return new WaitForSeconds(1.5f);
    //    player.SetActive(false);
    //    ladder.SetActive(true);
    //}
    IEnumerator putDown()
    {
        player.SetActive(false);
        playerNew.SetActive(true);
        ladder.SetActive(true);
        playerNew.GetComponent<Animator>().Play("PutDownLadder");
        yield return new WaitForSeconds(2f);
        ladder.SetActive(false);
        ladderNew.SetActive(true);
        playerNew.GetComponent<Animator>().Play("UpLadder");
        StartCoroutine(GetComponent<LadderToColor>().climb());
    }
}
