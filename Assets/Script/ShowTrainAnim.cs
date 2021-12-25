using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShowTrainAnim : MonoBehaviour
{
    public List<GameObject> hideObj;
    public GameObject train;
    public RotateBigCube cubeRotator;
    public collectLigntning lightning;
    public List<Slider> sliders;
    public List<float> sliderValue;
    // Start is called before the first frame update

    // Update is called once per frame
    void Update()
    {
        for (int i = 0; i < sliderValue.Count; i++)
        {
            if (sliders[i].value != sliderValue[i])
            {
                break;
            }
            if (i == sliderValue.Count - 1)
            {
                if(lightning.power==4)
                {
                    foreach (GameObject obj in hideObj)
                    {
                        obj.SetActive(false);
                    }
                    StartCoroutine(show());
                    
                }
            }
        }
    }
    IEnumerator show()
    {
        yield return new WaitUntil(cubeRotator.RotateToTrail);
        train.SetActive(true);
    }
}
