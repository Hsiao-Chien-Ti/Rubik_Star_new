using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CollectWithTrash : MonoBehaviour
{
    public Slider slider;
    public AudioSource source;
    public GameObject warning;
    public static int trash = 0;
    public Material trashMat;
    private void OnTriggerEnter(Collider other)
    {
        //print(other.gameObject.name);
        if (other.gameObject.CompareTag("Player"))
        {
            if(slider.value<slider.maxValue)
            {
                source.Play();
                slider.value += 1;
                if(gameObject.CompareTag("trash"))
                {
                    trash++;
                }
                Destroy(gameObject);
            }
            else if(trash!=0)
            {
                
                warning.SetActive(true);
                LeanTween.alphaCanvas(warning.GetComponent<CanvasGroup>(), 1, 1f);
                LeanTween.alphaCanvas(warning.GetComponent<CanvasGroup>(), 0, 1f).setDelay(2f);
                trashMat.EnableKeyword("_EMISSION");
                StartCoroutine(trashGlow());
                
            }

        }

    }
    IEnumerator trashGlow()
    {
        trashMat.SetColor("_EmissionColor", new Color(0,90f/255,0));
        yield return new WaitForSeconds(0.4f);
        trashMat.SetColor("_EmissionColor", new Color(0, 0, 0));
        yield return new WaitForSeconds(0.4f);
        trashMat.SetColor("_EmissionColor", new Color(0, 90f / 255, 0));
        yield return new WaitForSeconds(0.4f);
        trashMat.SetColor("_EmissionColor", new Color(0, 0, 0));

    }
}
