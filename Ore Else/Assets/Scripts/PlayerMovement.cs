using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    public Rigidbody2D rb;
    public float moveDirectionX;
    public float moveDirectionY;
    public float moveSpeed;


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }



    public void ManageMovement()
    {
        moveDirectionX = Input.GetAxis("Horizontal");
        moveDirectionY = Input.GetAxis("Vertical");

        //rb.AddForce(

    }




}
