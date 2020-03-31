using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenu : MonoBehaviour
{
    #region Monobehavior

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

    public void Play()
    {
        UIManager.main.PlayGame();
    }

    // Calls quit method in UIManager
    public void Quit()
    {
        UIManager.main.Quit();
    }

    #endregion
}
