using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChildBlockBehaviour : MonoBehaviour
{

    private int health;
    private FatherBlockBehaviour father;

    // Start is called before the first frame update
    void Start()
    {

        father = GetComponentInParent<FatherBlockBehaviour>();
        health = father.getHealth();
    }

    // Update is called once per frame
    void Update()
    {
        die();
    }
    public void onHit(int damage)
    {
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector2 mousePos2D = new Vector2(mousePos.x, mousePos.y);

        RaycastHit2D hit = Physics2D.Raycast(mousePos2D, Vector2.zero);
        if (hit.collider != null)
        {
            Debug.Log(hit.collider.gameObject.name);
            if(hit.collider.gameObject==gameObject)
            {
                health-=damage;
            }
        }
    }
    public void die()
    {
        if (this.health <= 0)
        {
            Destroy(gameObject);
        }
    }
}
