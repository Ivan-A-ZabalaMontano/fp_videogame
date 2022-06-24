using UnityEngine;

public class Eye : Enemy
{
    // Start is called before the first frame update

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        lookPlayer();
        move();
        die();
    }

    public override void move()
    {
        player = GameObject.Find("Player").transform;
        transform.Translate(0, this.speed * Time.deltaTime, 0);

    }
    public void lookPlayer()
    {
        Vector2 dir = new Vector2(player.transform.position.x - transform.position.x, player.transform.position.y - transform.position.y);
        transform.up = dir;
    }

    void die()
    {

        if (this.getHealth() <= 0)
        {

            GameObject hud = GameObject.Find("EventSystem");
            HudHandler handler = hud.GetComponent<HudHandler>();
            handler.addScore(30);
            Destroy(gameObject);
        }
    }
    public override void gotHit(int dmg)
    {
        this.health -= dmg;
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
