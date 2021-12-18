using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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
                //timer.transform.GetChild(0).GetComponent<Image>().color = Color.red;
                timer.GetComponent<Timer>().remainingDuration -= 10;
                StartCoroutine(timeColor());
            }
        }
    }
    IEnumerator timeColor()
    {
        timer.transform.GetChild(0).GetComponent<Image>().color = Color.red;
        yield return new WaitForSeconds(1f);
        timer.transform.GetChild(0).GetComponent<Image>().color = new Color(255f/255,143f/255,0);
    }
}
