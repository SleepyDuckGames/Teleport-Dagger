using UnityEngine;

public class ChangeOfLocation : MonoBehaviour
{
    [SerializeField] private Sprite[] sprites;

    private void Update()
    {
        if(Location.location == 1)
        {
            gameObject.GetComponent<SpriteRenderer>().sprite = sprites[1];
        }
        else
        {
            gameObject.GetComponent<SpriteRenderer>().sprite = sprites[0];
        }
    }
}
