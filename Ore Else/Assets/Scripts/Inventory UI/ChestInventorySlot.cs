using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChestInventorySlot : MonoBehaviour
{
    Item item;

    public Image icon;
    public Button TransferButton;
    public Button SelectButton;
    public Button RemoveButton;

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
        itemInfoLines[2] = "Value: " + value.ToString() + "\n";
        itemInfoLines[3] = "Quality: " + qualityScore.ToString() + "\n";

    }

    public void RemoveItem()
    {
        item = null;
        icon.sprite = null;
        icon.enabled = false;
        RemoveButton.interactable = false;
        TransferButton.interactable = false;
        SelectButton.interactable = false;
        qualityScoreUI = 0;
        nameUI = null;
        typeUI = null;
        valueUI = 0;
        hasItem = false;
    }



    public void RemoveItemFromInventoryScript()
    {
        ChestUI.instance.UpdateUI();
        ChestInventoryManager.instance.items.Remove(ChestInventoryManager.instance.items[trueIndexUI]);
        ChestUI.instance.UpdateUI();
    }

    public void TransferItem()
    {

        ChestUI.instance.UpdateUI();

        InventoryManager.instance.Add(item, qualityScoreUI, nameUI, typeUI, item.sprite, valueUI);

        RemoveItemFromInventoryScript();
        RemoveItem();

        ChestUI.instance.UpdateUI();
        InventoryUI.instance.UpdateUI();

        ItemInfoPanel.instance.gameObject.SetActive(false);
        ChestItemInfoPanel.instance.gameObject.SetActive(false);
        ItemInfoPanel.instance.lastUsedButtonIndex = -1;
        ChestItemInfoPanel.instance.lastUsedButtonIndex = -1;

    }

    public void SelectItem()
    {
        ChestUI.instance.UpdateUI();
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


    public void OnMainButton()
    {
        if (ChestItemInfoPanel.instance.lastUsedButtonIndex != trueIndexUI)
        {
            ChestItemInfoPanel.instance.ShowInfoPanel(itemInfoLines, trueIndexUI);
        }
    }


    public void ClearItemInfo()
    {
        if (ChestItemInfoPanel.instance.lastUsedButtonIndex == trueIndexUI)
        {
            ChestItemInfoPanel.instance.HideInfoPanel();
        }
    }

}
