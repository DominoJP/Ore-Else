using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollisionManager : MonoBehaviour
{


    public bool canUseStorageChest;
    public bool canUseForge;
    public bool canUseAnvil;
    public bool canUseWoodworkingBench;
    public bool canUseGemStation;
    public bool canUseShop;
    public bool canUseEnchantingStation;
    public Vector3 cameraPos;
    public Camera mainCam;
    public Vector3 centerOfShop;
    public GameObject scriptManager;
    public Canvas chestCanvas;

    public GameObject anvilSurface;

    //public Canvas hammerCanvas;

    // Start is called before the first frame update
    void Start()
    {
        //hammerCanvas.enabled = false;
        centerOfShop = new Vector3(0, 0, 0);
        mainCam = Camera.main;
       // cameraPos = mainCam.ScreenToWorldPoint;
    }

    // Update is called once per frame
    void Update()
    {
        if(canUseAnvil && Input.GetKeyDown(KeyCode.E))
        {
            Instantiate(anvilSurface, centerOfShop, Quaternion.Euler(0, 0, 0));

        }

        if(canUseShop && Input.GetKeyDown(KeyCode.E))
        {
            for(int i = 0; i < InventoryUI.instance.inventorySlots.Length; i++)
            {
                InventoryUI.instance.inventorySlots[i].EnableSellButton();
            }
        }

        if (!canUseShop)
        {
            for (int i = 0; i < InventoryUI.instance.inventorySlots.Length; i++)
            {
                InventoryUI.instance.inventorySlots[i].DisableSellButton();
            }
        }

        if (canUseStorageChest && Input.GetKeyDown(KeyCode.E))
        {
            chestCanvas.enabled = true;
            
            for(int i = 0; i < InventoryUI.instance.inventorySlots.Length; i++)
            {
                InventoryUI.instance.inventorySlots[i].chestOpen = true;
            }

        }

        if (!canUseStorageChest)
        {
            chestCanvas.enabled = false;

            for (int i = 0; i < InventoryUI.instance.inventorySlots.Length; i++)
            {
                InventoryUI.instance.inventorySlots[i].chestOpen = false;
            }
        }

    }


    




    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("StorageChest"))
        {
            canUseStorageChest = true;
        }

        if (other.CompareTag("Forge"))
        {
            canUseForge = true;
        }

        if (other.CompareTag("Anvil"))
        {
            canUseAnvil = true;
        }

        if (other.CompareTag("WoodworkingBench"))
        {
            canUseWoodworkingBench = true;
        }

        if (other.CompareTag("GemStation"))
        {
            canUseGemStation = true;
        }

        if (other.CompareTag("Shop"))
        {
            canUseShop = true;
        }

        if (other.CompareTag("EnchantingStation"))
        {
            canUseEnchantingStation = true;
        }
    }


    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("StorageChest"))
        {
            canUseStorageChest = false;
        }

        if (other.CompareTag("Forge"))
        {
            canUseForge = false;
        }

        if (other.CompareTag("Anvil"))
        {
            canUseAnvil = false;
        }

        if (other.CompareTag("WoodworkingBench"))
        {
            canUseWoodworkingBench = false;
        }

        if (other.CompareTag("GemStation"))
        {
            canUseGemStation = false;
        }

        if (other.CompareTag("Shop"))
        {
            canUseShop = false;
        }

        if (other.CompareTag("EnchantingStation"))
        {
            canUseEnchantingStation = false;
        }
    }


}
