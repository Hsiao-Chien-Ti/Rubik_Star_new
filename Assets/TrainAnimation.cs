using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrainAnimation : MonoBehaviour
{
    public Transform target;
    public float liftSpeed;
    public List<GameObject> tracks;
    public GameObject train;
    bool first = true;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Vector3.Distance(transform.position,target.position)>0.001)
        {
            transform.position = Vector3.MoveTowards(transform.position, target.position, liftSpeed);
        }
        else
        {
            if(first)
            {
                StartCoroutine(showObj());
            }
            first = false;
        }
    }
    IEnumerator showObj()
    {
        for(int i=0;i<tracks.Count;i++)
        {
            yield return new WaitForSeconds(0.2f);
            tracks[i].SetActive(true);
        }
        yield return new WaitForSeconds(0.4f);
        train.SetActive(true);
    }
}
