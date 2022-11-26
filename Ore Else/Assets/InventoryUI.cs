using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryUI : MonoBehaviour
{

    public GameObject itemParent;

    public InventorySlot[] inventorySlots;


    public InventoryManager inventoryScript;

    // Start is called before the first frame update
    void Start()
    {
        inventoryScript = GameObject.Find("ScriptManager").GetComponent<InventoryManager>();
        inventorySlots = itemParent.GetComponentsInChildren<InventorySlot>();
        
    }

    // Update is called once per frame
    void Update()
    {
        UpdateUI();
    }

    public void UpdateUI()
    {
         for(int i = 0; i < inventorySlots.Length; i++)
        {
            if (i < inventoryScript.items.Count)
            {
                inventorySlots[i].AddItem(inventoryScript.items[i]);
            }
        }
    }

   


}
