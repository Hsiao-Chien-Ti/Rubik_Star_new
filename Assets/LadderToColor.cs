using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LadderToColor : MonoBehaviour
{
    public List<GameObject> showObj;
    public List<GameObject> hideObj;
    public GameObject timer;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public IEnumerator climb()
    {
        yield return new WaitForSeconds(3.5f);
        timer.transform.GetChild(0).GetComponent<Image>().color = new Color(255f / 255, 143f / 255, 0);
        foreach (GameObject obj in showObj)
        {
            obj.SetActive(true);
        }
        foreach (GameObject obj in hideObj)
        {
            obj.SetActive(false);
        }
    }
}
