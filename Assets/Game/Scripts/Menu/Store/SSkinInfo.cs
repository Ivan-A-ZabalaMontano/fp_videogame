using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable, CreateAssetMenu(fileName = "New Skin", menuName = "Create New Skin")]
public class SSkinInfo : ScriptableObject {
    public enum SkinIDs {skin1, skin2, skin3}
    public SkinIDs skinID;
     
    public Sprite skinHeadSprite;
    public Sprite skinBodySprite;
    public Sprite skinSwordSprite;
    public Sprite skinHandSprite;
    public int skinPrice;
}
