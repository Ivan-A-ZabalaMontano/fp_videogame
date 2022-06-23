using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HudHandler : MonoBehaviour
{
    [SerializeField] Transform target;
    private Vector3 currentPosition;
    private Vector3 highestPosition;

    [SerializeField] Text scoreText;

    private int score = 0;

    private GameOverScreen gameOverScreen;
    private Player player;
    private GameObject playerObject;
    // Start is called before the first frame update
    void Start()
    {
        gameOverScreen = GetComponent<GameOverScreen>();
        gameOverScreen.GetGameObject().SetActive(false);
        highestPosition = new Vector3(target.position.x, target.position.y, target.position.z);
        currentPosition = new Vector3(target.position.x, target.position.y, target.position.z);
    }

    // Update is called once per frame
    void Update()
    {
        if (target != null)
        {
            checkForGameOver();
            currentPosition = new Vector3(target.position.x, target.position.y, target.position.z);
            if (checkForHighestPos())
            {
                score++;
                scoreText.text = "Score: " + score;
            }
        }
    }

    bool checkForHighestPos()
    {
        bool flag = false;
        if (currentPosition.y > highestPosition.y)
        {
            highestPosition = new Vector3(currentPosition.x, currentPosition.y, currentPosition.z);
            flag = true;
        }
        return flag;
    }

    void checkForGameOver()
    {
        playerObject = GameObject.Find("Player");
        player = playerObject.GetComponent<Player>();
        if (player.getIsDead())
        {
            gameOverScreen.Setup(score);
        }
    }

    public void addScore(int score)
    {
        this.score+=score;
        scoreText.text = "Score: " + this.score;
    }

}
