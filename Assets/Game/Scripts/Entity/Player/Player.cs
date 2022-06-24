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

    private BoxCollider2D body;
     [SerializeField] Animator playerAnimator;
    // Start is called before the first frame update
    void Start()
    {
        body = GetComponentInChildren<BoxCollider2D>();
        pmovement = gameObject.GetComponent<PlayerMovement2D>();
        weaponBehaviour = gameObject.GetComponentInChildren<WeaponBehaviour>();
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
        this.health -= dmg;
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
}
