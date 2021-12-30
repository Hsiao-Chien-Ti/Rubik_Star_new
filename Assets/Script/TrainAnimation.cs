using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrainAnimation : MonoBehaviour
{
    public Transform target;
    public float liftSpeed;
    public List<GameObject> tracks;
    public GameObject train;
    public int level;
    Vector3 initPos;
    public NextLevel levelController;
    // Start is called before the first frame update

    void Start()
    {
        initPos = transform.position;
    }
    private void OnEnable()
    {
        StartCoroutine(showObj());
    }
    public IEnumerator showObj()
    {
        while (Vector3.Distance(transform.position, target.position) > 0.001)
        {
            transform.position = Vector3.MoveTowards(transform.position, target.position, liftSpeed);
            yield return null;
        }
        for (int i=0;i<tracks.Count;i++)
        {
            yield return new WaitForSeconds(0.2f);
            tracks[i].SetActive(true);
        }
        yield return new WaitForSeconds(0.4f);
        train.SetActive(true);
        if (level==5)
        {
            yield return new WaitForSeconds(2f);
            levelController.gameObject.GetComponent<ShowTrainAnim>().enabled = false;
            levelController.hide();
            Destroy(gameObject);
        }
    }
    public void OnDisable()
    {
        transform.position = initPos;
        for (int i = 0; i < tracks.Count; i++)
        {
            tracks[i].SetActive(false);
        }
        train.SetActive(false);
    }

}
