using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenu : MonoBehaviour
{
    #region Inspector Fields

    [Space(20)]
    public GameObject Day;
    public GameObject Evening;
    public GameObject Night;

    #endregion

    #region Monobehavior

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        DateTime = System.DateTime.Now;

        if (DateTime.Hour < 16)
        {
            // Show day image
            Day.SetActive(true);
            Evening.SetActive(false);
            Night.SetActive(false);
        }
        else if (DateTime.Hour >= 16 && DateTime.Hour <= 19)
        {
            // Show evening image
            Day.SetActive(false);
            Evening.SetActive(true);
            Night.SetActive(false);
        }
        else
        {
            // Show night image
            Day.SetActive(false);
            Evening.SetActive(false);
            Night.SetActive(true);
        }
    }

    #endregion

    #region Runtime Fields

    private System.DateTime DateTime;

    #endregion

    #region Public Methods

    public void Play()
    {
        UIManager.main.PlayGame();
    }

    // Calls quit method in UIManager
    public void Quit()
    {
        UIManager.main.Quit();
    }

    /*public void ResetGame()
    {
        UIManager.main.ResetProgress();
    }*/

    #endregion
}
