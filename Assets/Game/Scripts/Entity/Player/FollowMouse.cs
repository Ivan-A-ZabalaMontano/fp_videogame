using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowMouse : MonoBehaviour
{

    Vector3 worldPosition;
    PlayerMovement2D player;
    void Start()
    {
        player = GetComponentInParent<PlayerMovement2D>();
    }
    // Update is called once per frame
    void Update()
    {
        setRotation();
    }
    private Vector2 getMousePosition()
    {
        Vector3 mousePos = Input.mousePosition;
        mousePos.z = Camera.main.nearClipPlane;
        worldPosition = Camera.main.ScreenToWorldPoint(mousePos);
        Vector2 mousePosition = new Vector2(worldPosition.x, worldPosition.y);
        return mousePosition;
    }
    private void setRotation()
    {
        Vector2 direction = (getMousePosition() - (Vector2)transform.position).normalized;
        transform.right = direction;
        Vector3 currentScale = gameObject.transform.localScale;
        if (direction.x < 0)
        {
            currentScale.y = -1;

        }
        else if (direction.x > 0)
        {
            currentScale.y = 1;

        }
        gameObject.transform.localScale = currentScale;
    }
}
