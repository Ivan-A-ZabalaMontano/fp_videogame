using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BottomDead : MonoBehaviour
{
    private CameraFollow cameraFollow;
    private bool activateTrigger;
    // Start is called before the first frame update
    void Start()
    {
        cameraFollow=Camera.main.GetComponent<CameraFollow>();
    }

    // Update is called once per frame
    void Update()
    {
        activateTrigger=cameraFollow.getPassedSpawn();
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        Debug.Log("Collision detected");
        if(activateTrigger)
        {
            GameObject other= collider.gameObject;
            if(other.tag=="Player")
            {
                other.GetComponent<Player>().gotHit(100);
            }
            
        }
    }
}
