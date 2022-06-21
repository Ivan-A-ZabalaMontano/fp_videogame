using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Entity
{
    //Player Variables
     PlayerMovement2D pmovement;
     WeaponBehaviour weaponBehaviour;
     private bool isJumping=false;
     private bool isDashing=false;
     private bool isAttacking=false;

    // Start is called before the first frame update
    void Start()
    {
        pmovement=gameObject.GetComponent<PlayerMovement2D>();
        weaponBehaviour=gameObject.GetComponentInChildren<WeaponBehaviour>();
    }

    // Update is called once per frame
    void Update()
    {
      if(Input.GetButtonDown("Jump"))
      {
          isJumping=true;
      }
      if(Input.GetButtonDown("Fire1"))
      {
        isAttacking=true;
        weaponBehaviour.attack();
      }
      if(Input.GetButtonDown("Fire2"))
      {
          isDashing=true;
          Debug.Log("Dash");
      }
    }
    void FixedUpdate()
    {
        movement();
    }
    //Getters && Setters

    //Behaviour

        //Movement
        void movement()
        {
            float horizontal= Input.GetAxisRaw("Horizontal")*this.speed*Time.fixedDeltaTime;
            pmovement.move(horizontal,isJumping,ref isDashing);
            isJumping=false;
        }

}
