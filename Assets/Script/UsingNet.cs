using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UsingNet : MonoBehaviour
{
    public Animator catchingStar;
    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            catchingStar.SetTrigger("UsingNet");
        }
    }
}
