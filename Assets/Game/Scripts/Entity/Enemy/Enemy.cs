using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Enemy : Entity
{
    [SerializeField] protected Transform player;
    protected Vector3 playerPos;
    // Start is called before the first frame update
    void Start()
    {
        
    }
    // Update is called once per frame
    void Update()
    {
           
    }

    public abstract void move();
    public abstract void gotHit(int dmg);
}
