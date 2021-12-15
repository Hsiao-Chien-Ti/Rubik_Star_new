using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CatchingStar : MonoBehaviour
{
    public GameObject timer;
    private void OnTriggerEnter(Collider other)
    {
        //print(other.gameObject.name);
        if (other.gameObject.CompareTag("Star"))
        {
            //print("catch");
            Destroy(other.gameObject);
            timer.GetComponent<Timer>().remainingDuration += 10;
            //print(timer.GetComponent<Timer>().remainingDuration);
            StartCoroutine(timeColor());
        }
    }
    IEnumerator timeColor()
    {
        
        timer.transform.GetChild(0).GetComponent<Image>().color = Color.green;
        yield return new WaitForSeconds(1f);
        timer.transform.GetChild(0).GetComponent<Image>().color = new Color(255f / 255, 143f / 255, 0);
    }
}
