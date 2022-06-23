using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement2D : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private float jumpForce; //Fuerza del salto
    [SerializeField] private float wallForce; //Fuerza aplicada al saltar de una pared
    [SerializeField] private float movementSmoothing = .02f; //Cantidad para suavizar el movimiento

    //Collision Detection
    [SerializeField] private Transform overlapObject; //Objecto sobre el cual generar  la colision
    [SerializeField] private float circleRadius;  //Radio de colision
    [SerializeField] private LayerMask layer; //Layer a la cual se le aplicara la colision

    [SerializeField] private float slideCollisionLenght;
    
    [SerializeField] private float upperCollisionLenght;

    private bool onGround = true;//Booleano para detectar si esta en el suelo
    private bool canWallJump = false;// booleano para detectar si puede 
    private  bool wallJump=false;// booleano para saber si el jugador utilizo el walljump

    private float wallCounter=0;//Contador para el tiempo en el cual desactivar el estado de wallJump
    private Vector3 currentVelocity = Vector3.zero; 
    private Rigidbody2D rb2D;
    [SerializeField]private GameObject body;


    private bool faceRight = true;
    void Awake()
    {
        rb2D = gameObject.GetComponent<Rigidbody2D>();
      
    }
    void Update()
    {
        checkCollisions();
        wallJumpCounter();
      
    }
    // Update is called once per frame
    public void move(float movementDir, bool air,ref bool  isDashing)
    {
        dash(ref isDashing);
        if (canWallJump && !onGround)
        {
            Debug.Log("Can Walljump");
            if (air && movementDir!=0)
            {
                rb2D.AddForce(new Vector2(-movementDir*wallForce, jumpForce), ForceMode2D.Impulse);
                wallJump=true;
            }
        }
        if(!wallJump)
        {
            Vector3 targetVelocity = new Vector2(movementDir * 10f, rb2D.velocity.y);
            rb2D.velocity = Vector3.SmoothDamp(rb2D.velocity, targetVelocity, ref currentVelocity, movementSmoothing);
        }

        if (air && onGround)
        {
            rb2D.AddForce(new Vector2(0f, jumpForce), ForceMode2D.Impulse);
        }
        if (movementDir > 0 && !faceRight)
        {
            flip();
        }
        else if (movementDir < 0 && faceRight)
        {
            flip();
        }

    }
    public void dash(ref bool isDashing)
    {
        if(isDashing)
        {
              
            Vector3 mousePos= Input.mousePosition;
            mousePos=Camera.main.ScreenToWorldPoint(mousePos);
            if(mousePos.y>transform.position.y)
            {
                mousePos.y=transform.position.y;
            }
            Vector2 dir= new Vector2(mousePos.x-transform.position.x,mousePos.y-transform.position.y);
            dir*=10;
       
            rb2D.AddForce(dir,ForceMode2D.Impulse);
            isDashing=false;
        }
    }
    public void checkCollisions()
    {
        onGround = Physics2D.OverlapCircle(overlapObject.position, circleRadius, layer);
        canWallJump = Physics2D.OverlapPoint(new Vector2(overlapObject.position.x + (slideCollisionLenght), overlapObject.position.y+(upperCollisionLenght)));


    }
    public void wallJumpCounter()
    {
        if(wallJump)
        {
            wallCounter+=Time.deltaTime;
            if(wallCounter>=0.2)
            {
                wallCounter=0;
                wallJump=false;
            }
        }
    }
    public void flip()
    {
        Vector3 currentScale = body.transform.localScale;
        currentScale.x *= -1;
        body.transform.localScale = currentScale;
        faceRight = !faceRight;
        slideCollisionLenght *= -1;
    }
    void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(overlapObject.position, circleRadius);
        Gizmos.DrawLine(overlapObject.position, new Vector2(overlapObject.position.x + (slideCollisionLenght), overlapObject.position.y+(upperCollisionLenght)));
    }
}
