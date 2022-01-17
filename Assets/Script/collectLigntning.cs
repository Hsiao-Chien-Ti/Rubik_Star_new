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
    public Text txt;
    private void Update()
    {
        GetComponent<BoxCollider>().enabled = transform.parent.GetComponent<LineRenderer>().enabled;
        if(!transform.parent.GetComponent<LineRenderer>().enabled)
        {
            hitTime = 0;
            exitTime = 0;
            outTrigger = true;
            used = false;
        }
        //if(Time.time-hitTime>15f&&used)
        //{
        //    showToast("沒有在這邊一直充電的歐，請轉走一下再來吧", 1);
        //}
        if (Time.time-hitTime>1f&&!outTrigger&&!used&&LightningCombine.finish)
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
        if (other.gameObject.name=="L_Wall")
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
    void showToast(string text,
int duration)
    {
        StartCoroutine(showToastCOR(text, duration));
    }

    private IEnumerator showToastCOR(string text,
        int duration)
    {
        Color orginalColor = txt.color;

        txt.text = text;
        txt.enabled = true;

        //Fade in
        yield return fadeInAndOut(txt, true, 0.5f);

        //Wait for the duration
        float counter = 0;
        while (counter < duration)
        {
            counter += Time.deltaTime;
            yield return null;
        }

        //Fade out
        yield return fadeInAndOut(txt, false, 0.5f);

        txt.enabled = false;
        txt.color = orginalColor;
    }

    IEnumerator fadeInAndOut(Text targetText, bool fadeIn, float duration)
    {
        //Set Values depending on if fadeIn or fadeOut
        float a, b;
        if (fadeIn)
        {
            a = 0f;
            b = 1f;
        }
        else
        {
            a = 1f;
            b = 0f;
        }

        Color currentColor = txt.color;
        float counter = 0f;

        while (counter < duration)
        {
            counter += Time.deltaTime;
            float alpha = Mathf.Lerp(a, b, counter / duration);

            targetText.color = new Color(currentColor.r, currentColor.g, currentColor.b, alpha);
            yield return null;
        }
    }
}
