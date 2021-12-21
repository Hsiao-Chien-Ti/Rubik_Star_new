using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAtSate : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject drawing;
    void Start()
    {
        GetComponent<Animator>().Play("Base Layer.lookSatel");
        drawing.SetActive(true);
    }

    
}
