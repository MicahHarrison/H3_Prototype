using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

    public float maxSpeed = 4;
    public float jumpForce = 400;
    public float minHeight, maxHeight;
    public int maxHealth;
    public string playerName;
    public Sprite playerImage;
    public AudioClip colllisionSound, jumpSound, healthItem, death;

    private int currentHealth;
    private int currentFupa;
    private float currentSpeed;
    private Rigidbody rb;
    private Animator anim;
    private Transform groundCheck;
    private bool onGround;
    private bool isDead = false;
    private bool facingRight = true;
    private bool jump = false;
    private AudioSource audioS;
    private SoundManager soundM;
    // Use this for initialization
    void Start () {
        rb = GetComponent<Rigidbody>();
        anim = GetComponent<Animator>();
        audioS = GetComponent<AudioSource>();
        soundM = SoundManager.instance;
        groundCheck = gameObject.transform.Find("GroundCheck");
        currentSpeed = maxSpeed;
        maxHealth = GameControl.instance.maxhealth;
        currentHealth = GameControl.instance.currenthealth;
        currentFupa = GameControl.instance.currentfupa;
        Debug.Log(GameControl.instance.playerposition);
        Debug.Log("LOADED PLAYER");
        transform.position = GameControl.instance.playerposition;
        
    }

// Update is called once per frame
void Update () {
        onGround = Physics.Linecast(transform.position, groundCheck.position, 1 << LayerMask.NameToLayer("Ground"));
        anim.SetBool("OnGround", onGround);
        anim.SetBool("Dead", isDead);
        if (Input.GetButtonDown("Jump") && onGround)
        {
            soundM.PlaySingle(jumpSound);
            jump = true;
        }
        if (Input.GetButtonDown("Fire1"))
        {
            anim.SetTrigger("Attack");
        }
	}

    private void FixedUpdate()
    {
        if (!isDead)
        {
            float h = Input.GetAxis("Horizontal");
            float z = Input.GetAxis("Vertical");
            if (!onGround) //if player is in the air, you cant move
            {
                z = 0;
            }
            rb.velocity = new Vector3(h * currentSpeed, rb.velocity.y, z * currentSpeed);
            if (onGround)
                anim.SetFloat("Speed", Mathf.Abs(rb.velocity.magnitude));
            

            if ((h > 0 && !facingRight) || (h < 0 && facingRight))
            {
                Flip();
            }
            if (jump)
            {
                soundM.PlaySingle(jumpSound);
                jump = false;
                rb.AddForce(Vector3.up * jumpForce);
            }
            float minWidth = Camera.main.ScreenToWorldPoint(new Vector3(0, 0, 10)).x;
            float maxWidth = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, 0, 10)).x;
            rb.position = new Vector3(Mathf.Clamp(rb.position.x, minWidth + 1, maxWidth - 1), rb.position.y, Mathf.Clamp(rb.position.z, minHeight, maxHeight));
        }
    }

    void Flip()
    {
        facingRight = !facingRight;

        Vector3 scale = transform.localScale;
        scale.x *= -1;
        transform.localScale = scale;
    }

    void ZeroSpeed()
    {
        currentSpeed = 0;
    }
    void ResetSpeed()
    {
        currentSpeed = maxSpeed;
    }

    public void TookDamage(int damage)
    {
        if (!isDead)
        {
            currentHealth -= damage;
            GameControl.instance.currenthealth = currentHealth;
            anim.SetTrigger("HitDamage");
            soundM.PlaySingle(colllisionSound);
            FindObjectOfType<UIManager>().UpdateHealth(currentHealth);
            if (currentHealth <= 0)
            {
                soundM.PlaySingle(death);
                isDead = true;
                GameControl.instance.lives -= 1;
                FindObjectOfType<UIManager>().UpdateLives();
                if (facingRight)
                {
                    rb.AddForce(new Vector3(-3, 5, 0), ForceMode.Impulse);
                } else
                {
                    rb.AddForce(new Vector3(3, 5, 0), ForceMode.Impulse);
                }
            }
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Health Item"))
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                Destroy(other.gameObject);
                anim.SetTrigger("Catching");
                soundM.PlaySingle(healthItem);
                currentHealth = maxHealth;
                GameControl.instance.currenthealth = currentHealth;
                FindObjectOfType<UIManager>().UpdateHealth(currentHealth);
            }
        }
        if (other.CompareTag("Fountain"))
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                soundM.PlayEfx();
            }
        }
    }

    void PlayerRespawn()
    {
        isDead = false;
        currentHealth = maxHealth;
        FindObjectOfType<UIManager>().UpdateHealth(currentHealth);
        GameControl.instance.currenthealth = currentHealth;
        anim.Rebind();
        float minWidth = Camera.main.ScreenToWorldPoint(new Vector3(0, 0, 10)).x;
        transform.position = new Vector3(minWidth, 10, -4);
    }
}
