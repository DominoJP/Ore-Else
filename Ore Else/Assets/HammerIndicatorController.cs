using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class HammerIndicatorController : MonoBehaviour
{

    public HammerMinigame hammerGameScript;
    

    // Start is called before the first frame update
    void Awake()
    {
        hammerGameScript = GameObject.Find("AnvilSurface").GetComponent<HammerMinigame>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("TopBumper") && hammerGameScript.isMovingUp)
        {
            hammerGameScript.isMovingUp = false;
            hammerGameScript.isMovingDown = true;
            hammerGameScript.moveDirection = new Vector2(0, -1);
            hammerGameScript.canHit = true;
        }

        if (other.CompareTag("BottomBumper") && hammerGameScript.isMovingDown)
        {
            hammerGameScript.isMovingUp = true;
            hammerGameScript.isMovingDown = false;
            hammerGameScript.moveDirection = new Vector2(0, 1);
            hammerGameScript.canHit = true;
        }

        if (other.CompareTag("HammerTarget"))
        {
            hammerGameScript.isInTarget = true;
        }

    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("HammerTarget"))
        {
            hammerGameScript.isInTarget = false;
        }
    }

}
