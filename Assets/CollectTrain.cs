using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CollectTrain : MonoBehaviour
{
    public Slider slider;
    public AudioSource source;
    public static bool first;
    public GameObject lightningTip;
    private void Start()
    {
        first = true;
    }
    private void OnTriggerEnter(Collider other)
    {
        if(first)
        {
            lightningTip.SetActive(true);
            first = false;
        }
        if (other.gameObject.CompareTag("Player"))
        {
            source.Play();
            slider.value += 1;
            Destroy(gameObject);
        }

    }
}
