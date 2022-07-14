using System.Collections;
using UnityEngine;

public class Speed : MonoBehaviour
{
    [SerializeField] public static float speed = 1;
    [SerializeField] private float cooldown;
    [SerializeField] private float acceleration;
    [SerializeField] private float sharpAcceleration;
    private float sharpAccelerationValue;
    private bool sharpAccelerationStart;
    private bool isCooldown;

    private void Awake()
    {
        isCooldown = false;
        sharpAccelerationValue = sharpAcceleration;
        sharpAccelerationStart = true;
    }

    private void FixedUpdate()
    {
        sharpAccelerationValue = sharpAcceleration;
        if (!isCooldown)
        {
            StartCoroutine(Cooldown());
        }
        if (Location.location == 1 && sharpAccelerationStart)
        {
            speed *= sharpAccelerationValue;
            sharpAccelerationStart = false;
        }
        if (Location.location == 0 && !sharpAccelerationStart)
        {
            if (sharpAccelerationStart == false)
                speed /= sharpAccelerationValue;
            sharpAccelerationStart = true;
        }

    }

    void Acceleration()
    {
        speed += acceleration;
    }

    private IEnumerator Cooldown()
    {
        isCooldown = true;
        yield return new WaitForSeconds(cooldown);
        Acceleration();
        isCooldown = false;
        yield break;
    }
}
