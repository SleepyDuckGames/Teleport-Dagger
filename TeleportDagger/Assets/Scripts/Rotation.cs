using UnityEngine;

public class Rotation : MonoBehaviour
{
    [SerializeField] private GameObject TopBorder;
    [SerializeField] private GameObject BottomBorder;
    [SerializeField] private bool isRightDirection;

    void Update()
    {
        transform.Rotate(new Vector3(0, 0, 360) * Time.deltaTime);

        if (transform.position.y > TopBorder.transform.position.y)
            isRightDirection = false;
        else if (transform.position.y < BottomBorder.transform.position.y)
            isRightDirection = true;

        if (isRightDirection)
        {
            transform.position += (Time.deltaTime * Vector3.up);
        }
        else
        {
            transform.position += (Time.deltaTime * Vector3.down);
        }

    }
}
