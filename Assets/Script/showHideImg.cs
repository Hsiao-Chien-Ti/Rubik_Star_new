using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class showHideImg : MonoBehaviour
{
    public float time;
    public float maxAlpha;
    public float minAlpha;
    void Start()
    {
        
    }
    public void startProcedure()
    {
        StartCoroutine(procedure());
    }
    public void show()
    {
        StartCoroutine(fadeInAndOut(GetComponent<Image>(), true, 0.8f));
    }
    IEnumerator procedure()
    {
        yield return fadeInAndOut(GetComponent<Image>(), true, 0.8f);
        yield return new WaitForSeconds(time);
        yield return fadeInAndOut(GetComponent<Image>(), false, 0.8f);
    }
    IEnumerator fadeInAndOut(Image targetImg, bool fadeIn, float duration)
    {
        //Set Values depending on if fadeIn or fadeOut
        float a, b;
        if (fadeIn)
        {
            a = minAlpha;
            b = maxAlpha;
        }
        else
        {
            a = maxAlpha;
            b = minAlpha;
        }

        Color currentColor = targetImg.color;
        float counter = 0f;

        while (counter < duration)
        {
            counter += Time.deltaTime;
            float alpha = Mathf.Lerp(a, b, counter / duration);

            targetImg.color = new Color(currentColor.r, currentColor.g, currentColor.b, alpha);
            yield return null;
        }
    }
}
