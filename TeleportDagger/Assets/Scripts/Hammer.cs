using System.Collections;
using UnityEngine;

public class Hammer : MonoBehaviour
{
    [SerializeField] private bool isRightDirection;
    [SerializeField] private float cooldown;
    [SerializeField] private bool isCooldown = true;
    [SerializeField] private float speed;

    private void Start()
    {

    }

    void FixedUpdate()
    {
        if (gameObject.transform.localPosition.y <= -1.03f && !isCooldown)
        {
            isRightDirection = true;
            StartCoroutine(Cooldown());
        }
        if (gameObject.transform.localPosition.y >= 1.03f && !isCooldown)
        {
            isRightDirection = false;
            StartCoroutine(Cooldown());
        }

        if (isRightDirection && transform.localPosition.y <= 1.03f)
        {
            transform.localPosition += (Time.fixedDeltaTime * Vector3.up * speed);
            if(transform.localPosition.y >= 1.03f)
            {
                transform.localPosition = new Vector3(0f, 1.03f, 0f);
            }
        }
        else if(!isRightDirection && transform.localPosition.y >= -1.03f)
        {
            transform.localPosition += (Time.deltaTime * Vector3.down * speed);
            if (transform.localPosition.y <= -1.03f)
            {
                transform.localPosition = new Vector3(0f, -1.03f, 0f);
            }
        }

    }

    public void HammerMovement()
    {
        isCooldown = false;
    }

    private IEnumerator Cooldown()
    {
        isCooldown = true;
        yield return new WaitForSeconds(cooldown);
        isCooldown = false;
        yield break;
    }
}
