using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Level5Opengame : MonoBehaviour
{
    // Start is called before the first frame update
    public showDrawing levelController;
    public Text line1;
    public Text line2;
    void Start()
    {
        StartCoroutine(playAnim());
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    IEnumerator playAnim()
    {
        yield return new WaitForSeconds(5f);
        yield return fadeInAndOut(line1, true, 0.7f);
        yield return new WaitForSeconds(0.5f);
        yield return fadeInAndOut(line2, true, 0.7f);
        yield return new WaitForSeconds(2f);
        line1.gameObject.transform.parent.gameObject.SetActive(false);
        levelController.show();
    }
    IEnumerator fadeInAndOut(Text targetText, bool fadeIn, float duration)
    {
        //Set Values depending on if fadeIn or fadeOut
        float a, b;
        if (fadeIn)
        {
            a = 0f;
            b = 1f;
        }
        else
        {
            a = 1f;
            b = 0f;
        }

        Color currentColor = targetText.color;
        float counter = 0f;

        while (counter < duration)
        {
            counter += Time.deltaTime;
            float alpha = Mathf.Lerp(a, b, counter / duration);

            targetText.color = new Color(currentColor.r, currentColor.g, currentColor.b, alpha);
            yield return null;
        }
    }
}
