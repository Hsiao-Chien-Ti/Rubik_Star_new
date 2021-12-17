using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level3_hammer_hit : MonoBehaviour
{
    public Animator anim;
    public GameObject cube;
    public GameObject metalPlate;
    public List<GameObject> hideObj;
    public GameObject platform;
    float height;
    public Material newMaterial;
    public bool finish=false;
    // Start is called before the first frame update
    void Start()
    {
        height = cube.transform.localScale.y;   
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Return)&&height>=0.2f)
        {
            anim.SetTrigger("Hit");
            Vector3 scale = cube.transform.localScale;
            scale.y *= 0.8f;
            cube.transform.localScale =scale;
            height *= 0.8f;
        }
        if(height<0.2f&&!finish)
        {
            //cube.SetActive(false);
            //metalPlate.SetActive(true);
            cube.GetComponent<Renderer>().material = newMaterial;
            cube.GetComponent<Animator>().enabled = true;
            finish = true;
            StartCoroutine(close());

        }
    }
    IEnumerator close()
    {
        yield return new WaitForSeconds(1.1f);
        cube.SetActive(false);
        foreach (GameObject obj in hideObj)
        {
            obj.SetActive(true);
        }
        platform.SetActive(false);
        gameObject.SetActive(false);
    }
}
