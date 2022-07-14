using System.Collections;
using UnityEngine;

public class Location : MonoBehaviour
{
    [SerializeField] private int locationTransition;
    [SerializeField] private Score score;
    private int numberOfTransitions;
    private bool isCooldown;
    public static int location;
    public Flash flash;

    private void Awake()
    {
        location = 0;
        numberOfTransitions = 0;
    }

    private void Update()
    {

        if (score.score % locationTransition == 0 && score.score != 0 && !isCooldown)
        {
            numberOfTransitions++;
            location = numberOfTransitions % 2;
            flash.FlashStart();
            StartCoroutine(Cooldown2());

        }
    }

    private IEnumerator Cooldown2()
    {
        isCooldown = true;
        yield return new WaitForSeconds(1f);
        isCooldown = false;
        yield break;
    }
}
