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
    public bool hasItem;

    public int trueIndexUI;

   


    public void AddItem(Item newItem, float qualityScore, string name, string itemType, Sprite itemSprite, int value, int index)
    {
        item = newItem;
        
        

        qualityScoreUI = qualityScore;
        nameUI = name;
        typeUI = itemType;
        valueUI = value;

        icon.sprite = itemSprite;
        icon.enabled = true;
        SelectButton.interactable = true;
        RemoveButton.interactable = true;
        hasItem = true;
       
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
        qualityScoreUI = 0;
        nameUI = null;
        typeUI = null;
        valueUI = 0;
        hasItem = false;
        
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
        InventoryManager.instance.items.Remove(InventoryManager.instance.items[trueIndexUI]);
    }

    public void SellItem()
    {
        InventoryUI.instance.UpdateUI();
    }

    public void SelectItem()
    {
        InventoryUI.instance.UpdateUI();
    }

    public void EnableSellButton()
    {
        if (hasItem)
        {
            SellButton.interactable = true;
            RemoveButton.interactable = false;
        }
        
    }

    public void DisableSellButton()
    {
        SellButton.interactable = false;
        if (hasItem)
        {
            RemoveButton.interactable = true;
        }
    }

    public void TransferItem()
    {
        InventoryUI.instance.UpdateUI();

        ChestInventoryManager.instance.Add(item, qualityScoreUI, nameUI, typeUI, item.sprite, valueUI);

        RemoveItemFromInventoryScript();
        RemoveItem();

        InventoryUI.instance.UpdateUI();
    }

}
