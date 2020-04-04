using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    #region Data Types

    public enum ResourceType
    {
        Meat,
        Fletching,
        Smithing,
        Textiles,
        Potions,
        Gems
    }

    [System.Serializable]
    public struct Resource
    {
        public ResourceType name;
        public int level;
        public bool isActive;
    }

    #endregion

    #region Inspector Fields

    public int Money = 0;

    public int MaxStatLevel = 3;

    public Resource[] Resources;

    #endregion

    #region RuntimeFields

    private int LastLoginHour;
    private int LastLoginMinute;
    private int LastLoginSecond;

    #endregion

    #region Static Fields

    public static GameManager main;

    #endregion

    #region Monobehavior

    private void Awake()
    {
        if (main == null)
        {
            main = this;
        }
        else
        {
            GameObject.Destroy(gameObject);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        /*if (PlayerPrefs.HasKey("Money") && (SceneManager.GetSceneByBuildIndex(1).Equals(SceneManager.GetActiveScene())))
        {
            LoadData();
        }*/
    }

    // Update is called once per frame
    void Update()
    {
       
    }

    #endregion

    #region Public Methods



    #endregion

    #region Private Methods

    #   region Unused methods for saving data

    /*private void CalculateTimeAFK()
    {
        int currentHour = System.DateTime.Now.Hour;
        int currentMinute = System.DateTime.Now.Minute;
        int currentSecond = System.DateTime.Now.Second;


    }*/

    /*private void LoadData()
    {
        for (int i = 0; i < Resources.Length; i++)
        {
            Resources[i].level = PlayerPrefs.GetInt("ResourceID " + i + " Level");
            if (PlayerPrefs.GetInt("IsActive") == 0)
            {
                Resources[i].isActive = false;
            }
            else
            {
                Resources[i].isActive = true;
            }
        }
        Money = PlayerPrefs.GetInt("Money");
    }*/

    /*private void OnApplicationQuit()
    {
        for (int i = 0; i < Resources.Length; i++)
        {
            PlayerPrefs.SetInt("ResourceID " + i + " Level", Resources[i].level);
            if (Resources[i].isActive)
            {
                PlayerPrefs.SetInt("IsActive", 1);
            }
            else
            {
                PlayerPrefs.SetInt("IsActive", 0);
            }
        }

        PlayerPrefs.SetInt("Money", Money);
    }*/

    // Reset game progress
    /*public void ResetProgress()
    {
        for (int i = 0; i < Resources.Length; i++)
        {
            Resources[i].level = 0;
            GameManager.main.Resources[i].isActive = false;
            if (Resources[i].name == ResourceType.Meat)
            {
                Resources[i].isActive = true;
            }
            PlayerPrefs.SetInt("ResourceID " + i + " Level", 0);
            PlayerPrefs.SetInt("IsActive " + i, 0);
        }
        Money = 10;
    }*/

    #endregion

    #endregion
}
