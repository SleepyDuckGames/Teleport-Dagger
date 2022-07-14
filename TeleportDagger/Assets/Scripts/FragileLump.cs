using UnityEngine;

public class FragileLump : MonoBehaviour
{
    [SerializeField] private GameObject fragileLump;
    [SerializeField] private GameObject pieces;
    [SerializeField] private bool cooldown = false;
    [SerializeField] private Animator animator;

    void Update()
    {
        if(fragileLump.activeInHierarchy == false && cooldown == false)
        {
            animator.speed = 1;
            pieces.SetActive(true);

        }
        if(pieces.activeInHierarchy == false)
        {
            animator.speed = 0;
        }


    }

    public void ActivePieces()
    {
        animator.speed = 0;
        pieces.SetActive(false);
        cooldown = true;
    }

    public void Cooldown()
    {
        cooldown = false;
    }
}
