using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class ChestInventoryManager : MonoBehaviour
{

    public ChestUI inventoryUI;

    public static ChestInventoryManager instance;

    private void Awake()
    {
        if (instance != null)
        {
            Debug.Log("inventory instance issue");
            return;
        }

        instance = this;
    }

    private void Start()
    {
        inventoryUI = GameObject.Find("ChestCanvas").GetComponent<ChestUI>();
    }



    public List<Item> items = new List<Item>();

    public void Add(Item item, float qualityScore, string name, string itemType, Sprite sprite, int value)
    {
        if (CheckInventorySpace())
        {

            items.Add(Instantiate(item));

            int currentIndex = items.Count - 1;

            items[currentIndex].itemName = name;
            items[currentIndex].qualityScore = qualityScore;
            items[currentIndex].type = itemType;
            items[currentIndex].sprite = sprite;
            items[currentIndex].value = value;
            items[currentIndex].itemIndex = currentIndex;

            inventoryUI.UpdateUI();

        }



    }

    public bool CheckInventorySpace()
    {

        if (items.Count < 21)
        {
            return true;
        }

        else
        {
            return false;
        }

    }



}
