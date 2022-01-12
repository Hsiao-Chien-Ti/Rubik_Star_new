using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EndFoodGame : MonoBehaviour
{
    public GameObject plate;
    public Text time;
    public GameObject next;
    public GameObject text;
    public GameObject timer;
    public GameObject score;
    public GameObject nowCam;
    public GameObject mainCam;
    public GameObject levelController;
    bool ended=false;
    private void Update()
    {
        if(transform.position.y<0&&!ended)
        {
            ended = true;
            end();
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if(!ended)
        {
            ended = true;
            end();
        }
    }
    void end()
    {
        plate.GetComponent<MoveDish>().enabled = false;
        score.SetActive(false);
        nowCam.transform.GetChild(0).gameObject.SetActive(false);
        timer.GetComponent<Timer>().duration = FoodCount.score;
        time.text = $"{FoodCount.score / 60:00}:{FoodCount.score % 60:00}";        
        text.SetActive(true);
        next.SetActive(true);
        time.gameObject.SetActive(true);
    }
    public void changeCamera()
    {
        score.transform.parent.gameObject.SetActive(false);
        nowCam.SetActive(false);
        mainCam.SetActive(true);
        levelController.GetComponent<showDrawing>().show();
        transform.parent.gameObject.SetActive(false);
    }
}
