using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenFoodGame : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject nowCam;
    public GameObject gameCam;
    public GameObject hamburger;
    public GameObject canvas;
    public GameObject rule;
    public GameObject score;
    public GameObject hungryText;
    void Start()
    {
        StartCoroutine(startGame());
    }
    IEnumerator startGame()
    {
        yield return new WaitForSeconds(5f);
        hungryText.SetActive(true);
        yield return new WaitForSeconds(2.25f);
        hungryText.SetActive(false);
        nowCam.SetActive(false);
        gameCam.SetActive(true);
        canvas.SetActive(true);
        yield return new WaitForSeconds(1f);
        rule.SetActive(false);
        score.SetActive(true);        
        hamburger.SetActive(true);
    }
}
