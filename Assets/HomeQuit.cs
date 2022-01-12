using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HomeQuit : MonoBehaviour
{
    public void yes()
    {
        Application.Quit();
    }
    public void no()
    {
        gameObject.SetActive(false);
    }
}
