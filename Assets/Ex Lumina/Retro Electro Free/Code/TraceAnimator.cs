using UnityEngine;

// Simply scroll the oscilloscope prefab's "trace" texture.

public class TraceAnimator : MonoBehaviour
{
    // Number of complete scrollings per second.

    public float speed = .25f;

    Material trace;
    Vector2 offset;

    void Start()
    {
        trace = GetComponent<Renderer>().material;
        offset = trace.mainTextureOffset;
    }

    void Update()
    {
        offset.x = (offset.x + speed * Time.deltaTime) % 1;
        trace.mainTextureOffset = offset;
    }
}
