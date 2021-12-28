using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PickupLadder : MonoBehaviour
{
    public GameObject ladder;
    public GameObject ladderNew;
    public GameObject head;
    public GameObject RArm;
    public GameObject net;
    public static bool picked=false;
    public Slider slider;
    public Text collectTxt;
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.name=="SateLadder")
        {
            if(slider.value == slider.maxValue && CollectWithTrash.trash == 0)
            {
                ladder.transform.parent = RArm.transform;
                Destroy(other.gameObject);
                ladder.SetActive(true);
                net.SetActive(false);
                picked = true;
                StartCoroutine(anim());
            }
            else
            {
                collectTxt.text = "Collect More!!!!!";
                FadeIn(collectTxt, 0f);
                FadeOut(collectTxt);
            }

        }
    }
    IEnumerator anim()
    {
        GetComponent<Animator>().SetBool("FinishPickLadder", false);
        GetComponent<Animator>().Play("PickupLadder");
        yield return new WaitForSeconds(1.1f);
        ladder.SetActive(false);
        ladderNew.SetActive(true);
        GetComponent<Animator>().SetBool("FinishPickLadder",true);
    }
    // Start is called before the first frame update
    void Start()
    {
        picked = false;
    }
    void FadeIn(Text txt, float delay)
    {
        LeanTween.alphaCanvas(txt.GetComponent<CanvasGroup>(), 1, 0.5f).setDelay(delay).setOnComplete(() => FadeOut(txt));
    }
    void FadeOut(Text txt)
    {
        LeanTween.alphaCanvas(txt.GetComponent<CanvasGroup>(), 0, 0.5f).setDelay(1f);
    }
}
