using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Helmet : MonoBehaviour
{
    // Start is called before the first frame update
    private void OnEnable()
    {
        StartCoroutine(hatOff());
    }
    IEnumerator hatOff()
    {
        yield return new WaitForSeconds(2f);
        gameObject.SetActive(false);
    }
}
