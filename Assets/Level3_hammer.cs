using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class Level3_hammer : MonoBehaviour
{
    public List<Slider> sliders;
    public List<float> sliderValue;
    public Text txt;
    public GameObject levelController;
    public List<GameObject> hideObj;
    public GameObject platform;
    public GameObject hammer;
    public GameObject cube;
    //public GameObject plate;
    private void Start()
    {
        levelController = GameObject.Find("LevelController");
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            for (int i = 0; i < sliderValue.Count; i++)
            {
                if (sliders[i].value != sliderValue[i])
                {
                    showToast("Collect more!!!!!", 1);
                    break;
                }
                if (i == sliderValue.Count - 1)
                {
                    platform.SetActive(true);
                    hammer.SetActive(true);
                    cube.SetActive(true);
                    foreach (GameObject obj in hideObj)
                    {
                        obj.SetActive(false);
                    }
                    //cube.GetComponent<Animator>().enabled = true;
                    GetComponent<Level3_hammer>().enabled = false;
                    //levelController.GetComponent<NextLevel>().hide();
                }
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
}
