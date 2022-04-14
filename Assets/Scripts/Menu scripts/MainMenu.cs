using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    [SerializeField] private GameObject MenuPanel;
    [SerializeField] private GameObject settingsPanel;
    [SerializeField] private GameObject aboutPanel;

    void Start()
    {
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.Confined;
        MenuPanel.SetActive(true);
        settingsPanel.SetActive(false);
    }

    public void Button_NewGame()
    {
        SceneManager.LoadScene("mainscene", LoadSceneMode.Single);
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

    public void BackToMainMenu()
    {
        SceneManager.LoadScene("MainMenu", LoadSceneMode.Single);
    }

    public void BackToWinnerMenu()
    {
        MenuPanel.SetActive(true);
        aboutPanel.SetActive(false);
    }
    public void TutorialButton()
    {
        SceneManager.LoadScene("Tutorial_1", LoadSceneMode.Single);
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }
    
    public void Button_Settings()
    {
        MenuPanel.SetActive(false);
        settingsPanel.SetActive(true);
    }

    public void Button_BackToMenu()
    {
        MenuPanel.SetActive(true);
        settingsPanel.SetActive(false);

    }

    public void Button_Quit()
    {
        Application.Quit();
    }

    public void About_Button()
    {
        MenuPanel.SetActive(false);
        aboutPanel.SetActive(true);
    }

}
