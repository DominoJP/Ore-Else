using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : MonoBehaviour
{

    public delegate void OnInventoryChange();
    public OnInventoryChange onInventoryChangeCallback;
    
    
    public List<Item> items = new List<Item>();

   public void Add(Item item, float qualityScore, string name, string itemType)
    {



        items.Add(Instantiate(item));

        int currentIndex = items.Count - 1;

        items[currentIndex].itemName = name;
        items[currentIndex].qualityScore = qualityScore;
       // items[itemIndex].value = value;
        items[currentIndex].type = itemType;


    }
   


}
