using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformCombine : MonoBehaviour
{
    public Transform edge1;
    public Transform edge2;
    public GameObject he;
    public GameObject re;
    public static bool finish = true;
    private void Update()
    {
        if(Vector3.Distance(edge1.position,edge2.position)<=0.05)
        {
            he.SetActive(true);
            re.SetActive(true);
            finish = true;
        }
        else
        {
            he.SetActive(false);
            re.SetActive(false);
            finish = false;
        }
    }
}
