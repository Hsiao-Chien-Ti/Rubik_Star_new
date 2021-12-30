using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class showLightning : MonoBehaviour
{
    // Start is called before the first frame update
    float timeStamp =0;
    bool started = false;
    public int showIdx = 0;
    public int hideIdx = 0;
    public int warnIdx = 0;
    public List<int> showTime;
    public List<int> hideTime;
    public List<int> warnTime;
    public GameObject lightningEnd;
    public showHideImg warning;
    public AudioSource lightningAudio;
    private void Start()
    {
        for(int i=0;i<showTime.Count;i++)
        {
            hideTime.Add(showTime[i]+5);
            warnTime.Add(showTime[i] -15);
        }
    }
    // Update is called once per frame
    void Update()
    {
        if (FindObjectOfType<CharacterMoving>() != null && !started)
        {
            timeStamp = Time.time;
            started = true;
        }
        if(started)
        {
            if(hideIdx>=hideTime.Count)
            {
                return;
            }
            if(!GetComponent<LineRenderer>().enabled)
            {
                if (Time.time - timeStamp > warnTime[warnIdx])
                {
                    warning.startProcedure();
                    warnIdx++;
                }
                else if (Time.time-timeStamp>showTime[showIdx])
                {
                    GetComponent<LineRenderer>().enabled = true;
                    lightningAudio.Play();
                    //lightningEnd.GetComponent<collectLigntning>().enabled = true;
                    showIdx++;
                }
            }
            else
            {
                if(Time.time-timeStamp>hideTime[hideIdx])
                {
                    GetComponent<LineRenderer>().enabled = false;
                    lightningAudio.Stop();
                    //lightningEnd.GetComponent<collectLigntning>().enabled = false;
                    hideIdx++;
                }
            }


        }
    }
}
