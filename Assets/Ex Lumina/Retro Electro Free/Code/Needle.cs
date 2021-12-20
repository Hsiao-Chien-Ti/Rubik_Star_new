using System.Collections;
using UnityEngine;

// Rotate the ammeter needle.

public class Needle : MonoBehaviour
{
    // Scale "amps" to an angle.

    const float scale = 97f / 50f;

    public float amps = 0;

    Transform needleTransform;
    Vector3 localEulerAngles;

    Coroutine continuous = null;

    // Set true for continuous monitoring of any changes
    // in the "amps" public member.

    public bool ContinuousUpdate
    {
        set
        {
            if (value && continuous == null)
            {
                continuous = StartCoroutine(Continuous());
            }
            else if (!value && continuous != null)
            {
                StopCoroutine(continuous);
            }
        }

        get => continuous != null;
    }

    // Set the amps and leave the needle in a matching
    // position, even if the public "amps" member's
    // value changes.

    public float AmpsFixed
    {
        set
        {
            ContinuousUpdate = false;
            amps = value;
            Set();
        }

        get => amps;
    }

    void Start()
    {
        needleTransform = transform.Find("AmmeterNeedle");
        localEulerAngles = needleTransform.localEulerAngles;
        ContinuousUpdate = true;
    }

    IEnumerator Continuous()
    {
        while (true)
        {
            Set();
            yield return null;
        }
    }

    void Set()
    {
        localEulerAngles.y = scale * amps;
        needleTransform.localEulerAngles = localEulerAngles;
    }
}
