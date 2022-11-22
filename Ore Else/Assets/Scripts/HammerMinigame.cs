using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HammerMinigame : MonoBehaviour
{

    public PlayerCollisionManager playerColScript;
    public float currentWeaponScore;
    public float distFromTarget;
    public GameObject indicator;
    public GameObject target;
    public GameObject fillBar;


    // Start is called before the first frame update
    void Start()
    {
        playerColScript = GameObject.Find("Player").GetComponent<PlayerCollisionManager>();
        fillBar = GameObject.Find("FillBar");
        target = GameObject.Find("Target");
        indicator = GameObject.Find("Indicator");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
