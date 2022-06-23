using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class MenuManager : MonoBehaviour
{
    [SerializeField] string gameScene;
    [SerializeField] string skinScene;

    [SerializeField] Button play;
    
    [SerializeField] Button skin;
    
    [SerializeField] Button exit;
    // Start is called before the first frame update
    void Start()
    {
    
        play.onClick.AddListener(startGame);
        skin.onClick.AddListener(skinScreen);
        exit.onClick.AddListener(quitGame);

    }
    public void startGame()
    {
        SceneManager.LoadScene(gameScene);
    }
    public void skinScreen()
    {
        SceneManager.LoadScene(skinScene);
    }
    public void quitGame()
    {
        Debug.Log("Quitting");
        Application.Quit();
    }
}
