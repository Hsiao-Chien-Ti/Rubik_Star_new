using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FoodCount : MonoBehaviour
{
    public Text scoreText;
    RaycastHit[] hits;
    public LayerMask foodLayer;
    public static int score = 0;
    private void Update()
    {
        //score = 0;
        //hits = Physics.RaycastAll(transform.position, transform.up, foodLayer);
        //Debug.DrawRay(transform.position, transform.up * 1000, Color.green);
        //foreach(RaycastHit hit in hits)
        //{
        //    if(hit.collider.gameObject.GetComponent<foodDrop>().collided)
        //        score += hit.collider.gameObject.GetComponent<foodDrop>().point;
        //}
        //score = Mathf.Max(score, 0);
        
    }
    private void LateUpdate()
    {
        score = Mathf.Max(score, 0);
        scoreText.text = "Score:"+score;
    }

}
