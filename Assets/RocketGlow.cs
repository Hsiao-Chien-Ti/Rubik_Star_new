using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class RocketGlow : MonoBehaviour
{
    public Material rocketMat;
    bool first=true;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(GetComponent<Slider>().value==GetComponent<Slider>().maxValue&&CollectWithTrash.trash==0)
        {
            rocketMat.EnableKeyword("_EMISSION");
            if(first)
            {
                StartCoroutine(rocketGlow());
                first = false; 
            }

        }
    }
    IEnumerator rocketGlow()
    {
        rocketMat.SetColor("_EmissionColor", new Color(255/255,138/255,0));
        yield return new WaitForSeconds(0.4f);
        rocketMat.SetColor("_EmissionColor", new Color(0, 0, 0));
        yield return new WaitForSeconds(0.4f);
        rocketMat.SetColor("_EmissionColor", new Color(255 / 255, 138 / 255, 0));
        yield return new WaitForSeconds(0.4f);
        rocketMat.SetColor("_EmissionColor", new Color(0, 0, 0));

    }
}
