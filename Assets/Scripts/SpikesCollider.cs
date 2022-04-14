using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class SpikesCollider : MonoBehaviour
{
    private GameManager GM;
    private CheckPointManager CM; 
    private GrapplingGun GG;
    private Scene current_scene;
    void Start()
    {
        CM = FindObjectOfType<CheckPointManager>();
        GG = FindObjectOfType<GrapplingGun>();
        GM = FindObjectOfType<GameManager>();        

        SceneManager.GetActiveScene();
    }


    void  OnTriggerEnter(Collider other){
        if (other.CompareTag("Player")){
        current_scene = SceneManager.GetActiveScene();
            Debug.Log("collision");
            if(current_scene.name != "tutorial_2") GG.StopGrapple();
            if(current_scene.name != "tutorial_1" && current_scene.name != "tutorial_2"){
                GM.PlayerHealth = GM.PlayerHealth - 20;
            }
            CM.setPlayerPosition();
            GM.HealthUpdate();
        }
      }
}
