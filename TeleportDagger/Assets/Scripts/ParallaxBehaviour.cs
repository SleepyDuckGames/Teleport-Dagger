using UnityEngine;

public class ParallaxBehaviour : MonoBehaviour
{
    [SerializeField, Range(0f, 1f)] private float parallaxStrength = 0.01f;

    void Update()
    {
        transform.Translate(Time.deltaTime * Speed.speed * Vector3.left*parallaxStrength);
    }
}
