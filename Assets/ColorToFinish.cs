    using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorToFinish : MonoBehaviour
{
    public static int[] finish=new int[6];
    public GameObject levelController;
    private void LateUpdate()
    {
        if(finish[0]* finish[1]* finish[2]* finish[3]* finish[4]* finish[5]!=0)
        {
            levelController.GetComponent<NextLevel>().hide();
        }
    }
}
