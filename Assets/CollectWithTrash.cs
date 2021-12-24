using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CollectWithTrash : MonoBehaviour
{
    public Slider slider;
    public AudioSource source;
    public showHideImg warning;
    public static int trash = 0;
    private void OnTriggerEnter(Collider other)
    {
        //print(other.gameObject.name);
        if (other.gameObject.CompareTag("Player"))
        {
            if(slider.value<slider.maxValue)
            {
                source.Play();
                slider.value += 1;
                if(gameObject.tag=="trash")
                {
                    trash++;
                }
                Destroy(gameObject);
            }
            else
            {
                warning.startProcedure();
            }

        }

    }
}
