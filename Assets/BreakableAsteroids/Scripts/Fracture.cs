using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fracture : MonoBehaviour
{
    [Tooltip("\"Fractured\" is the object that this will break into")]
    public GameObject fractured;
    GameObject fracture;

    public void FractureObject()
    {
        //GetComponent<MeshRenderer>().enabled = false;
        //GetComponent<MeshCollider>().enabled = false;
        //GameObject piece =Instantiate(fractured, transform.position, transform.rotation); //Spawn in the broken version
        fracture = FractionPool.SharedInstance.GetPooledObject();
        if (fracture != null)
        {
            fracture.transform.position = transform.position;
            fracture.transform.rotation = transform.rotation;
            fracture.transform.localScale = transform.localScale;
            fracture.SetActive(true);
            StartCoroutine(disableFrac());
            //GetComponent<MeshRenderer>().enabled = false;
            //GetComponent<MeshCollider>().enabled = false;
        }


        //Destroy(gameObject); //Destroy the object to stop it getting in the way

        //Destroy(piece, 0.7f);
    }
    IEnumerator disableFrac()
    {
        yield return new WaitForSeconds(0.7f);
        fracture.SetActive(false);
        gameObject.SetActive(false);
    }
}
