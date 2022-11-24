using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class HammerMinigame : MonoBehaviour
{

    
    public float currentWeaponScore;
    public float currentHitDistance;
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
    void Awake()
    {
        moveDirection = new Vector2(0, 1);
        isMovingDown = false;
        isMovingUp = true;
        fillBar = GameObject.Find("FillBar");
        target = GameObject.Find("Target");
        indicator = GameObject.Find("Indicator");

        storedValues = GameObject.Find("ScriptManager").GetComponent<StoredValues>();
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

        for (int i = 0; i < 8; i++)
        {
            if (Input.GetMouseButtonDown(0)) 
            {
                if (!isInTarget)
                {
                    currentHitDistance = Mathf.Abs(target.transform.position.y - indicator.transform.position.y);
                }

            }

            if (isInTarget)
            {
                currentHitDistance = 0f;
            }
            

        }
    }



    private void OnTriggerEnter2D(Collider2D other)
    {
       

       
    }


}
