using UnityEngine;

public class On : MonoBehaviour
{
    public GameObject[] prefabs;

    OnOff[] onOffs;

    // Start is called before the first frame update
    void Start()
    {
        onOffs = new OnOff[prefabs.Length];

        for (int i = 0; i < prefabs.Length; ++i)
        {
            onOffs[i] = prefabs[i].GetComponent<OnOff>();
        }
    }

    private void OnMouseDown()
    {
        foreach (OnOff onOff in onOffs)
        {
            onOff.On = true;
        }
    }
}