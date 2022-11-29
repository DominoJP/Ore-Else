using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class ChestItemInfoPanel : MonoBehaviour
{

    public static ChestItemInfoPanel instance;


    public TextMeshProUGUI text;
    public bool isPanelOpen;
    //public bool isPanelClosed;

    public int lastUsedButtonIndex = -1;

    public int frameCounter;

    // Start is called before the first frame update
    void Awake()
    {
        if (instance != null)
        {
            Debug.Log("item info instance issue");
            return;
        }

        instance = this;

    }

    private void Start()
    {
        
        gameObject.SetActive(false);
        isPanelOpen = false;

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (frameCounter < 1)
        {
            frameCounter++;
        }
    }

    public void ShowInfoPanel(string[] itemInfo, int slotIndex)
    {
        if (slotIndex != lastUsedButtonIndex)
        {
            gameObject.SetActive(true);
            text.text = itemInfo[0] + itemInfo[1] + itemInfo[2] + itemInfo[3];
            frameCounter = 0;
            isPanelOpen = true;
            lastUsedButtonIndex = slotIndex;
        }

        ChestUI.instance.UpdateUI();
        InventoryUI.instance.UpdateUI();
        ItemInfoPanel.instance.gameObject.SetActive(false);




    }


    public void HideInfoPanel()
    {

        if (frameCounter > 0)
        {
            gameObject.SetActive(false);
            text.text = string.Empty;
            isPanelOpen = false;
            lastUsedButtonIndex = -1;
        }

        ItemInfoPanel.instance.gameObject.SetActive(false);

        //isPanelClosed = true;

        

    }


}
