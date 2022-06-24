using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SkinInShop : MonoBehaviour
{
    public SSkinInfo skinInfo;
    public Image skinImage;
    public bool isSkinUnlocked;
    private void Awake(){
        skinImage.sprite = skinInfo.skinBodySprite;
    }
    
    public void onButtoPress(){
        PlayfabManager playfabManager = GameObject.Find("Main Camera").GetComponent<PlayfabManager>();
        if (isSkinUnlocked){
            //equip
        }else{
            //buy
        }
    }
}
