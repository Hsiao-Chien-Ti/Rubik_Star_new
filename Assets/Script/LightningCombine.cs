using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LightningCombine : MonoBehaviour
{
    public List<Transform> edges;
    public static bool finish = false;
    public GameObject lightningImg;


    // Update is called once per frame
    void Update()
    {
        for(int i=0;i<4;i++)
        {
            if(Vector3.Distance(edges[i].position, edges[7-i].position) >= 0.05)
            {
                finish = false;
                break;
            }
            if (i == 3)
                finish = true;
        }
        if(finish)
        {
            lightningImg.SetActive(true);
        }
        else
        {
            lightningImg.SetActive(false);
        }

    }
}
