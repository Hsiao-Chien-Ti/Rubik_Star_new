using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScaleTween : MonoBehaviour
{
    public GameObject x;
    public GameObject text;
    public Automate cube;
    private void Start()
    {
        LeanTween.scale(gameObject, new Vector3(1, 1, 1), 1f);
        cube = FindObjectOfType<Automate>();
        text.SetActive(true);
        
    }
    public void close()
    {
        transform.GetChild(1).GetComponent<AudioSource>().Pause();
        LeanTween.scale(gameObject, new Vector3(0,0,0), 0.5f).setOnComplete(DestoryMe);
        cube.startShuffle = true;
        cube.Shuffle();
    }
    void DestoryMe()
    {
        Destroy(gameObject);
    }
    
}


