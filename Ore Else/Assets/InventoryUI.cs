using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryUI : MonoBehaviour
{
    public static InventoryUI instance;

    public Transform slotsParent;

    public InventorySlot[] inventorySlots;


    public InventoryManager inventoryScript;


    private void Awake()
    {
        if (instance != null)
        {
            Debug.Log("inventory instance issue");
            return;
        }

        instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        inventoryScript = GameObject.Find("ScriptManager").GetComponent<InventoryManager>();

        inventorySlots = slotsParent.GetComponentsInChildren<InventorySlot>();

        UpdateUI();

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void UpdateUI()
    {

        Debug.Log("Updated Inventory");

         for(int i = 0; i < inventorySlots.Length; i++)
        {
            if (i < inventoryScript.items.Count)
            {
                inventorySlots[i].AddItem(inventoryScript.items[i], inventoryScript.items[i].qualityScore, inventoryScript.items[i].itemName, inventoryScript.items[i].type, inventoryScript.items[i].sprite, inventoryScript.items[i].value, inventoryScript.items[i].itemIndex);
                
                inventorySlots[i].trueIndexUI = i;
            }

            else
            {
                inventorySlots[i].RemoveItem();
            }

        }

        for (int i = 0; i < inventorySlots.Length; i++)
        {
            if (inventorySlots[i].hasItem && inventorySlots[i].chestOpen)
            {
                inventorySlots[i].EnableTransferButton();
            }

            
        }

        

    }

   


}
