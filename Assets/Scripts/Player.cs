using System.Collections;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class Player : Entity
{
    [SerializeField] private float speed = 3f; // скорость движени€
    [SerializeField] private int health = 5; // количество жизней
    [SerializeField] private float jumpForce = 15f; // сила прыжка
    private bool isGrounded = false; //метод €вл€етс€ закрытым

    [SerializeField] private Image[] hearts;

    [SerializeField] private Sprite aliveHeart;
    [SerializeField] private Sprite deadHeart;
    [SerializeField] GameObject imGameOver;
    private bool facingRight = true;

    public bool isAttacking = false; //атакуем ли мы сейчас
    public bool isRecharged = true; //перезар€дились ли мы

    public Transform attackPos; //позици€ атаки
    public float attackRange; //дальность атаки
    public LayerMask enemy; //слой с врагами
    public Joystick joystick;
    public AudioSource stepsound;

    [SerializeField] private AudioSource jumpSound;
    [SerializeField] private AudioSource damageSound;
    [SerializeField] private AudioSource missAttack;
    [SerializeField] private AudioSource attackMob;

    private Rigidbody2D rb;
    private Animator anim;
    private SpriteRenderer sprite;
    private float moveInput;

    public static Player Instance { get; set; }
    private States State
    {
        get { return (States)anim.GetInteger("state"); }
        set { anim.SetInteger("state", (int)value); }
    }
    private void Awake()
    {
        lives = 6;
        health = lives;
        Instance = this;
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        sprite = GetComponentInChildren<SpriteRenderer>();
        isRecharged = true;


    }

    private void FixedUpdate()
    {
        CheckGround();
        moveInput = Input.GetAxis("Horizontal");
        
        if (facingRight == false 
           && moveInput > 0)
        {
            Flip();
        }
        else if (facingRight == true 
                && moveInput < 0)
        {
            Flip();
        }
    }
    private void Run()
    {
        stepsound.Play();
        if (isGrounded) State = States.run;

        Vector3 dir = transform.right * joystick.Horizontal;
        
        transform.position = Vector3.MoveTowards(transform.position, transform.position + dir, speed * Time.deltaTime);
        sprite.flipX = dir.x < 0.0f;

    }


    public void Update()
    {
        if (isGrounded 
           && !isAttacking) State = States.idle;

        if (!isAttacking 
           && joystick.Horizontal !=0)
            Run();
        if (!isAttacking 
           && isGrounded 
           && joystick.Vertical > 0.5f)
            Jump();
       


        if (health > lives)
            health = lives;


        for (int i = 0; i < hearts.Length; i++)
        {
            if (i < health)
                hearts[i].sprite = aliveHeart;
            else
                hearts[i].sprite = deadHeart;

            if (i < lives)
                hearts[i].enabled = true;
            else
                hearts[i].enabled = false;
        }
    }

    private void Jump()
    {
         
        rb.velocity = Vector2.up * jumpForce;
        jumpSound.Play();
    }

    private void CheckGround()
    {
        Collider2D[] collider = Physics2D.OverlapCircleAll(transform.position, 0.3f);
        isGrounded = collider.Length > 1;

        if (!isGrounded) State = States.jump;

    }

    public override void GetDamage()
    {
        lives -= 1;
        damageSound.Play();
        if (health <=1)
        {
            imGameOver.SetActive(true);
            Time.timeScale = 0;
            foreach (var h in hearts)
                h.sprite = deadHeart;
            Die();
        }
        Debug.Log(lives);
    }


    private IEnumerator EnemyOnAttck(Collider2D enemy)
    {
        SpriteRenderer enemyColor = enemy.GetComponentInChildren<SpriteRenderer>();
        enemyColor.color = new Color(1f, 0.4375f, 0.4375f);
        yield return new WaitForSeconds(0.15f);
        // enemyColor.color = new Color(1,1,1);
    }
    public enum States
    {
        idle,
        run,
        jump,
        attack
    }

    public void Attack()
    {
        
            Debug.Log("Ќажата кнопка");
       

        if (isGrounded 
           && isRecharged)
        {
            State = States.attack;
            isAttacking = true;
            isRecharged = false;

            StartCoroutine(AttackAnimation());
            StartCoroutine(AttackCoolDown());
            Debug.Log("јтака произведена");
        }
    }

    private void OnAttack()
    {
        Collider2D[] colliders = Physics2D.OverlapCircleAll(attackPos.position, attackRange, enemy);

        if (colliders.Length == 0)
            missAttack.Play();
        else
            attackMob.Play();

        for (int i = 0; i < colliders.Length; i++)
        {
            colliders[i].GetComponent<Entity>().GetDamage();
            StartCoroutine(EnemyOnAttck(colliders[i]));
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(attackPos.position, attackRange);
    }
    private IEnumerator AttackAnimation()
    {
        yield return new WaitForSeconds(0.4f);
        isAttacking = false;
    }
    private IEnumerator AttackCoolDown()
    {
        yield return new WaitForSeconds(0.5f);
        isRecharged = true;
    }

    void Flip()
    {
        facingRight = !facingRight;
        Vector3 scaler = transform.localScale;
        scaler.x *= -1;
        transform.localScale = scaler;
    }

    
        }
    

