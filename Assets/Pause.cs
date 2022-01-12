using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Pause : MonoBehaviour
{
    public static bool muted=false;
    public GameObject pausePanel;
    public void ShowPanel()
    {
        Time.timeScale = 0;
        pausePanel.SetActive(true);
    }
    public void Resume()
    {
        Time.timeScale = 1;
        pausePanel.SetActive(false);
    }

    public void Restart()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void LoadHome()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("HomeMenu");
    }

    public void Mute()
    {
        if(!muted)
        {
            AudioListener.volume = 0f;
            muted = true;
        }
        else
        {
            AudioListener.volume = 1f;
            muted = false;
        }
    }
}
