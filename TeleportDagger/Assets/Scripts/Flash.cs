using System.Collections;
using UnityEngine;

public class Flash : MonoBehaviour
{
    [SerializeField] private SpriteRenderer sr;
    private float t;

    private void Update()
    {
        
    }

    public void FlashStart()
    {
        StartCoroutine(FadeIn());
    }

    IEnumerator FadeIn()
    {
        float t = 1f;

        while (t > 0f)
        {
            t -= Time.deltaTime * 1f;
            float a = t;
            sr.color = new Color(1f, 1f, 1f, a);
            yield return 0;
        }
    }
}
