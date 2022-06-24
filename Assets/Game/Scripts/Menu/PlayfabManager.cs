using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PlayFab;
using PlayFab.ClientModels;
using Newtonsoft.Json;
using UnityEngine.UI;

public class PlayfabManager : MonoBehaviour
{
    public static PlayfabManager instance;

    [Header("Windows")]
    public GameObject nameWindow;
    public GameObject leaderboardWindow;

    [Header("Display name window")]
    public GameObject nameError;
    public GameObject nameInput;
    
    [Header("Leaderboard")]
    public GameObject rowPrefab;
    public Transform rowsParent;

    [Header("UI")]
    public Text crystalsValueText;

    private string input;
    // Start is called before the first frame update
    void Start()
    {
        nameWindow.SetActive(false);
        leaderboardWindow.SetActive(false);
        Login();
    }
    private void Awake(){
        instance = this;
    }
    // Update is called once per frame
    void Login(){
        var request = new LoginWithCustomIDRequest {
            CustomId = SystemInfo.deviceUniqueIdentifier,
            CreateAccount = true, 
            InfoRequestParameters = new GetPlayerCombinedInfoRequestParams {
                GetPlayerProfile = true
            }
        };
        PlayFabClientAPI.LoginWithCustomID(request,OnSuccess,OnError);
    }
    void OnSuccess(LoginResult result){
        Debug.Log("iniciaste o creaste, bien mierda");
        string name = null;
        if(result.InfoResultPayload.PlayerProfile != null){
            name = result.InfoResultPayload.PlayerProfile.DisplayName;
        }
        if (name == null){
            nameWindow.SetActive(true);
        }else{
            leaderboardWindow.SetActive(true);
        }
        GetVirtualCurrency();
    }
    void OnError(PlayFabError error){
        Debug.Log("la cagaste otra vez, piensa en cambiar tu forma de vivir por favor");
        Debug.Log(error.GenerateErrorReport());
    }
    public void SubmitNameButtom(string name){
        var request = new UpdateUserTitleDisplayNameRequest{
            DisplayName = name,
        };
        PlayFabClientAPI.UpdateUserTitleDisplayName(request, OnDisplayNameUpdate, OnError);
    }
    void OnDisplayNameUpdate(UpdateUserTitleDisplayNameResult result){
        Debug.Log("Update display name");
        nameWindow.SetActive(false);
        leaderboardWindow.SetActive(true);
    }
    public void ReadStringInput(string message){
        input = message;
        SubmitNameButtom(input);
    } 
    public void SendLeaderboard(int score){
        var request = new UpdatePlayerStatisticsRequest{
            Statistics = new List<StatisticUpdate>{
                new StatisticUpdate{
                    StatisticName = "Score",
                    Value = score
                }
            }
        };
        PlayFabClientAPI.UpdatePlayerStatistics(request, OnLeaderboardUpdate, OnError);
    }
    void OnLeaderboardUpdate(UpdatePlayerStatisticsResult result){
        Debug.Log("ahora todos pueden ver lo malo que eres, felicidades");
    }
    public void GetLeaderboard(){
        var request = new GetLeaderboardRequest{
            StatisticName="Score",
            StartPosition=0,
            MaxResultsCount=10
        };
        Debug.Log("los resultadajos los jalas exitosamente, como tu pija");
        PlayFabClientAPI.GetLeaderboard(request,OnLeaderboardGet,OnError);
    }
    void OnLeaderboardGet(GetLeaderboardResult result){
        foreach (Transform item in rowsParent){
            Destroy(item.gameObject);
        }
        foreach (var item in result.Leaderboard)
        {
            GameObject newGo = Instantiate(rowPrefab,rowsParent);
            Text[] texts = newGo.GetComponentsInChildren<Text>();
            texts[0].text = (item.Position + 1 ).ToString();
            texts[1].text = item.DisplayName; 
            texts[2].text = item.StatValue.ToString();
        }
    }
    public void GetVirtualCurrency(){
        PlayFabClientAPI.GetUserInventory(new GetUserInventoryRequest(),OnGetUserIventorySuccess,OnError);
    }
    void OnGetUserIventorySuccess(GetUserInventoryResult result){
        int crystals = result.VirtualCurrency["CR"];
        crystalsValueText.text = crystals.ToString();
    } 
    public void GetApparance(){

    }
    public void SaveApearance(){
        
    }
}
