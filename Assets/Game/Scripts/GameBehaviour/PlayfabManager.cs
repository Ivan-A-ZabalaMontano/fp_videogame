using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PlayFab;
using PlayFab.ClientModels;
using Newtonsoft.Json;
using UnityEngine.UI;

public class PlayfabManager : MonoBehaviour
{
    public GameObject rowPrefab;
    public Transform rowsParent;
    // Start is called before the first frame update
    void Start()
    {
        Login();
    }

    // Update is called once per frame
    void Login(){
        var request = new LoginWithCustomIDRequest {
            CustomId = SystemInfo.deviceUniqueIdentifier,
            CreateAccount = true
        };
        PlayFabClientAPI.LoginWithCustomID(request,OnSuccess,OnError);
    }
    void OnSuccess(LoginResult result){
        Debug.Log("iniciaste o creaste, bien mierda");
    }
    void OnError(PlayFabError error){
        Debug.Log("la cagaste otra vez, piensa en cambiar tu forma de vivir por favor");
        Debug.Log(error.GenerateErrorReport());
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
            texts[1].text = item.PlayFabId; 
            texts[2].text = item.StatValue.ToString();
        }
    }
    #region Leaderboard
    /*public void getLeaderboard1(){
        var requestLeaderboard = new GetLeaderboardRequest{
            StartPosition=0,
            StatisticName="PlayerHighscore";
        }
    }*/
    #endregion Leaderboard
}
