using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] Animator borderBlocksAnimator;
    [SerializeField]Transform player;
    [SerializeField] float offsetY;
    void LateUpdate()
    {
        cameraFollowPlayerY();
    }

    public void cameraFollowPlayerY()
    {
        if(player.position.y>transform.position.y)
        {
            Vector3 newPos=new Vector3(transform.position.x,player.position.y-offsetY,transform.position.z);
            transform.position=newPos;
            borderBlocksAnimator.SetTrigger("Up");

        }
    }
}
