using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LightningCombine : MonoBehaviour
{
    public List<Transform> edges;
    bool finish = false;
    public GameObject emptyLightning;
    public GameObject fullLightning;
    public Slider slider;


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
            if(slider.value==5)
            {
                fullLightning.SetActive(true);
                emptyLightning.SetActive(false);
            }
            else
            {
                emptyLightning.SetActive(true);
                fullLightning.SetActive(false);
            }
        }
        else
        {
            emptyLightning.SetActive(false);
            fullLightning.SetActive(false);
        }

    }
}
