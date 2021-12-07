using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidHit : MonoBehaviour
{
    public GameObject timer;
    public int level;
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.layer==11)
        {
            if(level==1||(level!=1 && !GetComponent<HelmetDefend>().defending))
            {
               timer.GetComponent<Timer>().remainingDuration -= 2; 
            }
        }
    }
}
