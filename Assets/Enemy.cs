using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {

    public float maxSpeed;
    public float minHeight, maxHeight;
    public float damageTime = .5f;
    public float maxHealth;
    public float attackRate = 1f;
    public GameObject[] coins;
    public int numcoinsmax = 4;
    public int numcoinsmin = 0;
    public int numcoins;


    private float currentHealth;
    private float currentSpeed;
    private Rigidbody rb;
    protected Animator anim;
    private Transform groundCheck;
    private bool onGround;
    protected bool facingRight = true;
    private Transform target;
    protected bool isDead = false;
    private float zForce;
    private bool damaged = false;
    private float damageTimer;
    private float walkTimer;
    private float nextAttack;
    private SoundManager soundM;
    public AudioClip colllisionSound, death;
    private int currentcoins;


    // Use this for initialization
    void Start () {
        numcoins = Random.Range(numcoinsmin, numcoinsmax);
        rb = GetComponent<Rigidbody>();
        anim = GetComponent<Animator>();
        groundCheck = gameObject.transform.Find("GroundCheck");
        currentSpeed = maxSpeed;
        target = FindObjectOfType<Player>().transform;
        currentHealth = maxHealth;
        soundM = SoundManager.instance;
    }
	
	// Update is called once per frame
	void Update () {
        onGround = Physics.Linecast(transform.position, groundCheck.position, 1 << LayerMask.NameToLayer("Ground"));
        anim.SetBool("Grounded", onGround);
        anim.SetBool("Dead", isDead);

        facingRight = (target.position.x < transform.position.x) ? false : true;
        if (facingRight)
        {
            transform.eulerAngles = new Vector3(0, 180, 0);
        } else
        {
            transform.eulerAngles = new Vector3(0, 0, 0);
        }

        if (damaged && !isDead)
        {
            damageTimer += Time.deltaTime;
            if(damageTimer >= damageTime)
            {
                damaged = false;
                damageTimer = 0;
            }
        }

        walkTimer += Time.deltaTime;
    }
    
    void FixedUpdate()
    {
        if (!isDead)
        {
            Vector3 targetDistance = target.position - transform.position;
            float hForce = targetDistance.x / Mathf.Abs(targetDistance.x);

            if (walkTimer >= Random.Range(1f,2f))
            {
                zForce = Random.Range(-1, 2);
                walkTimer = 0;
            }
            if(Mathf.Abs(targetDistance.x) < 1.5f)
            {
                hForce = 0;
            }
            if (!damaged)
            rb.velocity = new Vector3(hForce * currentSpeed, 0, zForce * currentSpeed);

            anim.SetFloat("Speed", Mathf.Abs(currentSpeed));
            if (Mathf.Abs(targetDistance.x) < 1.5f && Mathf.Abs(targetDistance.z) < 1.5f && Time.time > nextAttack)
            {
                anim.SetTrigger("Attack");
                currentSpeed = 0;
                nextAttack = Time.time + attackRate;
            }
        }
        rb.position = new Vector3(rb.position.x, rb.position.y, Mathf.Clamp(rb.position.z, minHeight, maxHeight));
    }
    public void TookDamage(int damage)
    {
        if (!isDead)
        {
            damaged = true;
            currentHealth -= damage;
            anim.SetTrigger("HitDamage");
            soundM.PlaySingle(colllisionSound);
            if (currentHealth <= 0) { 
                isDead = true;
                soundM.PlaySingle(death);
                rb.AddRelativeForce(new Vector3(3, 5, -1), ForceMode.Impulse);
                SpawnCoins();
            }

        }
    }

    public void DisableEnemy()
    {
        Destroy(gameObject);
        //gameObject.SetActive(false);
    }

    void ZeroSpeed()
    {
        currentSpeed = 0;
    }
    void ResetSpeed()
    {
        currentSpeed = maxSpeed;
    }

    void SpawnCoins()
    {
        Vector3 spawnPosition = new Vector3(transform.position.x, transform.position.y, transform.position.z);
        GameObject coin = Instantiate(coins[Random.Range(0, coins.Length)], spawnPosition, Quaternion.identity);
        coin.SetActive(true);
        coin.GetComponent<Rigidbody>().AddRelativeForce(new Vector3(Random.Range(-1, 3), Random.Range(4, 10), Random.Range(-2, 2)), ForceMode.Impulse);
        currentcoins++;
        if (currentcoins < numcoins)
        {
            Invoke("SpawnCoins", 0);
        }
    }
}
