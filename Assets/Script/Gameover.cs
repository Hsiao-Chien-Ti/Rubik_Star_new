using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Gameover : MonoBehaviour
{
    public GameObject buttonCanvas;
    public GameObject astronaut;
    public AudioSource source;
    public AudioClip cryclip;
    public AudioClip flatclip;
    public List<GameObject> invisible = new List<GameObject>();
    public bool resetCam=false;
    public GameObject mainCam;
    public GameObject sateCam;
    //public Animator anim;
    public FractionPool fpool;
    private void Start()
    {
        fpool = GameObject.FindObjectOfType<FractionPool>();
        foreach (GameObject obj in fpool.pooledObjects)
        {
            invisible.Add(obj);
        }
    }
    public void hide()
    {
        if(resetCam)
        {
            sateCam.SetActive(false);
            mainCam.SetActive(true);
        }
        foreach (GameObject obj in invisible)
        {
            obj.SetActive(false);
        }
        StartCoroutine(anim());
    }
    IEnumerator anim()
    {
        source.clip = cryclip;
        source.Play();
        astronaut.SetActive(true);
        yield return new WaitForSeconds(3f);
        source.clip = flatclip;
        source.Play();
        buttonCanvas.SetActive(true);
    }
    public void restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    public void loadHome()
    {
        SceneManager.LoadScene("HomeMenu");
    }
}
