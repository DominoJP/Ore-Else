using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChestUI : MonoBehaviour
{
    public static ChestUI instance;

    public Transform slotsParent;

    public ChestInventorySlot[] inventorySlots;


    public ChestInventoryManager inventoryScript;


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
        inventoryScript = GameObject.Find("ScriptManager").GetComponent<ChestInventoryManager>();

        inventorySlots = slotsParent.GetComponentsInChildren<ChestInventorySlot>();

        UpdateUI();

    }

    // Update is called once per frame
    void Update()
    {
        //UpdateUI();
    }

    public void UpdateUI()
    {

        Debug.Log("Updated Chest Inventory");

        for (int i = 0; i < inventorySlots.Length; i++)
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


    }




}
