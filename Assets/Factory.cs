using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Factory : MonoBehaviour
{
    public Slider helmetSlider;
<<<<<<< HEAD
<<<<<<< HEAD
<<<<<<< HEAD
    public Text txt;
=======
>>>>>>> 68fc3cd4d5bcce476f9de203860bbaaefc93e534
=======
>>>>>>> 68fc3cd4d5bcce476f9de203860bbaaefc93e534
=======
>>>>>>> 68fc3cd4d5bcce476f9de203860bbaaefc93e534
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
            if(helmetSlider.value==8)
            {
                print("level up");
            }
            else
            {
<<<<<<< HEAD
<<<<<<< HEAD
<<<<<<< HEAD
                showToast("Collect more!!!!!!!", 1);
            }
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
=======
=======
>>>>>>> 68fc3cd4d5bcce476f9de203860bbaaefc93e534
=======
>>>>>>> 68fc3cd4d5bcce476f9de203860bbaaefc93e534
                print("collect more!");
            }
        }
    }
<<<<<<< HEAD
<<<<<<< HEAD
>>>>>>> 68fc3cd4d5bcce476f9de203860bbaaefc93e534
=======
>>>>>>> 68fc3cd4d5bcce476f9de203860bbaaefc93e534
=======
>>>>>>> 68fc3cd4d5bcce476f9de203860bbaaefc93e534
}
