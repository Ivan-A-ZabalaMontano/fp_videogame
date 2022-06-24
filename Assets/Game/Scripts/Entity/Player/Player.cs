using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Entity
{
    //Player Variables
    PlayerMovement2D pmovement;
    WeaponBehaviour weaponBehaviour;
    private bool isJumping = false;
    private bool isDashing = false;
    public bool isDead = false;
    [SerializeField] public float hitTimer;
    private float auxHitTimer;
    private bool gotHitted = false;
    private BoxCollider2D body;
     [SerializeField] Animator playerAnimator;
    // Start is called before the first frame update
    void Start()
    {
    
        body = GetComponentInChildren<BoxCollider2D>();
        pmovement = gameObject.GetComponent<PlayerMovement2D>();
        weaponBehaviour = gameObject.GetComponentInChildren<WeaponBehaviour>();
        auxHitTimer = hitTimer;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Jump"))
        {
            isJumping = true;
        }
        if (Input.GetButtonDown("Fire1"))
        {
            weaponBehaviour.attack();
        }
        if (Input.GetButtonDown("Fire2"))
        {
            isDashing = true;
            Debug.Log("Dash");
        }
        resetHitbox();
    }
    void FixedUpdate()
    {
        if(!isDead)
        {
               movement();
        }
        die();
    }
    //Getters && Setters

    //Behaviour

    //Movement
    void movement()
    {
        float horizontal = Input.GetAxisRaw("Horizontal") * this.speed * Time.fixedDeltaTime;
        pmovement.move(horizontal, isJumping, ref isDashing);
        isJumping = false;
    }
    public void gotHit(int dmg)
    {
        gotHitted = true;
        setColor(Color.red);
        body = GetComponent<BoxCollider2D>();
        body.enabled = false;
        this.health -= dmg;
    }
    public void resetHitbox(){
        if(gotHitted){
            hitTimer -= Time.deltaTime;
        }
        if(hitTimer <= 0){
            hitTimer = auxHitTimer;
            gotHitted = false;
            body.enabled = true;
            setColor(Color.white);
        }
    }
    public void die()
    {
        if (health <= 0)
        {
            isDead = true;
            playerAnimator.SetTrigger("isDead");
        }
    }

    public bool getIsDead()
    {
        return this.isDead;
    }
    void setColor(Color color)
    {
        foreach (SpriteRenderer sr in GetComponentsInChildren<SpriteRenderer>())
        {
            sr.material.color = color;
        }
    }
}
