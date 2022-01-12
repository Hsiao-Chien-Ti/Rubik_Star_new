using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class showStair : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(fadeIn());
    }

    IEnumerator fadeIn()
    {
       Material[] mat = new Material[3];
        while(true)
        {
            
            mat= GetComponent<Renderer>().materials;
            for(int i=0;i<3;i++)
            {
                mat[i].color = new Color(mat[i].color.r, mat[i].color.g, mat[i].color.b, mat[i].color.a + 0.2f * Time.deltaTime);
            }
            if(mat[0].color.a>=1)
            {
                break;
            }
            yield return null;
        }
    }
}
