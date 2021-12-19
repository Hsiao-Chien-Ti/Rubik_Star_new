using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RocketCompose : MonoBehaviour
{
    public List<GameObject> hideObj;
    public List<GameObject> showObj;
    public List<GameObject> lateShowObj;
    public string nextSceneName;
    // Start is called before the first frame update
    public void show()
    {
        foreach (GameObject obj in hideObj)
        {
            obj.SetActive(false);
        }
        foreach (GameObject obj in showObj)
        {
            obj.SetActive(true);
        }
        StartCoroutine(showBtn());
    }
    IEnumerator showBtn()
    {
        yield return new WaitForSeconds(2f);
        foreach (GameObject obj in lateShowObj)
        {
            obj.SetActive(true);
        }
    }
    public void loadNext()
    {
        SceneManager.LoadScene(nextSceneName);
    }

}
