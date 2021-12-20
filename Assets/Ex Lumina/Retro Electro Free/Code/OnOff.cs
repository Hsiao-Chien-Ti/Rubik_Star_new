using UnityEngine;

// Generalized class that finds two child prefabs, "On" and "Off,"
// and activates/deactivates them, one active and one not.

// Either property can control the effect, with On = true and
// Off = false having same result (likewise for On = false and
// Off = true).

public class OnOff : MonoBehaviour
{
    GameObject onChild;
    GameObject offChild;

    public bool On
    {
        set
        {
            onChild.SetActive(value);
            offChild.SetActive(!value);
        }

        get => onChild.activeSelf;
    }

    public bool Off
    {
        set
        {
            onChild.SetActive(!value);
            offChild.SetActive(value);
        }

        get => offChild.activeSelf;
    }

    void Start()
    {
        onChild = transform.Find("On").gameObject;
        offChild = transform.Find("Off").gameObject;
    }
}
