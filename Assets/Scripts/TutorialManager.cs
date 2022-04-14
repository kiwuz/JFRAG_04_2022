using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TutorialManager : MonoBehaviour
{
    private Scene current_scene;
    public float waveMana;
    private PauseMenu PM;

    void Start()
    {
        PM = FindObjectOfType<PauseMenu>();
        waveMana = 100f;
    }

    void Update()
    {
        current_scene = SceneManager.GetActiveScene();
        if(current_scene.name == "tutorial_3" || current_scene.name == "tutorial_2" ){
            if (waveMana < 100f && !PM.GameIsPaused) waveMana = waveMana +0.25f;
        }
    }
}
