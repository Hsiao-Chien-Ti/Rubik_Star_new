using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorToCube : MonoBehaviour
{
    public List<GameObject> showObj;
    public List<GameObject> hideObj;
    public GameObject cube;
    public GameObject player;
    public GameObject rocket;
    public AudioSource background;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(back());
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    IEnumerator back()
    {
        player.GetComponent<FaceUp>().enabled = false;
        rocket.GetComponent<WantRocket>().enabled = false;
        background.Pause();
        yield return new WaitForSeconds(6f);
        foreach (GameObject obj in showObj)
        {
            obj.SetActive(true);
        }
        cube.GetComponent<ChangeColor>().change();
        background.Play();
        foreach (GameObject obj in hideObj)
        {
            obj.SetActive(false);
        }


        
    }
}
