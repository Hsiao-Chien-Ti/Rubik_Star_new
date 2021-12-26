using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeColor : MonoBehaviour
{
    public List<Material> mats;
    public List<GameObject> front;
    public List<GameObject> back;
    public List<GameObject> up;
    public List<GameObject> down;
    public List<GameObject> left;
    public List<GameObject> right;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.K))
        {
            for(int i=0;i<26;i++)
            {
                front[i].transform.GetChild(0).GetComponent <Renderer>().material= mats[0];
                back[i].transform.GetChild(0).GetComponent<Renderer>().material = mats[1];
                up[i].transform.GetChild(0).GetComponent<Renderer>().material = mats[2];
                down[i].transform.GetChild(0).GetComponent<Renderer>().material = mats[3];
                left[i].transform.GetChild(0).GetComponent<Renderer>().material = mats[4];
                right[i].transform.GetChild(0).GetComponent<Renderer>().material = mats[5];
            }
        }
    }
}
