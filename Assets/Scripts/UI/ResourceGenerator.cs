using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ResourceGenerator : MonoBehaviour
{
    #region Structs

    [System.Serializable]
    public struct UpgradeStats
    {
        public int level;
        public int cost;
        public int moneyPerCycle;
        public float cycleTime;
    }

    #endregion

    #region Inspector Fields

    public Text MoneyText;

    [Space(20)]
    public GameManager.ResourceType ResourceType;

    [Space(20)]
    public Sprite[] ResourceIcons;
    
    [Space(20)]
    public UpgradeStats[] Stats;

    [Space(20)]
    public Text ResourceLevelText;

    [Space(10)]
    public Image ResourceButtonImage;

    [Space(10)]
    public Slider ResourceProgressBar;

    #endregion

    #region Runtime Fields

    private int ResourceID;
    private int ResourceLevel;
    private float ResourceTimer;
    private float ResourceCycleTime;
    private int MaxStatLevel;

    private Transform Parent;

    #endregion

    #region Monobehavior

    // Start is called before the first frame update
    void Start()
    {
        // Set Parent var
        Parent = gameObject.transform;

        // Used to get ResourceID
        int iDCounter = 0;

        // Gets ResourceID from GameManager list of Resources
        foreach(GameManager.Resource current in GameManager.main.Resources){
            if(current.name == ResourceType){
                ResourceID = iDCounter;
                break;
            }
            iDCounter++;
        }

        // Setup variables
        MoneyText.text = GameManager.main.Money.ToString();
        ResourceLevel = GameManager.main.Resources[ResourceID].level;
        ResourceTimer = Stats[ResourceLevel].cycleTime;

        ResourceLevelText.text = "Lv. " + ResourceLevel.ToString();

        MaxStatLevel = GameManager.main.MaxStatLevel;
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log("Resource Level: " + ResourceLevel);

        if (ResourceLevel > 0)
        {
            // Timers
            ResourceTimer += Time.deltaTime;
            ResourceProgressBar.value = ResourceTimer / ResourceCycleTime;

            // Adds money if timer is finished
            if (ResourceTimer > Stats[ResourceLevel].cycleTime)
            {
                ResourceTimer -= Stats[ResourceLevel].cycleTime;
                GameManager.main.Money += Stats[ResourceLevel].moneyPerCycle;
                MoneyText.text = GameManager.main.Money.ToString();
            }
        }
    }

    #endregion

    #region Public Methods

    // Upgrade the resource if player has enough money. Saves new values to GameManager
    public void UpgradeResource()
    {
        if (ResourceLevel + 1 <= MaxStatLevel)
        {
            if (GameManager.main.Money >= Stats[ResourceLevel + 1].cost)
            {
                ResourceLevel = ResourceLevel + 1;
                GameManager.main.Resources[ResourceID].level = ResourceLevel;

                //Debug.Log("New " + ResourceType.ToString() + " Level: " + ResourceLevel.ToString());

                GameManager.main.Money -= Stats[ResourceLevel].cost;
                MoneyText.text = GameManager.main.Money.ToString();
                ResourceCycleTime = Stats[ResourceLevel].cycleTime;
                ResourceButtonImage.sprite = ResourceIcons[ResourceLevel];
                ResourceTimer = 0;

                // Set resource level text
                if (ResourceLevel == MaxStatLevel)
                {
                    ResourceLevelText.text = "MAX";
                }
                else
                {
                    ResourceLevelText.text = "Lv. " + ResourceLevel.ToString();
                }

                // Activate next resource if this has been upgraded once
                if (ResourceLevel == 1 && ResourceID + 1 <= GameManager.main.Resources.Length)
                {
                    GameHUD.main.ResourceObjects[ResourceID + 1].SetActive(true);
                    GameManager.main.Resources[ResourceID + 1].isActive = true;
                }
            }
        }
    }

    #endregion
}