using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;



public class GameManager : MonoBehaviour
{
    public float PlayerHealth;
    public int ammunition;
    public AudioSource gameMusic;
    public float waveMana;
    private PauseMenu PM;
    private boss_zone BZ;
    [SerializeField] private Text hp_text;
    [SerializeField] private Image hp_plus;
    [SerializeField] private Text ammo_text;
    [SerializeField] private Image ammo_icon;
    [SerializeField] private GameObject player;


    void Start()
    {
        PM = FindObjectOfType<PauseMenu>();
        BZ = FindObjectOfType<boss_zone>();
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        PlayerHealth = 100f;
        ammunition = 12;
        waveMana = 100;

        gameMusic.volume = 60f;
        gameMusic.Play();

        player= GameObject.FindGameObjectWithTag("Player");
    }
    void Update()
    {
        if (PlayerHealth <= 0){
            SceneManager.LoadScene("Loser", LoadSceneMode.Single);
        }

        HealthUpdate();
        ammo_update();

        if(PlayerHealth >100){
            PlayerHealth = 100;
        }
        if (ammunition > 20){
            ammunition = 20;
        }

        if (waveMana < 100f && !PM.GameIsPaused) waveMana = waveMana +0.25f;


        if(!BZ.bossMusic && gameMusic.volume <60) gameMusic.volume  =  gameMusic.volume + 10;

    }


    public void HealthUpdate(){

        hp_text.text = PlayerHealth.ToString();

        if (PlayerHealth <= 50){
           hp_text.color = Color.yellow;
           hp_plus.color = Color.yellow;
        }
        if(PlayerHealth<=25){
            hp_text.color = Color.red;
            hp_plus.color = Color.red;
        }
    }

    public void ammo_update(){

        ammo_text.text = ammunition.ToString();
        if(ammunition<=6){
            ammo_text.color = Color.yellow;
            ammo_icon.color = Color.yellow;
        }
        if(ammunition<=3){
            ammo_text.color = Color.red;
            ammo_icon.color = Color.red;

        }
    }
}
