using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HammerMinigame : MonoBehaviour
{

    
    public float currentWeaponScore;
    public float distFromTarget;
    public GameObject indicator;
    public GameObject target;
    public GameObject fillBar;
    public Rigidbody2D rbIndicator;

    public float moveSpeed;
    public Vector2 moveDirection;
    public bool isMovingUp;
    public bool isMovingDown;

    // Start is called before the first frame update
    void Awake()
    {
        moveDirection = new Vector2(0, 1);
        isMovingDown = false;
        isMovingUp = true;
        fillBar = GameObject.Find("FillBar");
        target = GameObject.Find("Target");
        indicator = GameObject.Find("Indicator");
        
    }

    // Update is called once per frame
    void Update()
    {
        ManageIndicatorMovement();
    }


    public void ManageIndicatorMovement()
    {
        rbIndicator.AddForce(moveDirection * moveSpeed);
    }


    private void OnTriggerEnter2D(Collider2D other)
    {
       
       
    }


}
