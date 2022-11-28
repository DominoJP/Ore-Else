using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventorySlot : MonoBehaviour
{
    Item item;

    public Image icon;
    public Button SellButton;
    public Button SelectButton;
    public Button RemoveButton;

    public float qualityScoreUI;
    public string nameUI;
    public string typeUI;
    public int valueUI;
    public int indexUI;

   


    public void AddItem(Item newItem, float qualityScore, string name, string itemType, Sprite itemSprite, int value, int index)
    {
        item = newItem;
        
        

        qualityScoreUI = qualityScore;
        nameUI = name;
        typeUI = itemType;
        valueUI = value;

        icon.sprite = itemSprite;
        icon.enabled = true;

        RemoveButton.interactable = true;
        SellButton.interactable = true;
        SelectButton.interactable = true;
        indexUI = index;
        
    }

    public void RemoveItem()
    {
        item = null;
        icon.sprite = null;
        icon.enabled = false;
        RemoveButton.interactable = false;
        SellButton.interactable = false;
        SelectButton.interactable = false;
        
    }


    
    public void RemoveItemFromInventoryScript()
    {
        

       /* for (int i = 0; i < InventoryManager.instance.items.Count; i++)
        {
            if (InventoryManager.instance.items[i].itemIndex == indexUI)
            {
                InventoryManager.instance.items.Remove(InventoryManager.instance.items[i]);
            }
        }*/

        InventoryUI.instance.UpdateUI();
        InventoryManager.instance.items.Remove(InventoryManager.instance.items[indexUI]);
    }

    public void SellItem()
    {
        InventoryUI.instance.UpdateUI();
    }

    public void SelectItem()
    {
        InventoryUI.instance.UpdateUI();
    }

}
