using System.Collections;
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

    #endregion

    #region Private Methods


    #endregion
}
