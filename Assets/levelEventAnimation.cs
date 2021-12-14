using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class levelEventAnimation : MonoBehaviour
{
    public bool closed = false;
    // Start is called before the first frame update
    void Start()
    {
        LeanTween.scale(gameObject, new Vector3(10, 10, 10), 1f);
        close();
    }
    public void close()
    {
        LeanTween.scale(gameObject, new Vector3(0, 0, 0), 0.5f).setOnComplete(DestoryMe);
        closed=true;
    }
    public bool getClose()
    {
        return closed;
    }
    void DestoryMe()
    {
        Destroy(gameObject);
    }
}
