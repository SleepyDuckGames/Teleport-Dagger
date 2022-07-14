using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField, Range(0f, 1f)] private float parallaxStrength = 1f;

    void Update()
    {
        transform.Translate(Time.deltaTime * Speed.speed * Vector3.left * 5.12f * parallaxStrength); //5.12 RepeatMover axis
    }
}
