using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShopUI : MonoBehaviour
{

    public Sprite ironSprite;



    public void Iron()
    {
        StoredValues.instance.money -= 10;
        InventoryManager.instance.Add(new Item(), 0, "Iron Ore", "Raw Material", ironSprite, 10);
    }

    public void Mithril()
    {
        StoredValues.instance.money -= 20;
    }

    public void Orichalcum()
    {
        StoredValues.instance.money -= 30;
    }

    public void Oak()
    {
        StoredValues.instance.money -= 10;
    }

    public void Maple()
    {
        StoredValues.instance.money -= 20;
    }

    public void Mahogany()
    {
        StoredValues.instance.money -= 30;
    }

    public void Sapphire()
    {
        StoredValues.instance.money -= 10;
    }

    public void Emerald()
    {
        StoredValues.instance.money -= 20;
    }

    public void Ruby()
    {
        StoredValues.instance.money -= 30;
    }


}
