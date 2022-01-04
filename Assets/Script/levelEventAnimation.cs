using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class levelEventAnimation : MonoBehaviour
{
    public bool closed = false;
    public GameObject player;
    public List<GameObject> hideObj;
    public AudioSource backgroundAudio;
    // Start is called before the first frame update
    void Start()
    {
        RenderTexture.active = GetComponent<VideoPlayer>().targetTexture;
        GL.Clear(true, true, Color.clear);
        RenderTexture.active = null;
        gameObject.GetComponent<VideoPlayer>().SetDirectAudioMute(0, false);
        player.SetActive(false);
        foreach(GameObject obj in hideObj)
        {
            obj.SetActive(false);
        }
        backgroundAudio.Pause();
        LeanTween.scale(gameObject, new Vector3(1, 1, 1), 1f).setIgnoreTimeScale(true);
        Time.timeScale = 0;
        
        //close();
    }
    public void close()
        {
            //gameObject.GetComponent<VideoPlayer>().targetTexture.Release();
        print("close");
        foreach (GameObject obj in hideObj)
        {
            obj.SetActive(true);
        }
        player.SetActive(true);
        Time.timeScale = 1;
        //GL.Clear(true, true, Color.clear);
        gameObject.GetComponent<VideoPlayer>().SetDirectAudioMute(0, true);
        backgroundAudio.Play();
        LeanTween.scale(gameObject, new Vector3(0, 0, 0), 0.5f);
        
        closed=true;
        //DestoryMe();
    }
    public bool getClose()
    {
        return closed;
    }
    void DestoryMe()
    {
        Destroy(gameObject);
    }
}
