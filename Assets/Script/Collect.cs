using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Collect : MonoBehaviour
{
    public Slider slider;
    public AudioSource source;
    private void OnTriggerEnter(Collider other)
    {
        //print(other.gameObject.name);
        if (other.gameObject.CompareTag("Player"))
        {
            source.Play();
            slider.value += 1;
            Destroy(gameObject);
        }

    }
    //private void OnTriggerEnter(Collision collision)
    //{
    //    print(collision.gameObject.name);
    //    if(collision.gameObject.CompareTag("Player"))
    //    {
    //        slider.value += 1;
    //        Destroy(gameObject);
    //    }
    //}
}
