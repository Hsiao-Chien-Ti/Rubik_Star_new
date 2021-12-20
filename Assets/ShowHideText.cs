using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI
;
public class ShowHideText : MonoBehaviour
{
    // Start is called before the first frame update
    public Image extra;
    public float time;
    void Start()
    {
        StartCoroutine(hideText());
    }
    IEnumerator hideText()
    {
        yield return new WaitForSeconds(time);
        yield return fadeInAndOut(GetComponent<Text>(), false, 0.5f);
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

        Color currentColor = targetText.color;
        float counter = 0f;

        while (counter < duration)
        {
            counter += Time.deltaTime;
            float alpha = Mathf.Lerp(a, b, counter / duration);

            targetText.color = new Color(currentColor.r, currentColor.g, currentColor.b, alpha);
            extra.color = new Color(extra.color.r, extra.color.g, extra.color.b, alpha);
            yield return null;
        }
    }
}
