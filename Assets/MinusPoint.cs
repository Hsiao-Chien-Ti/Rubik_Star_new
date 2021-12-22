using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MinusPoint : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.GetComponent<foodDrop>().collided)
            FoodCount.score -= other.gameObject.GetComponent<foodDrop>().point;
    }
}
