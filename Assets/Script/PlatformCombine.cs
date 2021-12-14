using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformCombine : MonoBehaviour
{
    public Transform edge1;
    public Transform edge2;
    public List<GameObject> show;
    public static bool finish = true;
    private void Update()
    {
        //print(Vector3.Distance(edge1.position, edge2.position));
        if(Vector3.Distance(edge1.position,edge2.position)<=0.05)
        {
            foreach(GameObject obj in show)
            {
                obj.SetActive(true);
            }
            finish = true;
        }
        else
        {
            foreach (GameObject obj in show)
            {
                obj.SetActive(false);
            }
            finish = false;
        }
    }
}
