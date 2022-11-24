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

    public GameObject anvilSurface;

    // Start is called before the first frame update
    void Start()
    {
        centerOfShop = new Vector3(0, 0, 0);
        mainCam = Camera.main;
       // cameraPos = mainCam.ScreenToWorldPoint;
    }

    // Update is called once per frame
    void Update()
    {
        if(canUseStorageChest && Input.GetKeyDown(KeyCode.E))
        {
            Instantiate(anvilSurface, scriptManager.transform) ;
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
