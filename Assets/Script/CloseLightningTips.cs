using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloseLightningTips : MonoBehaviour
{
    public List<GameObject> showObj;
    // Start is called before the first frame update
    void Start()
    {
        GetComponent<showHideImg>().show();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void close()
    {
        foreach(GameObject obj in showObj)
        {
            obj.SetActive(true);
        }
        gameObject.SetActive(false);
    }
}
