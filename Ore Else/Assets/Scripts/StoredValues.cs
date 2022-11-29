using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoredValues : MonoBehaviour
{


    public static StoredValues instance;

    public int money;

    


    // Start is called before the first frame update
    void Awake()
    {
        if(instance != null)
        {
            Debug.Log("StoredVales instance issue");
            return;
        }

        instance = this;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
