using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ChooseItem : MonoBehaviour
{

    public static ChooseItem instance;

    private void Awake()
    {
        if (instance != null)
        {
            Debug.Log("instance issue");
            return;
        }

        instance = this;
        StoredValues.instance.selectedItemIndex = -1;
    }


    public int frameCounter;

    public Canvas chooseItem;
    public TextMeshProUGUI text;
    public TextMeshProUGUI buttonText;

    public bool canPlay = false;
    public bool noItem = false;

    
    public void ResetValues()
    {
        text.text = "Select the item you want to use and click play";
        buttonText.text = "Play";
        noItem = false;
        canPlay = false;
        StoredValues.instance.selectedItemIndex = -1;
    }

    public void SendItemIndex()
    {
        StoredValues.instance.selectedItemIndex = ItemInfoPanel.instance.lastUsedButtonIndex;

        if (StoredValues.instance.selectedItemIndex >= 0)
        {
            
            StoredValues.instance.outgoingItemType = InventoryUI.instance.inventorySlots[StoredValues.instance.selectedItemIndex].typeUI;
            StoredValues.instance.outgoingItemScore = InventoryUI.instance.inventorySlots[StoredValues.instance.selectedItemIndex].qualityScoreUI;
            StoredValues.instance.outgoingItemValue = InventoryUI.instance.inventorySlots[StoredValues.instance.selectedItemIndex].valueUI;


        }

        if (noItem)
        {
            ExitMenu();
        }

        if (StoredValues.instance.selectedItemIndex < 0 && !noItem)
        {
            CantPlay();
        }

        CheckItemType();

    }


    

    public void ExitMenu()
    {
        noItem = false;
        ResetValues();
        chooseItem.enabled = false;
    }

    public void CantPlay()
    {
        canPlay = false;
        text.text = "This item is cannot be used here";
        buttonText.text = "Exit";
        noItem = true;
    }

    public void CheckItemType()
    {
        if (PlayerCollisionManager.instance.canUseAnvil)
        {
            if (StoredValues.instance.outgoingItemType == "Iron Ingot" || StoredValues.instance.outgoingItemType == "Mithril Ingot" || StoredValues.instance.outgoingItemType == "Orichalcum Ingot")
            {
                PlayerCollisionManager.instance.SpawnAnvil();
                DeleteItem();
                ResetValues();
                chooseItem.enabled = false;
            }

            else
            {
                CantPlay();
            }

        }

        if (PlayerCollisionManager.instance.canUseForge)
        {
            if(StoredValues.instance.outgoingItemType == "Raw Iron" || StoredValues.instance.outgoingItemType == "Raw Mithril" || StoredValues.instance.outgoingItemType == "Raw Orichalcum")
            {
                PlayerCollisionManager.instance.SpawnForge();
                DeleteItem();
                ResetValues();
                chooseItem.enabled = false;
            }
            else
            {
                CantPlay();
            }
        }

        if (PlayerCollisionManager.instance.canUseWoodworkingBench)
        {
            if (StoredValues.instance.outgoingItemType == "Raw Oak" || StoredValues.instance.outgoingItemType == "Raw Maple" || StoredValues.instance.outgoingItemType == "Raw Mahogany")
            {
                PlayerCollisionManager.instance.SpawnForge();
                DeleteItem();
                ResetValues();
                chooseItem.enabled = false;
            }
            else
            {
                CantPlay();
            }

        }
    }

    public void DeleteItem()
    {
        InventoryUI.instance.inventorySlots[StoredValues.instance.selectedItemIndex].RemoveItem();
        InventoryUI.instance.inventorySlots[StoredValues.instance.selectedItemIndex].RemoveItemFromInventoryScript();
    }
}
