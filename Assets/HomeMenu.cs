using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HomeMenu : MonoBehaviour
{
    public GameObject quitDialog;
    public void startGame()
    {
        SceneManager.LoadScene("Level1_helmet");//之後改成播開場動畫
    }
    public void quitGame()
    {
        quitDialog.SetActive(true);
    }
}
