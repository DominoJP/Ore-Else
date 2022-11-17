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

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(canUseStorageChest && Input.GetKeyDown(KeyCode.E))
        {
            Debug.Log("working");
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