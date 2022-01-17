using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fractureDestroy : MonoBehaviour
{
    Vector3 initPos;
    Quaternion initRot;
    // Start is called before the first frame update
    void Awake()
    {
        initPos = transform.localPosition;
        initRot = transform.localRotation;
        //print(initPos);
    }
    private void OnDisable()
    {
        //print(transform.localPosition);
        transform.localPosition = initPos;
        transform.localRotation = initRot;
    }
}
