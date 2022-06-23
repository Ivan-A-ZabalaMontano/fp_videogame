using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrushBehaviour : MonoBehaviour
{
    [SerializeField] private LayerMask layer;
    [SerializeField] private Transform playerHead; //Objecto sobre el cual generar  la colision
    [SerializeField] private Transform playerFeet; //Objecto sobre el cual generar  la colision

    [SerializeField] private float angle;


    private bool headCol;
    private bool feetCol;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        checkCollisions();
        crushPlayer();

    }
    void checkCollisions()
    {
        headCol = Physics2D.OverlapBox(playerHead.position,new Vector2(angle/2,angle),angle/2,layer);
        feetCol = Physics2D.OverlapBox(playerFeet.position,new Vector2(angle/2,angle),angle/2,layer);

    }
    void crushPlayer()
    {
        if(feetCol && headCol)
        {
            Debug.Log("Player crushed");
            Destroy(gameObject);
        }
    
    }
    void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(playerHead.position,new Vector2(angle/2,angle));
        Gizmos.DrawWireCube(playerFeet.position,new Vector2(angle/2,angle));
    }
}
