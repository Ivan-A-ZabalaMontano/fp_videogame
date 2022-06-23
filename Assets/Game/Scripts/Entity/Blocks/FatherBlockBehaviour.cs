using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FatherBlockBehaviour : Entity
{
    //Main attributes

    private Color color;
    private Rigidbody2D rb2d;
    //Rotation Variables
    [SerializeField] Transform centerBlock;

    private Vector3 rotationPoint;

    [SerializeField] bool canRotate = true;
    [SerializeField] private float rotationDelay;
    private float auxRotationDelay;

    private int maxRotations;




    // Start is called before the first frame update
    void Start()
    {
        rb2d = gameObject.GetComponent<Rigidbody2D>();
        color = Random.ColorHSV(0f, 1f, 1f, 1f, 1f, 1f);
        rb2d.velocity=new Vector2(0,1f);



        setColor();
        if (canRotate)
        {
            auxRotationDelay = rotationDelay;
            maxRotations = Random.Range(1, 20);
            Debug.Log(maxRotations);
        }

    }

    // Update is called once per frame
    void Update()
    {

    }
    void FixedUpdate()
    {
        rotate();
        capMaxVelocity();
    }
    void rotate()
    {
        if (maxRotations > 0 && rb2d.velocity != Vector2.zero)
        {
            if (rotationDelay <= 0)
            {
                rotationPoint = new Vector3(centerBlock.position.x, centerBlock.position.y, centerBlock.position.z);
                rotationDelay = auxRotationDelay;
                transform.RotateAround(rotationPoint, new Vector3(0, 0, 1), 90);
                maxRotations--;
                rotationDelay = auxRotationDelay;
            }
            rotationDelay -= Time.deltaTime;
        }
        else if(rb2d.velocity==Vector2.zero)
        {
            maxRotations=0;
        }
    }
    void capMaxVelocity()
    {
        if (rb2d.velocity.y < -speed || rb2d.velocity.y>-speed)
        {
            rb2d.velocity = new Vector2(0,-speed);
        }
    }
    void setColor()
    {
        foreach (SpriteRenderer sr in GetComponentsInChildren<SpriteRenderer>())
        {
            sr.material.color = color;
        }
    }


}
