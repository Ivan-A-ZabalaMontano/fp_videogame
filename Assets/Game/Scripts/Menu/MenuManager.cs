using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class MenuManager : MonoBehaviour
{
    [SerializeField] string gameScene;
    [SerializeField] string skinScene;
    [SerializeField] string LeaderboardScene;
    [SerializeField] Button play;
    
    [SerializeField] Button skin;
    [SerializeField] Button leaderboard;
    [SerializeField] Button exit;
    // Start is called before the first frame update
    void Start()
    {
    
   
        skin.onClick.AddListener(skinScreen);
        leaderboard.onClick.AddListener(LeaderboardScreen);
        exit.onClick.AddListener(quitGame);    
          play.onClick.AddListener(startGame);

    }
    public void startGame()
    {
        SceneManager.LoadScene(gameScene);
    }
    public void skinScreen()
    {
        SceneManager.LoadScene(skinScene);
    }
    public void LeaderboardScreen()
    {
        SceneManager.LoadScene(LeaderboardScene);
    }
    public void quitGame()
    {
        Debug.Log("Quitting");
        Application.Quit();
    }
}
