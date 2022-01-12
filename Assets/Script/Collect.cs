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
        if (other.gameObject.CompareTag("Player"))
        {
            source.Play();
            slider.value += 1;
            Destroy(gameObject);
        }

    }
}
