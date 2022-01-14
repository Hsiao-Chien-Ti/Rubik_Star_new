using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class NextLevel : MonoBehaviour
{
    public GameObject buttonCanvas;
    public GameObject finishObj;
    public AudioSource source;
    public AudioClip clip;
    public List<GameObject> invisible = new List<GameObject>();
    public string nextSceneName;
    public FractionPool fpool;
    //public Animator anim;
    private void Start()
    {
        fpool = GameObject.FindObjectOfType<FractionPool>();
        foreach(GameObject obj in fpool.pooledObjects)
        {
            invisible.Add(obj);
        }
    }
    public void hide()
    {
        int idx = SceneManager.GetActiveScene().buildIndex;
        if(idx>PlayerPrefs.GetInt("LevelMap"))
        {
            PlayerPrefs.SetInt("LevelMap", idx);
        }
        //LevelMap.lm=Mathf.Max(LevelMap.lm,idx);
        foreach(GameObject obj in invisible)
        {
            obj.SetActive(false);
        }
        StartCoroutine(rotation());
    }
    IEnumerator rotation()
    {
        source.clip = clip;
        source.Play();
        finishObj.SetActive(true);
        yield return new WaitForSeconds(1f);
        buttonCanvas.SetActive(true);
    }
    public void loadNext()
    {

        SceneManager.LoadScene(nextSceneName);
    }
    public void loadHome()
    {
        SceneManager.LoadScene("HomeMenu");
    }
}
