using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slime : Enemy
{
    [SerializeField] private Transform groundDetection; //Objecto sobre el cual generar  la colision

    [SerializeField] private float circleRadius;  //Radio de colision
    [SerializeField] private LayerMask layer; //Layer a la cual se le aplicara la colision

    private bool onGround;
    private Rigidbody2D rb2d;


    // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        checkGround();
        move();
        die();
    }

    void checkGround()
    {
        onGround = Physics2D.OverlapCircle(groundDetection.position, circleRadius, layer);
    }

    public override void move()
    {
        player = GameObject.Find("Player").transform;
        if (rb2d.velocity.x == 0 && onGround)
        {
            rb2d.AddForce(new Vector2(this.speed, this.speed * 5), ForceMode2D.Impulse);
        }
        else
        {
            transform.Translate(player.transform.position.x * speed * Time.deltaTime, 0, 0);
        }
    }

    public override void gotHit(int dmg)
    {

        this.health -= dmg;
    }
    void die()
    {

        if (health <= 0)
        {
            GameObject hud = GameObject.Find("EventSystem");
            HudHandler handler = hud.GetComponent<HudHandler>();
            handler.addScore(30);
            Destroy(gameObject);
        }
    }
    void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(groundDetection.position, circleRadius);
    }
    void OnTriggerEnter2D(Collider2D collider)
    {
        GameObject other = collider.gameObject;
        if (other.tag == "Player")
        {
            other.GetComponent<Player>().gotHit(5);
        }
    }
}
