using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine;

public class GameHUD : MonoBehaviour
{
    #region Static Members

    public static GameHUD main;

    #endregion

    #region Inspector Fields

    public GameObject[] ResourceObjects;

    public Slider TimeScaleSlider;
    public Text TimeScaleText;

    [Space(20)]
    public GameObject Day;
    public GameObject Evening;
    public GameObject Night;

    #endregion

    #region Runtime Fields

    private System.DateTime DateTime;

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
        // Activates 
        for (int i = 0; i < ResourceObjects.Length; i++)
        {
            ResourceObjects[i].SetActive(GameManager.main.Resources[i].isActive);
        }

        UpdateTimeScale();
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

    #region Public Methods

    public void UpdateTimeScale()
    {
        Time.timeScale = TimeScaleSlider.value;
        TimeScaleText.text = "Time Scale: " + TimeScaleSlider.value.ToString("F2");
    }

    public void Quit()
    {
        Application.Quit();
        Debug.Log("Quitting Game");
    }

    public void MainMenu()
    {
        SceneManager.LoadScene(0);
    }

    #endregion
}