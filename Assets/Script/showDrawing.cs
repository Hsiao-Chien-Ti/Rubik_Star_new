using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class showDrawing : MonoBehaviour
{
    public GameObject drawing;
    public List<GameObject> hideObj;
    // Start is called before the first frame update
    public void show()
    {
        foreach(GameObject obj in hideObj)
        {
            obj.SetActive(false);
        }
        drawing.SetActive(true);
    }


    // Update is called once per frame
    void Update()
    {
        
    }
}
