using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScaleTween : MonoBehaviour
{
    public GameObject x;
    public GameObject text;
    public Automate cube;
    public List<GameObject> showObj;
    private void Start()
    {
        LeanTween.scale(gameObject, new Vector3(1, 1, 1), 1f);
        text.SetActive(true);
        
    }
    public void close()
    {
        transform.GetChild(1).GetComponent<AudioSource>().Pause();
        foreach(GameObject obj in showObj)
        {
            obj.SetActive(true);
        }
        LeanTween.scale(gameObject, new Vector3(0,0,0), 0.5f).setOnComplete(DestoryMe);
        cube.startShuffle = true;
        cube.Shuffle();
    }
    void DestoryMe()
    {
        Destroy(gameObject);
    }
    
}


