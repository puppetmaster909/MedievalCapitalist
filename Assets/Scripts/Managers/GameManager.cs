using System.Collections;
using System.Collections.Generic;
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

    }

    // Update is called once per frame
    void Update()
    {
       
    }

    #endregion

    #region Public Methods



    #endregion

    #region Private Methods



    #endregion
}
