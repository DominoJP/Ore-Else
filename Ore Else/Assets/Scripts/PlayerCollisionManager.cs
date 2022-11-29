using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollisionManager : MonoBehaviour
{

    public static PlayerCollisionManager instance;



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
    public Canvas inventoryCanvas;
    public bool localChestOpen;

    public bool inventoryOpen;

    public GameObject anvilSurface;
    public int frameCounter;

    //public Canvas hammerCanvas;

    // Start is called before the first frame update
    void Start()
    {
        //hammerCanvas.enabled = false;
        centerOfShop = new Vector3(0, 0, 0);
        mainCam = Camera.main;
        // cameraPos = mainCam.ScreenToWorldPoint;

        inventoryOpen = false;

        if (instance != null)
        {
            Debug.Log("player collision instance problem");
            return;
        }

        instance = this;

    }

    // Update is called once per frame
    void Update()
    {

        ManageActiveWorkstation();
       /* if (localChestOpen)
        {
            ChestUI.instance.UpdateUI();
            InventoryUI.instance.UpdateUI();
        }*/
    }


    private void FixedUpdate()
    {
        if (frameCounter < 1) 
        {
            frameCounter++;     
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


    public void ManageActiveWorkstation()
    {
        
        if (canUseAnvil && Input.GetKeyDown(KeyCode.E))
        {  
            Instantiate(anvilSurface, centerOfShop, Quaternion.Euler(0, 0, 0));
        }
  
        if (canUseShop && Input.GetKeyDown(KeyCode.E))
        { 
            for (int i = 0; i < InventoryUI.instance.inventorySlots.Length; i++)
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
            localChestOpen = true;
               
            for (int i = 0; i < InventoryUI.instance.inventorySlots.Length; i++) 
            {   
                InventoryUI.instance.inventorySlots[i].chestOpen = true; 
            }

            for (int i = 0; i < InventoryUI.instance.inventorySlots.Length; i++)
            {
                InventoryUI.instance.inventorySlots[i].EnableTransferButton();
            }

            for (int i = 0; i < ChestUI.instance.inventorySlots.Length; i++)
            {
                ChestUI.instance.inventorySlots[i].chestOpen = true;
            }

            for (int i = 0; i < ChestUI.instance.inventorySlots.Length; i++)
            {
                ChestUI.instance.inventorySlots[i].EnableTransferButton();
            }

        }
            
        if (!canUseStorageChest)
            
        {
            chestCanvas.enabled = false;
            localChestOpen = false;

            for (int i = 0; i < InventoryUI.instance.inventorySlots.Length; i++)
            {   
                InventoryUI.instance.inventorySlots[i].chestOpen = false;
            }

            for (int i = 0; i < InventoryUI.instance.inventorySlots.Length; i++)
            {
                InventoryUI.instance.inventorySlots[i].DisableTransferButton();
            }

            for (int i = 0; i < ChestUI.instance.inventorySlots.Length; i++)
            {
                ChestUI.instance.inventorySlots[i].chestOpen = false;
            }

            for (int i = 0; i < ChestUI.instance.inventorySlots.Length; i++)
            {
                ChestUI.instance.inventorySlots[i].DisableTransferButton();
            }
        }

        if (!inventoryOpen && Input.GetKeyDown(KeyCode.I))
        {
            inventoryCanvas.enabled = true;
            inventoryOpen = true;
            frameCounter = 0;
        }

        if (inventoryOpen && Input.GetKeyDown(KeyCode.I) && frameCounter == 1)
        {
            inventoryOpen = false;
            inventoryCanvas.enabled = false;
        }

    }



   

 }



