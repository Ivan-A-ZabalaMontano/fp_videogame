using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using  UnityEngine.SceneManagement;
public class GameOverScreen : MonoBehaviour
{
    [SerializeField]private GameObject gameOverScreen;
    public Text finalScoreText;
    public  void Setup(int score)
    {
        gameOverScreen.SetActive(true);
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void restartButton()
    {
        SceneManager.LoadScene("GameScene");
    }
    public void mainMenuButton()
    {
         SceneManager.LoadScene("MenuScene");
    }
    public void leaderboardButton()
    {
         SceneManager.LoadScene("LeaderboardScene");
    }
    public GameObject GetGameObject()
    {
        return this.gameOverScreen;
    }
}
