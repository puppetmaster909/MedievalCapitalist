﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    #region Screen Struct

    [System.Serializable]
    public struct Screen
    {
        public string name;
        public GameObject screen;
        public Animator animator;
    }

    #endregion

    #region Inspector Fields

    public Screen[] screens;

    [Space(10)]
    public int CurrentScreenID = 0;

    #endregion

    #region Runtime Fields

    [HideInInspector]
    public int PreviousScreenID;

    #endregion

    #region Static Fields

    public static UIManager main;

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

    // Checks if screen name exists and begins coroutine to bring it up
    public void ShowScreen(string name)
    {
        for (int i = 0; i < screens.Length; i++)
        {
            if (screens[i].name.Equals(name))
            {
                StartCoroutine(ShowScreenCoroutine(i));
            }
        }
    }

    // Swap screens between current and selected
    public IEnumerator ShowScreenCoroutine(int index)
    {
        // Not currently implemented. Used for animated screen contents
        if (screens[CurrentScreenID].animator != null)
        {
            screens[CurrentScreenID].animator.SetTrigger("Close");
            yield return new WaitForSeconds(1.0f);
        }

        screens[CurrentScreenID].screen.SetActive(false);
        screens[index].screen.SetActive(true);
        PreviousScreenID = CurrentScreenID;
        CurrentScreenID = index;
    }

    // Loads game scene
    public void PlayGame()
    {
        SceneManager.LoadScene(1);
    }

    // Exit the game and save progress
    public void Quit()
    {
        Application.Quit();
        Debug.Log("Quitting Game");
    }

    // Pauses game
    public void Pause()
    {
        Time.timeScale = 0;
        ShowScreen("Pause");
    }

    // Unpauses game
    public void UnPause(string screenName)
    {
        Time.timeScale = 1;
        ShowScreen(screens[PreviousScreenID].name);
    }

    // Reset game progress
    /*public void ResetProgress()
    {
        for (int i = 0; i < GameManager.main.Resources.Length; i++)
        {
            GameManager.main.Resources[i].level = 0;
            GameManager.main.Resources[i].isActive = false;
            if (GameManager.main.Resources[i].name == GameManager.ResourceType.Meat)
            {
                GameManager.main.Resources[i].isActive = true;
            }
            PlayerPrefs.SetInt("ResourceID " + i + " Level", 0);
            PlayerPrefs.SetInt("IsActive " + i , 0);
        }
        GameManager.main.Money = 10;
    }*/

    #endregion

    #region Private Methods


    #endregion
}
