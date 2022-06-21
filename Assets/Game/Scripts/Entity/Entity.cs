using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//
public abstract class Entity : MonoBehaviour
{
    //Entity Stats
    protected float  health;
    [SerializeField]protected float speed;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    //Getters && Setters
    public float getHealth()
    {
        return this.health;
    }
    public void setHealth(float health)
    {
        this.health=health;
    }
    //Methods
}
