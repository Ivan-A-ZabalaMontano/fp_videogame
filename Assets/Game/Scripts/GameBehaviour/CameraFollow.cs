using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    // Start is called before the first frame update
  
    [SerializeField] Transform player;
    [SerializeField] float offsetY;
    [SerializeField] float offsetSmoothing;
    void LateUpdate()
    {
        cameraFollowPlayerY();
    }

    public void cameraFollowPlayerY()
    {
        if (player != null)
        {
            Vector3 playerPos= new Vector3(transform.position.x,player.transform.position.y+offsetY,transform.position.z);
            transform.position=Vector3.Lerp(transform.position,playerPos,offsetSmoothing*Time.deltaTime);
        }

    }
}
