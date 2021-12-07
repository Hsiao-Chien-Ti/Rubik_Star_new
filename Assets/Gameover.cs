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
    //public Animator anim;
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Z))
        {
            hide();
        }
    }
    public void hide()
    {
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
}
