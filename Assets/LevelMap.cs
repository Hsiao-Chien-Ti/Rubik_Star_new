using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelMap : MonoBehaviour
{
    public int lm=0;
    // Start is called before the first frame update
    void Start()
    {
        //PlayerPrefs.DeleteAll();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnEnable()
    {
        lm=PlayerPrefs.GetInt("LevelMap");
        for (int i = 0; i <= lm; i++)
        {
            transform.GetChild(i).gameObject.SetActive(true);
        }
    }
}
