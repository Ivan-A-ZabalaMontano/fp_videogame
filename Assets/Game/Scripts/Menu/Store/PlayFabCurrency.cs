using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PlayFab;
using PlayFab.ClientModels;
using UnityEngine.UI;

public class PlayFabCurrency : MonoBehaviour
{
    public Text crystalsValueText;
    //public int crystalsPrice; //Costo de la compra de item
    //public string itemName; //Nombre del item a comprar
    // Start is called before the first frame update
    void Start()
    {
        Login();
    }
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
        GetVirtualCurrency();
    }
    /*public void BuyItem(){
        var request = new SubtractUserVirtualCurrencyRequest{
            VirtualCurrency = "CR",
            Amount = crystalsPrice
        };
        PlayFabClientAPI.SubtractUserVirtualCurrency(request, OnSubtractionCoinSuccess, OnError);
    }*/
    public void GetApparance(){
          
    }
    public void SaveApearance(){
         
    }
    void OnGetUserIventorySuccess(GetUserInventoryResult result){
        int crystals = result.VirtualCurrency["CR"];
        crystalsValueText.text = crystals.ToString();
    } 
    public void GetVirtualCurrency(){
        PlayFabClientAPI.GetUserInventory(new GetUserInventoryRequest(),OnGetUserIventorySuccess,OnError);
    }
    void OnSubtractionCoinSuccess(ModifyUserVirtualCurrencyResult result){
        Debug.Log("Bought Item ");
    }
    void OnError(PlayFabError error){
        Debug.Log("Error: " + error.ErrorMessage);
    }
}
