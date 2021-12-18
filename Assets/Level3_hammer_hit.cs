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
    public Animator playerAnim;
    public GameObject net;
    // Start is called before the first frame update
    void Start()
    {
        height = cube.transform.localScale.y;
        foreach (GameObject obj in hideObj)
        {
            obj.SetActive(false);
        }
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
            finish = true;
            cube.GetComponent<Renderer>().material = newMaterial;
            cube.GetComponent<Animator>().enabled = true;
            
            StartCoroutine(close());

        }
    }
    IEnumerator close()
    {
        print(Time.time);
        yield return new WaitForSeconds(1.1f);
        print(Time.time);
        platform.SetActive(false);
        cube.SetActive(false);
        foreach (GameObject obj in hideObj)
        {
            obj.SetActive(true);
        }
        playerAnim.SetBool("IsBattery", true);
        playerAnim.SetTrigger("PickupBattery");
        metalPlate.SetActive(true);
        net.SetActive(false);
        gameObject.SetActive(false);
        
    }
}
