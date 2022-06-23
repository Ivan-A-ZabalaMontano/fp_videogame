using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn : MonoBehaviour
{
    public GameObject[] blockType;
    public float respawnTime = 5.0f;
    public float[] spawnPositionsX;
    private Vector2 screenBounds;
    
    // Start is called before the first frame update
    void Start()
    {
        spawnPositionsX = new float[10];
        for (int i = 0; i < 10; i++)
        {
            spawnPositionsX[i] =(-10.5f)+(2.0f*i);
            Debug.Log(spawnPositionsX[i]);
        }
        screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width,Screen.height,Camera.main.transform.position.z)); 
        StartCoroutine(blockSpawn(respawnTime,blockType));
    }  
    // Update is called once per frame
    void Update()
    {
        
    }
    private IEnumerator blockSpawn(float interval,GameObject[] block){
        int n  = Random.Range(0, 4);
        int m  = Random.Range(0, 10);
        float SpawnPositionSet = spawnPositionsX[m];
        yield return new WaitForSeconds(interval);
        GameObject newBlock = Instantiate(block[n], new Vector3(SpawnPositionSet,(screenBounds.y)+2.5f,0),Quaternion.identity);
        StartCoroutine(blockSpawn(interval,block));
    }
}
