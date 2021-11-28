using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScaleTween : MonoBehaviour
{
    public GameObject x;
    public Automate cube;
    private void Start()
    {
        LeanTween.scale(gameObject, new Vector3(1, 1, 1), 0.5f);
        cube = FindObjectOfType<Automate>();
        
    }
    public void close()
    {
        LeanTween.scale(gameObject, new Vector3(0,0,0), 0.5f).setOnComplete(DestoryMe);
        cube.startShuffle = true;
        cube.Shuffle();
        
    }
    void DestoryMe()
    {
        Destroy(gameObject);
    }
    
}
