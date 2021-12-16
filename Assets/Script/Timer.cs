using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    public Image fill;
    public Text time;
    public GameObject levelController;

    public int duration;
    public int remainingDuration;
    // Start is called before the first frame update
    void Start()
    {
        levelController = GameObject.Find("LevelController");
        Being(duration);
    }
    void Being(int second)
    {
        remainingDuration = second;
        StartCoroutine(UpdateTimer());
        
    }
    IEnumerator UpdateTimer()
    {
        while(remainingDuration>=0)
        {
            time.text = $"{remainingDuration / 60:00}:{remainingDuration % 60:00}";
            fill.fillAmount = Mathf.InverseLerp(0, duration, remainingDuration);
            remainingDuration--;
            if(remainingDuration<10)
            {
                time.color = Color.red;
            }
            yield return new WaitForSeconds(1f);
        }
        levelController.GetComponent<Gameover>().hide();
    }
}
