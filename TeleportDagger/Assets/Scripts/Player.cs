using System.Collections;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private new Rigidbody2D rigidbody;
    [SerializeField] private float force;
    [SerializeField] private float cooldown;
    [SerializeField] private Animator animator;
    [SerializeField] private Transform teleportTop;
    [SerializeField] private Transform teleportBottom;
    [SerializeField] private int extraJumpsValue;
    [SerializeField] private AudioSource audioCoin;
    [SerializeField] private AudioSource audioPowerUp;
    [SerializeField] private AudioSource audioPowerUpReverse;
    [SerializeField] private AudioSource audioLosnig;
    [SerializeField] private Coin coin;
    [SerializeField] private GameObject restartPanel;
    [SerializeField] private Pause pause;
    public  bool powerUpCooldown;
    private int extraJumps;
    private bool banOnJump;
    private bool isJumping;

    private bool teleportUp;

    private bool isGrounded;
    public Transform groundCheck;
    public float checkRadius;
    public LayerMask whatIsGround;
 
    public Animator anim;
    public SimpleTouchPad touchPad;

    private void Start()
    {
        anim.speed = Speed.speed;
    }
    private void FixedUpdate()
    {
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, checkRadius, whatIsGround);
    }
    private void Update()
    {
        anim.speed = Speed.speed;

        animator.SetBool("IsGrounded", isGrounded);

        if (!isJumping && !isGrounded)
            animator.SetTrigger("StartFall");

        isJumping = isJumping && !isGrounded;
        
        if(isGrounded)
        {
            extraJumps = extraJumpsValue;
        }

        if (!touchPad.Cleek && !banOnJump && extraJumps > 0) {
            Jump();
            extraJumps--;
            touchPad.Cleek = true;
        }
        else if(!touchPad.Cleek && !banOnJump && extraJumps == 0 && isGrounded)
        {
            Jump();
            touchPad.Cleek = true;
        }
        else
        {
            touchPad.Cleek = true;
        }

        if (touchPad.SwipeDown)
        {
            touchPad.SwipeDown = false;
            if (!teleportUp)
            {
                animator.SetTrigger("TeleportTop");
                banOnJump = true;
            }
        }

        if (touchPad.SwipeUp)
        {
            touchPad.SwipeUp = false;
            if (teleportUp)
            {
                animator.SetTrigger("TeleportBottom");
                banOnJump = true;
            }
        }
    }

    void Jump()
    {
        animator.SetTrigger("StartJump");
        rigidbody.AddForce(Vector2.up * force, ForceMode2D.Impulse);
        isJumping = true;
    }

    void TeleportUp()
    {
        animator.SetBool("TeleportBool", true);
    }

    void TeleportUpEnd()
    {
        transform.position = teleportTop.position;
        banOnJump = false;
        animator.SetBool("TeleportBool", false);
    }

    void TeleportDown()
    {
        animator.SetBool("TeleportBool", true);
    }

    void TeleportDownEnd()
    {
        transform.position = teleportBottom.position;
        banOnJump = false;
        animator.SetBool("TeleportBool", false);
    }

    private void OnTriggerStay2D(Collider2D col)
    {
        if (col.gameObject.CompareTag("TeleportTop"))
        {
            teleportUp = false;
        }

        if (col.gameObject.CompareTag("TeleportBottom"))
        {
            teleportUp = true;
        }
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.CompareTag("Obstacle"))
        {
            if(col.name == "Fragile lump"  && powerUpCooldown)
            {
                col.gameObject.SetActive(false);
            }
            else
            {
                audioLosnig.Play();
                animator.SetTrigger("Losing");
                pause.RestartMenu();
            }
        }

        if (col.gameObject.CompareTag("Coin"))
        {
            audioCoin.Play();
            col.gameObject.SetActive(false);
            coin.PickUpCoin();
        }
        if (col.gameObject.CompareTag("PowerUp"))
        {
            gameObject.transform.localScale = new Vector3(1.2f, 1.2f, 1.2f);
            audioPowerUp.Play();
            col.gameObject.SetActive(false);
            StartCoroutine("PowerUpCooldown");
        }
    }

    IEnumerator PowerUpCooldown()
    {
        powerUpCooldown = true;
        yield return new WaitForSeconds(2f);
        audioPowerUpReverse.Play();
        gameObject.transform.localScale = new Vector3(1, 1, 1);
        powerUpCooldown = false;
        yield break;
    }
}
