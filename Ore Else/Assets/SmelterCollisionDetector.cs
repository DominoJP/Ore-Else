using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmelterCollisionDetector : MonoBehaviour
{
    // Start is called before the first frame update

    public bool isInContact;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("SmeltIngot"))
        {
            isInContact = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("SmeltIngot"))
        {
            isInContact = false ;
        }
    }

}
