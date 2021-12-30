using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelMemory : MonoBehaviour
{   public static bool[] memory=new bool[8];
    private static LevelMemory lm;
    // Start is called before the first frame update
    void Awake()
    {
        DontDestroyOnLoad(this);
        if (lm== null)
        {
            lm = this;
        }
        else
        {
            Destroy(gameObject);
        }
        for(int i=0;i<8;i++)
        {
            memory[i] = false;
        }
        memory[0] = true;
    }
    
    // Update is called once per frame
    void Update()
    {
        
    }
}
