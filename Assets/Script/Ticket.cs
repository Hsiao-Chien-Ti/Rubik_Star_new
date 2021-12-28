using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ticket : MonoBehaviour
{
    public List<GameObject> tickets;
    public GameObject station;
    public bool active = false;
    public bool finish = false;
    public List<Transform> edges;
    public Transform center;
    public IEnumerator show(float delay)
    {
        yield return new WaitForSeconds(delay);
        foreach(GameObject ticket in tickets)
        {
            ticket.SetActive(true);
        }
        active = true;
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(active)
        {
            //for (int i = 0; i <= 7; i++)
            //{
            //    if (Vector3.Distance(edges[2 * i].position, edges[2 * i + 1].position) > 0.05)
            //    {
            //        finish = false;
            //        break;
            //    }
            //    if (i == 7 && (center.up - edges[0].up).magnitude < 0.05)
            //    {
            //        finish = true;
            //    }
            //}
            finish = true;
        }
        if(finish)
        {
            //station.transform.localScale = new Vector3(40, 40, 40);
            station.SetActive(true);
        }
        else
        {
            station.SetActive(false);
        }
    }
}
