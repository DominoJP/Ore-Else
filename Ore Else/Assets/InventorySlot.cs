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
    public Button TransferButton;

    public float qualityScoreUI;
    public string nameUI;
    public string typeUI;
    public int valueUI;
    public int indexUI;
    public bool hasItem;
    public bool chestOpen;

    public int trueIndexUI;

    public string itemInfo;
    public string[] itemInfoLines = new string[4];

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

        itemInfoLines[0] = "Name: " + name + "\n";
        itemInfoLines[1] = "Type: " + itemType + "\n";
        itemInfoLines[2] = "Value: "+ value.ToString() + "\n";
        itemInfoLines[3] = "Quality: " + qualityScore.ToString() + "\n";





    }

    public void RemoveItem()
    {
        item = null;
        icon.sprite = null;
        icon.enabled = false;
        RemoveButton.interactable = false;
        SellButton.interactable = false;
        SelectButton.interactable = false;
        TransferButton.interactable = false;
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
        InventoryUI.instance.UpdateUI();
    }

    public void SellItem()
    {
        InventoryUI.instance.UpdateUI();

        StoredValues.instance.money += valueUI;
        RemoveItem();
        RemoveItemFromInventoryScript();

        InventoryUI.instance.UpdateUI();

        ItemInfoPanel.instance.gameObject.SetActive(false);
        ChestItemInfoPanel.instance.gameObject.SetActive(false);
        ItemInfoPanel.instance.lastUsedButtonIndex = -1;
        ChestItemInfoPanel.instance.lastUsedButtonIndex = -1;

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
        }

    }

    public void EnableTransferButton()
    {
        if (hasItem)
        {
            TransferButton.interactable = true;

        }

    }

    public void DisableTransferButton()
    {
        TransferButton.interactable = false;

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
        if (chestOpen)
        {
            InventoryUI.instance.UpdateUI();

            ChestInventoryManager.instance.Add(item, qualityScoreUI, nameUI, typeUI, item.sprite, valueUI);

            RemoveItemFromInventoryScript();
            RemoveItem();

            InventoryUI.instance.UpdateUI();
            ChestUI.instance.UpdateUI();

            ItemInfoPanel.instance.gameObject.SetActive(false);
            ChestItemInfoPanel.instance.gameObject.SetActive(false);
            ItemInfoPanel.instance.lastUsedButtonIndex = -1;
            ChestItemInfoPanel.instance.lastUsedButtonIndex = -1;
        }
    }

    public void OnMainButton()
    {

        if (ItemInfoPanel.instance.lastUsedButtonIndex != trueIndexUI)
        {
            ItemInfoPanel.instance.ShowInfoPanel(itemInfoLines, trueIndexUI);
        }

        ChestUI.instance.UpdateUI();
        InventoryUI.instance.UpdateUI();

        // ItemInfoPanel.instance.HideInfoPanel();



    }

    public void ClearItemInfo()
    {
        if (ItemInfoPanel.instance.lastUsedButtonIndex == trueIndexUI)
        {
            ItemInfoPanel.instance.HideInfoPanel();
        }

        ChestUI.instance.UpdateUI();
        InventoryUI.instance.UpdateUI();

    } 
}
