using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    // Start is called before the first frame update

    [SerializeField] Transform player;
    [SerializeField] float offsetY;
    [SerializeField] float offsetSmoothing;

    [SerializeField] Transform bg1;
    [SerializeField] Transform bg2;
    [SerializeField] Transform bg3;
    private bool passedSpawn = false;
    private float size;

    void Start()
    {
        size = bg1.GetComponent<BoxCollider2D>().size.y * 3;
        Debug.Log("BG Size: " + size);
    }
    void FixedUpdate()
    {
        cameraFollowPlayerY();
        updateBGs();
    }

    public void cameraFollowPlayerY()
    {
        if (player != null)
        {
            Vector3 playerPos = new Vector3(transform.position.x, player.transform.position.y + offsetY, transform.position.z);
            transform.position = Vector3.Lerp(transform.position, playerPos, offsetSmoothing * Time.deltaTime);
        }

    }
    public void updateBGs()
    {
        if (transform.position.y >= bg2.position.y)
        {
            passedSpawn = true;
            bg1.position = new Vector3(bg1.position.x, bg2.position.y + size, bg1.position.z);
            SwitchBGUp();
        }
        if (transform.position.y < bg1.position.y && passedSpawn)
        {
            bg2.position = new Vector3(bg2.position.x, bg1.position.y - size, bg2.position.z);
            SwitchBGDown();
        }
    }
    public void SwitchBGUp()
    {
        Transform aux = bg1;
        bg1 = bg2;
        bg2 = aux;
        bg3.position = new Vector3(bg3.position.x, bg3.position.y + size, bg3.position.z);
    }
    public void SwitchBGDown()
    {
        Transform aux = bg1;
        bg1 = bg2;
        bg2 = aux;
        bg3.position = new Vector3(bg3.position.x, bg3.position.y - size, bg3.position.z);
    }


    public bool getPassedSpawn()
    {
        return this.passedSpawn;
    }
}
