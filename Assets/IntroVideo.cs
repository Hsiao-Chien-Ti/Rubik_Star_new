using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;
using UnityEngine.SceneManagement;

public class IntroVideo : MonoBehaviour
{
    float time=0;
    // Start is called before the first frame update
    void Start()
    {
        RenderTexture.active = GetComponent<VideoPlayer>().targetTexture;
        GL.Clear(true, true, Color.clear);
        RenderTexture.active = null;
        time = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        if (!GetComponent<VideoPlayer>().isPlaying&&Time.time-time>1f)
        {
            SceneManager.LoadScene(1);
        }
    }
}
