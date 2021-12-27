using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCFlyout : MonoBehaviour
{
    bool fly = false;
    public Vector3 initPos;
    public Vector3 finalPos;
    private void OnEnable()
    {
        fly = true;
    }
    private void OnDisable()
    {
        fly = false;
        transform.localPosition = initPos;
        
    }

    // Update is called once per frame
    void Update()
    {
        if(fly)
        {
            transform.localPosition = Vector3.MoveTowards(transform.localPosition, finalPos, 0.2f);
        }
    }
}
