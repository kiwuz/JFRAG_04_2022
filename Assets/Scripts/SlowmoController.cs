using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Rendering;
using UnityEngine.Rendering.PostProcessing;

public class SlowmoController : MonoBehaviour
{

    private bool SlowmoActivated;
    private float slowmoPower;
    [SerializeField] private Image SlowmoBar;
    [SerializeField] private GameObject slowmo_postprocess;
    private PauseMenu PM;
    void Start()
    {
        PM = FindObjectOfType<PauseMenu>();

        SlowmoActivated = false;
        slowmoPower = 100f;
        slowmo_postprocess.SetActive(false);

    }

    void Update()
    {
        SlowmoBar.fillAmount = slowmoPower/100f;
        SlowMotion();

        if(SlowmoActivated && !PM.GameIsPaused){
            if(slowmoPower > 0) slowmoPower = slowmoPower - 0.4f;
            }

            if(!SlowmoActivated && !PM.GameIsPaused){
                if(slowmoPower < 100f) slowmoPower = slowmoPower +0.25f;
            }
    }
    void SlowMotion(){
        
        if(Input.GetKeyDown(KeyCode.Tab) && slowmoPower > 0 && !PM.GameIsPaused){
            if(!SlowmoActivated){
                Time.timeScale = 0.25f;
                SlowmoActivated = true;
                slowmo_postprocess.SetActive(true);
            }
            else if(SlowmoActivated){
                Time.timeScale = 1f;
                SlowmoActivated = false;
                slowmo_postprocess.SetActive(false);
            }
        }
        if(SlowmoActivated && slowmoPower <= 0 ){
            Time.timeScale = 1f;
            SlowmoActivated = false;
            slowmo_postprocess.SetActive(false);
        }
    }
}
