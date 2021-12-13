using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UnlockSkill : MonoBehaviour
{
    public GameObject buttonCanvas;
    public GameObject animPlayer;
    public AudioSource source;
    public AudioClip clip;
    public List<GameObject> invisible = new List<GameObject>();
    //public Animator anim;
    private void Start()
    {
        source.clip = clip;
        source.Play();
    }
    public void startLevel()
    {
        buttonCanvas.SetActive(false);
        animPlayer.SetActive(false);
        foreach (GameObject obj in invisible)
        {
            obj.SetActive(true);
        }
    }
}
