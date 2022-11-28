using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class HammerMinigame : MonoBehaviour
{

    public Canvas hammerCanvas;

    public float currentPartScore;
    public float currentHitDistance;
    public int requiredHits = 8;
    public List<float> hitDistances = new List<float>();
    public int hitCounter = 0;
    public float finalItemScore;

    public Sprite barIcon;
    public Sprite TestIcon;
    

    public GameObject indicator;
    public GameObject target;
    public GameObject fillBar;
    public Rigidbody2D rbIndicator;

    public float moveSpeed;
    public Vector2 moveDirection;
    public bool isMovingUp;
    public bool isMovingDown;
    public bool isInTarget;

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

        
        
       // Debug.Log("Test Start Function");

        inventoryManager = GameObject.Find("ScriptManager").GetComponent<InventoryManager>();


        requiredHits = 8;
        hitCounter = 0;

    }

    // Update is called once per frame
    void Update()
    {
        //FindInventoryManager();
        ManageIndicatorMovement();
        ManageHits();
    }


    public void ManageIndicatorMovement()
    {
        rbIndicator.velocity = (moveDirection * moveSpeed);
    }


    public void ManageHits()
    {

        if (Input.GetMouseButtonDown(0) && hitCounter < requiredHits) 
        {
            
            if (!isInTarget)
             {
                currentHitDistance = Mathf.Abs(target.transform.position.y - indicator.transform.position.y)/2.6f;
             }


            if (isInTarget)
            {
                currentHitDistance = 0f;
            }

            hitDistances.Add(currentHitDistance);
            hitCounter++;

            target.transform.localScale = new Vector2(1, Mathf.Abs(target.transform.localScale.y - ((1f / requiredHits) / 2f)));

        }




        if (hitCounter == requiredHits)
        {
            AverageScores();
           
           //
           //inventoryManager.items.Add(ScriptableObject.CreateInstance<Item>());

            //int currentIndex = inventoryManager.items.Count - 1;

            string prefix = GenerateName(finalItemScore);

            int value = Mathf.CeilToInt(finalItemScore * 1.2f);

           

            inventoryManager.Add(dullBlade, finalItemScore, prefix + " Dull Blade", "Unsharpened Blade", barIcon, value);


            hitDistances.Clear();
            hitCounter = 0;
            currentPartScore = 0;
           

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

   



}
