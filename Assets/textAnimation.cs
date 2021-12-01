using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class textAnimation : MonoBehaviour
{
    public string text = "Please collect all the <color=#F7CB45ff>yellow</color> fragments and send them to the factory to help Adi repair his safety helmet...";
    public string[] separate_text;
    public AudioSource typingAudio;
    
    private void Start()
    {
        separate_text = text.Split(' ');
        //typingAudio.Play();
        StartCoroutine(Animate());
    }
    IEnumerator Animate()
    {
        yield return new WaitForSeconds(1f);

        int idx = 0;        
        typingAudio.Play();
        while(idx<separate_text.Length)
        {
            GetComponent<Text>().text += ' '+separate_text[idx];
            print(GetComponent<Text>().text);
            idx++;
            if(idx==separate_text.Length)
            {
                typingAudio.Pause();
            }
            yield return new WaitForSeconds(0.1f);
        }
        
        
    }
}
