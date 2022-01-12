using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartLevel : MonoBehaviour
{
    public int level;
    public void startLevel()
    {
        SceneManager.LoadScene(level);
    }
}
