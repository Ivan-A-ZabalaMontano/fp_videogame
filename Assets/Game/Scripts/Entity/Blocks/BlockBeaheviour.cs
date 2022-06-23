using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockBeaheviour : MonoBehaviour
{
    private float previousTime;
    [SerializeField] public int life = 0;
    [SerializeField]Transform centerBlock;
    private Vector3 rotationPoint;
    // Start is called before the first frame update
    void Start()
    {
        rotationPoint = new Vector3(centerBlock.position.x,centerBlock.position.y,centerBlock.position.z);
        int positionR  = Random.Range(1, 5);
        transform.RotateAround(rotationPoint,new Vector3(0,0,1),90*positionR);
        Debug.Log(positionR);
    }

    // Update is called once per frame
    void Update()
    { 
        
    }
}
