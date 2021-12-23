using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CollectWithTrash : MonoBehaviour
{
    public Slider slider;
    public AudioSource source;
    public showHideImg warning;
    private void OnTriggerEnter(Collider other)
    {
        //print(other.gameObject.name);
        if (other.gameObject.CompareTag("Player"))
        {
            if(slider.value<slider.maxValue)
            {
                source.Play();
                slider.value += 1;
                Destroy(gameObject);
            }
            else
            {
                warning.startProcedure();
            }

        }

    }
}
