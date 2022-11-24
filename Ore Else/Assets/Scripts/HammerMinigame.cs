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

    public GameObject indicator;
    public GameObject target;
    public GameObject fillBar;
    public Rigidbody2D rbIndicator;

    public float moveSpeed;
    public Vector2 moveDirection;
    public bool isMovingUp;
    public bool isMovingDown;

    public bool isInTarget;

    public StoredValues storedValues;

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

            hitDistances.Clear();
            hitCounter = 0;

        }

            

    }

    public void AverageScores()
    {
        for(int i = 0; i < hitDistances.Count; i++)
        {
            currentPartScore = currentPartScore + hitDistances[i];
        }

        currentPartScore = currentPartScore / hitDistances.Count;
    }



    private void OnTriggerEnter2D(Collider2D other)
    {
       

       
    }


}
