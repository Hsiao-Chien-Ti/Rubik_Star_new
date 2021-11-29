using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidHit : MonoBehaviour
{
    public GameObject timer;
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.layer==11)
        {
            timer.GetComponent<Timer>().remainingDuration -= 2;
        }
    }
}
