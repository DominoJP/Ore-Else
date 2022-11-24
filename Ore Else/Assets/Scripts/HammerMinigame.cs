using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HammerMinigame : MonoBehaviour
{

    
    public float currentPartScore;
    public float currentHitDistance;
    public int requiredHits = 8;
    public List<float> hitDistances = new List<float>();
    public int hitCounter = 0;
    public float finalItemScore;

    public GameObject indicator;
    public GameObject target;
    public GameObject fillBar;
    public Rigidbody2D rbIndicator;

    public float moveSpeed;
    public Vector2 moveDirection;
    public bool isMovingUp;
    public bool isMovingDown;
    public bool isInTarget;
    public ScriptableObject dullBlade;

    public StoredValues storedValues;
    public InventoryManager inventoryManager;

    // Start is called before the first frame update
    void Start()
    {
        moveDirection = new Vector2(0, 1);
        isMovingDown = false;
        isMovingUp = true;
        fillBar = GameObject.Find("FillBar");
        target = GameObject.Find("Target");
        indicator = GameObject.Find("Indicator");

        storedValues = GameObject.Find("ScriptManager").GetComponent<StoredValues>();
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

        if (Input.GetMouseButtonDown(0) && hitCounter < requiredHits) 
        {
            target.transform.localScale = new Vector2(1, Mathf.Abs(target.transform.localScale.y - ((1f/requiredHits)/2f)));

            if (!isInTarget)
             {
                currentHitDistance = Mathf.Abs(target.transform.position.y - indicator.transform.position.y);
             }


            if (isInTarget)
            {
                currentHitDistance = 0f;
            }

            hitDistances.Add(currentHitDistance);
            hitCounter++;
        }
        

       

        if (hitCounter == requiredHits)
        {
            AverageScores();
           
            inventoryManager.items.Add(ScriptableObject.CreateInstance<Item>());

            int currentIndex = inventoryManager.items.Count - 1;

            AddDullBladeToList(finalItemScore, currentIndex);
            

            hitDistances.Clear();
            hitCounter = 0;
            currentPartScore = 0;
            //target.transform.localScale = new Vector2(1, .5f);
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

    public void AddDullBladeToList(float quality, int currentIndex)
    {
        string prefix;
        prefix = null;

        if(quality <= 25)
        {
            prefix = "Crude";
        }
        if (quality > 25 && quality <= 50)
        {
            prefix = "Decent";
        }
        if (quality > 50 && quality <= 75)
        {
            prefix = "Good";
        }
        if (quality > 75 && quality <= 100)
        {
            prefix = "Excellent";
        }

        inventoryManager.items[currentIndex].itemName = prefix + " Dull Blade";
        inventoryManager.items[currentIndex].qualityScore = finalItemScore;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
       

       
    }


}
