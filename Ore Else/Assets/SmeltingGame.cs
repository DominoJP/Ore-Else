using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmeltingGame : MonoBehaviour
{
    [Header("Smelting Area")]
    [SerializeField] Transform TopBoundary;
    [SerializeField] Transform LowBoundary;

    [Header("Ingot Settings")]
    [SerializeField] Transform Ingot;
    [SerializeField] float SmoothMotion= 3f; //Smooth ingot movement
    [SerializeField] float IngotTimeRandomizer= 3f; //How often the ingot will move.

    float IngotPosition;
    float IngotSpeed;
    float IngotTimer;
    float IngotTargetPosition;

   

    private void MoveIngot()
    {
     IngotTimer -= Time.deltaTime;
        if (IngotTimer < 0)
        {
            IngotTimer=Random.value + IngotTimeRandomizer;
            IngotTargetPosition = Random.value;
        }
        IngotPosition = Mathf.SmoothDamp(IngotPosition, IngotTargetPosition, ref IngotSpeed, SmoothMotion);
        Ingot.position= Vector3.Lerp(LowBoundary.position, TopBoundary.position, IngotPosition);
    }
    private void FixedUpdate()
    {
        MoveIngot();
    }

}
