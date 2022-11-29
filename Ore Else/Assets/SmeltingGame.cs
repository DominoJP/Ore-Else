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
   public float IngotPosition;
    float IngotSpeed;
    float IngotTimer;
    public float IngotTargetPosition;

    [Header("MeltingPoint Settings")]
    [SerializeField] Transform MeltingPoint;
    [SerializeField] float MeltingPointSize = .18f;
    [SerializeField] float MeltingPointSpeed = .1f;
    [SerializeField] float MeltingPointGravity = .05f;
    public float MeltingPointPosition;
    float MeltingPointVelocity;

    [Header("ProgressBar Settings")]
    [SerializeField] Transform ProgressBarContainer;
    [SerializeField] float MeltingPointPower;
    [SerializeField] float ProgressBarDecay;
    float IngotProgress;

    [Header("Andrew Things")]
    public SmelterCollisionDetector smelterCol;
    public float totalFrameCounter;
    public float touchingFrameCounter;
    public string incomingItemType;
    public float incomingItemScore;
    public string outgoingItemType;
    public float outgoingItemScore;
    public int outgoingItemValue;
    public string outgoingItemName;
    public Sprite outgoingItemSprite;
    public float finalScore;
    public Sprite ironBar;
    public Sprite mithrilBar;
    public Sprite orichalcumBar;
    public bool isOnTarget;
    public float distance;

    private void Start()
    {
        IngotProgress = 0f;
        SetIncomingValues();
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

        IngotProgress = totalFrameCounter / 500f;
        distance = Mathf.Abs(MeltingPointPosition - IngotPosition);
       if (distance < 0.1f)
        {
            isOnTarget = true;
        }

        if (distance >= 0.1f)
        {
            isOnTarget = false;
        }
    }

    public string GenerateName(float quality)
    {
        string prefix;
        prefix = null;

        if (quality <= 25)
        {
            prefix = "Crude";
        }
        if (quality > 25 && quality <= 70)
        {
            prefix = "Decent";
        }
        if (quality > 70 && quality <= 90)
        {
            prefix = "Good";
        }
        if (quality > 90 && quality <= 100)
        {
            prefix = "Excellent";
        }

        return prefix;
    }


        private void FixedUpdate()
    {
        MoveIngot();
        MoveMeltingPoint();
        CheckProgress();
        
        TrackScore();


        if(totalFrameCounter >= 500f)
        {
            float localFinalScore;

            localFinalScore = (touchingFrameCounter / totalFrameCounter) * 100f;
            Debug.Log(localFinalScore);
            string prefix = GenerateName(localFinalScore);
            SetOutgoingItemValues(prefix,localFinalScore);
            InventoryManager.instance.Add(new Item(), localFinalScore, outgoingItemName, outgoingItemType, outgoingItemSprite, outgoingItemValue);
            ClearStoredValues();
            Destroy(gameObject);
        }
    }

    public void TrackScore()
    {

        if (totalFrameCounter < 501f)
        {
            totalFrameCounter++;

            if (isOnTarget)
            {
                touchingFrameCounter++;
            }
        }
        
    }

    

    public void SetIncomingValues()
    {
        incomingItemScore = StoredValues.instance.outgoingItemScore;
        incomingItemType = StoredValues.instance.outgoingItemType;
    }

    public void SetOutgoingItemValues(string prefix, float score)
    {

        if (incomingItemType == "Raw Iron")
        {
            outgoingItemValue = Mathf.CeilToInt(score * 1.2f);
            outgoingItemType = "Iron Ingot";
            outgoingItemName = prefix + " Iron Ingot";
            outgoingItemSprite = ironBar;
        }

        if (incomingItemType == "Raw Mithril")
        {
            outgoingItemValue = Mathf.CeilToInt(score * 1.6f);
            outgoingItemType = "Mithril Ingot";
            outgoingItemName = prefix + " Mithril Ingot";
            outgoingItemSprite = mithrilBar;
        }

        if (incomingItemType == "Raw Orichalcum")
        {
            outgoingItemValue = Mathf.CeilToInt(score * 2f);
            outgoingItemType = "Orichalcum Ingot";
            outgoingItemName = prefix + " Orichalcum Ingot";
            outgoingItemSprite = orichalcumBar;
        }


        
    }

    public void ClearStoredValues()
    {
        StoredValues.instance.selectedItemIndex = ItemInfoPanel.instance.lastUsedButtonIndex;
        StoredValues.instance.outgoingItemType = InventoryUI.instance.inventorySlots[StoredValues.instance.selectedItemIndex].typeUI;
        StoredValues.instance.outgoingItemScore = InventoryUI.instance.inventorySlots[StoredValues.instance.selectedItemIndex].qualityScoreUI;
    }

}
