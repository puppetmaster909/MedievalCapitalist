using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    #region Inspector Fields



    #endregion

    #region RuntimeFields

    public int Money = 0;

    [Space(10)]
    public float IncreaseMoneyBy = 1;

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
