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

    [Header("MeltingPoint Settings")]
    [SerializeField] Transform MeltingPoint;
    [SerializeField] float MeltingPointSize = .18f;
    [SerializeField] float MeltingPointSpeed = .1f;
    [SerializeField] float MeltingPointGravity = .05f;
    float MeltingPointPosition;
    float MeltingPointVelocity;

    [Header("ProgressBar Settings")]
    [SerializeField] Transform ProgressBarContainer;
    [SerializeField] float MeltingPointPower;
    [SerializeField] float ProgressBarDecay;
    float IngotProgress;

    private void Start()
    {
        IngotProgress = 0.3f;
    }

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

    private void MoveMeltingPoint()
    {
        if(Input.GetMouseButton(0))
        {
            MeltingPointVelocity += MeltingPointSpeed * Time.deltaTime;
            Debug.Log("Jelp");
        }
        MeltingPointVelocity -= MeltingPointGravity * Time.deltaTime;

        MeltingPointPosition += MeltingPointVelocity;

        if(MeltingPointPosition -MeltingPointSize / 2 <= 0 && MeltingPointVelocity < 0)
        {
            MeltingPointVelocity = 0;
        }

        if(MeltingPointPosition + MeltingPointSize / 2 >= 1 && MeltingPointVelocity > 0)
        {
            MeltingPointVelocity = 0; 
        }
        MeltingPointPosition = Mathf.Clamp(MeltingPointPosition, MeltingPointSize / 2, 1 - MeltingPointSize / 2);
        MeltingPoint.position = Vector3.Lerp(LowBoundary.position, TopBoundary.position, MeltingPointPosition);
    }

    private void CheckProgress()
    {
        Vector3 ProgressBarScale = ProgressBarContainer.localScale;
        ProgressBarScale.y = IngotProgress;
        ProgressBarContainer.localScale = ProgressBarScale;

        float min = MeltingPointPosition - MeltingPointSize / 2;
        float max = MeltingPointPosition + MeltingPointSize / 2;

        if(min < IngotPosition && IngotPosition < max)
        {
            IngotProgress += MeltingPointPower + Time.deltaTime;
            if(IngotProgress >= 1)
            {
                int IngotQuality = 100;
                string prefix = GenerateName(IngotQuality);

                Debug.Log("You Win!");
            }
        }
        else
        {
            IngotProgress -= ProgressBarDecay + Time.deltaTime;
            if(IngotProgress <= 0)
            {
                int IngotQuality = 0;
                string prefix = GenerateName(IngotQuality);
                Debug.Log("Lose");
            }
        }
        IngotProgress=Mathf.Clamp(IngotProgress, 0, 1);

    }

    public string GenerateName(float quality)
    {
        string prefix;
        prefix = null;
        if (quality <= 99)
        {
            prefix = "Crude";
        }
        if (quality >= 100)
        {
            prefix = "Heated Ingot";
        }
        return prefix;
    }


        private void FixedUpdate()
    {
        MoveIngot();
        MoveMeltingPoint();
        CheckProgress();
    }

}
