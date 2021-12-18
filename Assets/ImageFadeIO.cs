using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ImageFadeIO : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(callFadeIO());
    }
    IEnumerator callFadeIO()
    {
        yield return imagefadeInAndOut(GetComponent<Image>(), true, 1f);
        yield return imagefadeInAndOut(GetComponent<Image>(), false, 1f);
    }

    IEnumerator imagefadeInAndOut(Image image, bool fadeIn, float duration)
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

        Color currentColor = image.color;
        float counter = 0f;

        while (counter < duration )
        {
            counter += Time.deltaTime;
            float alpha = Mathf.Lerp(a, b, counter / duration);

            image.color = new Color(currentColor.r, currentColor.g, currentColor.b, alpha);
            yield return null;
        }
    }

}
