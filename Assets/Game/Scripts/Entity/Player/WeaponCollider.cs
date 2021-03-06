using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponCollider : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        GameObject other=col.gameObject;
        if(other.tag=="Blocks")
        {
            ChildBlockBehaviour child=other.GetComponent<ChildBlockBehaviour>();
            child.onHit(10);
        }
        else if(other.tag=="Enemy")
        {
            Enemy enemy=other.GetComponent<Enemy>();
            enemy.gotHit(10);
        }
    }
}
