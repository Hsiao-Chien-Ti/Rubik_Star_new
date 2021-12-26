using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HomeQuit : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void yes()
    {
        Application.Quit();
    }
    public void no()
    {
        gameObject.SetActive(false);
    }
}
