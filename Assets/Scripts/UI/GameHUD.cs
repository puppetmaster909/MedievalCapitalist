using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameHUD : MonoBehaviour
{
    #region Structs

    [System.Serializable]
    public struct UpgradeCategory
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
    public Sprite[] MeatIcons;
    
    [Space(20)]
    public UpgradeCategory[] MeatStats;

    [Space(20)]
    public Image MeatButtonImage;

    [Space(20)]
    public Slider MeatProgressBar;

    #endregion

    #region Runtime Fields

    private int MeatLevel;
    private float MeatTimer;
    private float MeatCycleTime;

    #endregion

    #region Monobehavior

    // Start is called before the first frame update
    void Start()
    {
        MoneyText.text = GameManager.main.Money.ToString();

        MeatLevel = GameManager.main.MeatLevel;
        MeatTimer = MeatStats[MeatLevel].cycleTime;   
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log("Cost: " + MeatStats[MeatLevel + 1].cost.ToString());

        if (MeatLevel > 0)
        {
            // Timers
            MeatTimer += Time.deltaTime;
            MeatProgressBar.value = MeatTimer / MeatCycleTime;

            // Adds money if timer is finished
            if (MeatTimer > MeatStats[MeatLevel].cycleTime)
            {
                MeatTimer -= MeatStats[MeatLevel].cycleTime;
                GameManager.main.Money += MeatStats[MeatLevel].moneyPerCycle;
                MoneyText.text = GameManager.main.Money.ToString();
            }
        }
    }

    #endregion

    #region Public Methods

    public void UpgradeMeat()
    {
        if (GameManager.main.Money >= MeatStats[MeatLevel + 1].cost)
        {
            MeatLevel = MeatLevel + 1;
            GameManager.main.MeatLevel = MeatLevel;

            Debug.Log("New Meat Level: " + MeatLevel.ToString());

            GameManager.main.Money -= MeatStats[MeatLevel].cost;
            MoneyText.text = GameManager.main.Money.ToString();
            MeatCycleTime = MeatStats[MeatLevel].cycleTime;
            MeatButtonImage.sprite = MeatIcons[MeatLevel];
            MeatTimer = 0;
        }
    }

    #endregion
}
