using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PlayFab;
using PlayFab.ClientModels;
using UnityEngine.UI;
public class SkinToBuy : MonoBehaviour
{
    public int crystalsPrice; //Costo de la compra de item
    public string itemName; //Nombre del item a comprar
    [SerializeField] Button buy;
    // Start is called before the first frame update
    void Start()
    {
        buy.onClick.AddListener(BuyItem);
    }
    public void BuyItem(){
        var request = new SubtractUserVirtualCurrencyRequest{
            VirtualCurrency = "CR",
            Amount = crystalsPrice
        };
        PlayFabClientAPI.SubtractUserVirtualCurrency(request, OnSubtractionCoinSuccess, OnError);
    }
    void OnSubtractionCoinSuccess(ModifyUserVirtualCurrencyResult result){
        Debug.Log("Bought Item "+ itemName);
        PlayfabManager.instance.GetVirtualCurrency();
    }
    void OnError(PlayFabError error){
        Debug.Log("Error: " + error.ErrorMessage);
    }
}
