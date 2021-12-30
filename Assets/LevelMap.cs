using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelMap : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnEnable()
    {
        for(int i=0;i<7;i++)
        {
            if(LevelMemory.memory[i])
            {
                transform.GetChild(i).gameObject.SetActive(true);
            }
        }
    }
}
