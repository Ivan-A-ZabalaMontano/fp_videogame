using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] public GameObject SlimePrefab;
    [SerializeField] public GameObject EyePrefab;
    public float respawnTimeSlime = 5.0f;
    public float respawnTimeEyes = 10.0f;
    private Vector2 screenBounds;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(spawnEnemySlime(respawnTimeSlime,SlimePrefab));
        StartCoroutine(spawnEnemySlime(respawnTimeEyes,EyePrefab));
    }
    void Update(){
        screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width,Screen.height,Camera.main.transform.position.z));
    }
    // Update is called once per frame
    private IEnumerator spawnEnemySlime(float interval,GameObject enemy){
        yield return new WaitForSeconds(interval);
        GameObject newEnemy = Instantiate(enemy, new Vector3(Random.Range(-11.8f,11.2f),(screenBounds.y)+2f,0),Quaternion.identity);
        StartCoroutine(spawnEnemySlime(interval,enemy));
    }
    private IEnumerator spawnEnemyEye(float interval,GameObject enemy){
        yield return new WaitForSeconds(interval);
        GameObject newEnemy = Instantiate(enemy, new Vector3(Random.Range(-screenBounds.x,screenBounds.x),Random.Range(-screenBounds.y,screenBounds.y),0),Quaternion.identity);
        StartCoroutine(spawnEnemyEye(interval,enemy));
    }
}
