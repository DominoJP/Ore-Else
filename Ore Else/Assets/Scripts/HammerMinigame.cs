using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class HammerMinigame : MonoBehaviour
{

    public Canvas hammerCanvas;


    public string incomingItemType;
    public float incomingItemScore;

    public string outgoingItemType;
    public float outgoingItemScore;
    public int outgoingItemValue;


    public float currentPartScore;
    public float currentHitDistance;
    public int requiredHits = 8;
    public List<float> hitDistances = new List<float>();
    public int hitCounter = 0;
    public float finalItemScore;
    public float cooldown;
    

    public Sprite ironBladeIcon;
    public Sprite mithrilBladeIcon;
    public Sprite Orichalcum;
    

    public GameObject indicator;
    public GameObject target;
    public GameObject fillBar;
    public Rigidbody2D rbIndicator;

    public float moveSpeed;
    public Vector2 moveDirection;
    public bool isMovingUp;
    public bool isMovingDown;
    public bool isInTarget;
    public bool canHit;

    public Item dullBlade;

    
    public InventoryManager inventoryManager;

    // Start is called before the first frame update
    void Start()
    {
        //hammerCanvas = GameObject.Find("HammerGameCanvas").GetComponent<Canvas>();
        moveDirection = new Vector2(0, 1);
        isMovingDown = false;
        isMovingUp = true;
        fillBar = GameObject.Find("FillBar");
        target = GameObject.Find("Target");
        indicator = GameObject.Find("Indicator");
        canHit = true;
        moveSpeed = 4;

        SetIncomingValues();
        

        
       // Debug.Log("Test Start Function");

        inventoryManager = GameObject.Find("ScriptManager").GetComponent<InventoryManager>();


        requiredHits = 8;
        hitCounter = 0;

    }

    // Update is called once per frame
    void Update()
    {
        
        ManageIndicatorMovement();
        ManageHits();
    }


    public void ManageIndicatorMovement()
    {
        rbIndicator.velocity = (moveDirection * moveSpeed);
    }



    public void ManageHits()
    {

        if (Input.GetMouseButtonDown(0) && hitCounter < requiredHits && canHit) 
        {
            int hitsLeft = requiredHits - hitCounter;
            
            
                currentHitDistance = Mathf.Abs(target.transform.position.y - indicator.transform.position.y)/2.6f;
             


            if (isInTarget)
            {
                currentHitDistance /= 2;
            }

            hitDistances.Add(currentHitDistance*2);
            hitCounter++;

            if(hitsLeft > 5)
            {
                target.transform.localScale = new Vector2(1, Mathf.Abs(target.transform.localScale.y / 1.4f));
            }

            if (hitsLeft <= 5 && hitsLeft > 3)
            {
                target.transform.localScale = new Vector2(1, Mathf.Abs(target.transform.localScale.y / 1.8f));
            }

            if(hitsLeft <= 3)
            {
                target.transform.localScale = new Vector2(1, Mathf.Abs(target.transform.localScale.y / 2.2f));
            }
                
            

            
            canHit = false;
            moveSpeed += 1.4f;
        }




        if (hitCounter == requiredHits)
        {
            AverageScores();
           
           //
           //inventoryManager.items.Add(ScriptableObject.CreateInstance<Item>());

            //int currentIndex = inventoryManager.items.Count - 1;

            string prefix = GenerateName(finalItemScore);

            int value = Mathf.CeilToInt(finalItemScore * 1.2f);

            SetOutgoingItemValues();
           

            inventoryManager.Add(dullBlade, outgoingItemScore, prefix + " Dull Blade", outgoingItemType, ironBladeIcon, value);


            hitDistances.Clear();
            hitCounter = 0;
            currentPartScore = 0;

            ClearStoredValues();

            Destroy(gameObject);
        }

            

    }

    public void AverageScores()
    {
        for(int i = 0; i < hitDistances.Count; i++)
        {
            currentPartScore = currentPartScore + hitDistances[i];
        }

        currentPartScore = currentPartScore / hitDistances.Count;
        finalItemScore = (1 - currentPartScore) * 100;

        finalItemScore = (finalItemScore + incomingItemScore) / 2;

        if(finalItemScore < 0)
        {
            finalItemScore = 0;
        }
    }

    public string GenerateName(float quality)
    {
        string prefix;
        prefix = null;

        if(quality <= 25)
        {
            prefix = "Crude";
        }
        if (quality > 25 && quality <= 70)
        {
            prefix = "Decent";
        }
        if (quality > 70 && quality <= 90)
        {
            prefix = "Good";
        }
        if (quality > 90 && quality <= 100)
        {
            prefix = "Excellent";
        }

        return prefix;
        
        
    }

   
    public void ClearStoredValues()
    {
        StoredValues.instance.selectedItemIndex = ItemInfoPanel.instance.lastUsedButtonIndex;
        StoredValues.instance.outgoingItemType = InventoryUI.instance.inventorySlots[StoredValues.instance.selectedItemIndex].typeUI;
        StoredValues.instance.outgoingItemScore = InventoryUI.instance.inventorySlots[StoredValues.instance.selectedItemIndex].qualityScoreUI;
    }

    public void SetIncomingValues()
    {
        incomingItemScore = StoredValues.instance.outgoingItemScore;
        incomingItemType = StoredValues.instance.outgoingItemType;
    }

    public void SetOutgoingItemValues ()
    {

        if(incomingItemType == "Iron Ingot")
        {
            outgoingItemValue = Mathf.CeilToInt(finalItemScore * 1.2f);
            outgoingItemType = "Iron Blade";
           
        }

        if (incomingItemType == "Mithril Ingot")
        {
            outgoingItemValue = Mathf.CeilToInt(finalItemScore * 1.6f);
            outgoingItemType = "Mithril Blade";
            
        }

        if (incomingItemType == "Orichalcum Ingot")
        {
            outgoingItemValue = Mathf.CeilToInt(finalItemScore * 2f);
            outgoingItemType = "Orichalcum Blade";

        }
    }
}
