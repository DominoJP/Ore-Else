using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShopUI : MonoBehaviour
{

    

    public Sprite ironSprite;
    public Sprite mithrilSprite;
    public Sprite orichalcumSprite;
    public Sprite oakSprite;
    public Sprite mapleSprite;
    public Sprite mahoganySprite;
    public Sprite sapphireSprite;
    public Sprite emeraldSprite;
    public Sprite rubySprite;

    public int ironCost;
    public int mithrilCost;
    public int orichalcumCost;
    public int oakCost;
    public int mapleCost;
    public int mahoganyCost;
    public int sapphireCost;
    public int emeraldCost;
    public int rubyCost;

    

    public void Iron()
    {
        StoredValues.instance.money -= ironCost;
        InventoryManager.instance.Add(new Item(), 0, "Iron Ore", "Raw Iron", ironSprite, ironCost);
    }

    public void Mithril()
    {
        StoredValues.instance.money -= mithrilCost;
        InventoryManager.instance.Add(new Item(), 0, "Mithril Ore", "Raw Mithril", mithrilSprite, mithrilCost);
    }

    public void Orichalcum()
    {
        StoredValues.instance.money -= orichalcumCost;
        InventoryManager.instance.Add(new Item(), 0, "Orichalcum Ore", "Raw Orichalcum", orichalcumSprite, orichalcumCost);
    }

    public void Oak()
    {
        StoredValues.instance.money -= oakCost;
        InventoryManager.instance.Add(new Item(), 0, "Oak Wood", "Raw Oak", oakSprite, oakCost);
    }

    public void Maple()
    {
        StoredValues.instance.money -= mapleCost;
        InventoryManager.instance.Add(new Item(), 0, "Maple Wood", "Raw Maple", mapleSprite, mapleCost);
    }

    public void Mahogany()
    {
        StoredValues.instance.money -= mahoganyCost;
        InventoryManager.instance.Add(new Item(), 0, "Mahogany Wood", "Raw Mahogany", mahoganySprite, mahoganyCost);
    }

    public void Sapphire()
    {
        StoredValues.instance.money -= sapphireCost;
        InventoryManager.instance.Add(new Item(), 0, "Sapphire", "Sapphire", sapphireSprite, sapphireCost);
    }

    public void Emerald()
    {
        StoredValues.instance.money -= emeraldCost;
        InventoryManager.instance.Add(new Item(), 0, "Emerald", "Emerald", emeraldSprite, emeraldCost);
    }

    public void Ruby()
    {
        StoredValues.instance.money -= rubyCost;
        InventoryManager.instance.Add(new Item(), 0, "Ruby", "Ruby", rubySprite, rubyCost);
    }


}
