using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PlayFab;
using PlayFab.ClientModels;

public class PlayfabManager : MonoBehaviour
{
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
                    StatisticName = "PlatformScore",
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
            StatisticName="PlataformScore",
            StartPosition=0,
            MaxResultsCount=10
        };
        PlayFabClientAPI.GetLeaderboard(request,OnLeaderboardGet,OnError);
    }
    void OnLeaderboardGet(GetLeaderboardResult result){
        foreach (var item in result.Leaderboard)
        {
            Debug.Log(item.Position + " " + item.PlayFabId + " " + item.StatValue);
        }
    }
}
