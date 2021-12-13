using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CatchingStar : MonoBehaviour
{
    public GameObject timer;
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Star"))
        {
            Destroy(other.gameObject);
            timer.GetComponent<Timer>().remainingDuration += 2;
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
