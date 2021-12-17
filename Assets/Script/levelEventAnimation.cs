using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class levelEventAnimation : MonoBehaviour
{
    public bool closed = false;
    public GameObject player;
    public List<GameObject> hideObj;
    // Start is called before the first frame update
    void Start()
    {
        player.SetActive(false);
        foreach(GameObject obj in hideObj)
        {
            obj.transform.localScale = new Vector3(0, 0, 0);
        }
        LeanTween.scale(gameObject, new Vector3(1, 1, 1), 1f).setIgnoreTimeScale(true);
        Time.timeScale = 0;
        
        //close();
    }
    public void close()
    {
        foreach (GameObject obj in hideObj)
        {
            obj.transform.localScale = new Vector3(1, 1, 1);
        }
        player.SetActive(true);
        Time.timeScale = 1;
        LeanTween.scale(gameObject, new Vector3(0, 0, 0), 0.5f);
        closed=true;
        //DestoryMe();
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
