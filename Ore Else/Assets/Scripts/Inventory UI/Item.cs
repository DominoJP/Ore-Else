using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

[CreateAssetMenu(fileName = "New Item", menuName = "Item/Create New Item")]

public class Item : ScriptableObject
{
    
    public string type;
    public string itemName;
    public int value;
    public float qualityScore;
    public Sprite sprite;
    public int itemIndex;
    

}
