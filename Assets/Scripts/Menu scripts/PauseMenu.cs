using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    public bool GameIsPaused;
    [SerializeField] private GameObject pauseMenuUI;
    [SerializeField] public GameObject settingsUI;


    [SerializeField] private GameObject[] UIcomponents;

    void Start()
    {
        GameIsPaused = false;
        pauseMenuUI.SetActive(false);
        settingsUI.SetActive(false);

        UIcomponents = GameObject.FindGameObjectsWithTag("UIcomponent");
        for(int i=0;i<UIcomponents.Length; i++) UIcomponents[i].SetActive(true);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (GameIsPaused == true)
            {
                Resume();
            }
            else if (GameIsPaused == false)
            {
                Pause();
            }
        }
    }

    void Resume()
    {
        FindObjectOfType<MovementController>().isGamePaused = false;
        pauseMenuUI.SetActive(false);
        settingsUI.SetActive(false);
        Time.timeScale = 1f;
        GameIsPaused = false;
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        for(int i=0;i<UIcomponents.Length; i++) UIcomponents[i].SetActive(true);
    }
    void Pause()
    {
        FindObjectOfType<MovementController>().isGamePaused = true;
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.Confined;
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        GameIsPaused = true;
        for(int i=0;i<UIcomponents.Length; i++) UIcomponents[i].SetActive(false);
    }

    public void Button_Settings()
    {
        pauseMenuUI.SetActive(false);
        settingsUI.SetActive(true);
        Time.timeScale = 0f;
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.Confined;
        GameIsPaused = true;
    }

    public void Button_BackToPause()
    {
        pauseMenuUI.SetActive(true);
        settingsUI.SetActive(false);
        Time.timeScale = 0f;
        GameIsPaused = true;
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.Confined;
    }

    public void Button_Resume()
    {
        FindObjectOfType<MovementController>().isGamePaused = false;
        pauseMenuUI.SetActive(false);
        settingsUI.SetActive(false);
        Time.timeScale = 1f;
        GameIsPaused = false;
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        for(int i=0;i<UIcomponents.Length; i++) UIcomponents[i].SetActive(true);
    }


    public void Button_Quit()
    {
        Application.Quit();
    }

}
