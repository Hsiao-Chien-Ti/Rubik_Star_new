using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level5Opengame : MonoBehaviour
{
    // Start is called before the first frame update
    public showDrawing levelController;
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
        yield return new WaitForSeconds(7f);
        levelController.show();
    }
}
