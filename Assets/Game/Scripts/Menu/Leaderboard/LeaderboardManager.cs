using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PlayFab;
using PlayFab.ClientModels;
using Newtonsoft.Json;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LeaderboardManager : MonoBehaviour
{
    [SerializeField] Button menu;
    [SerializeField] string MenuScene;
    // Start is called before the first frame update
    void Start()
    {
        menu.onClick.AddListener(skinScreen);
    }
    public void skinScreen()
    {
        SceneManager.LoadScene(MenuScene);
    }
}
