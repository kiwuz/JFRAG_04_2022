using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Target : MonoBehaviour {
    public float health;
    public float PlayerHealth_;
    [SerializeField] private Image healthBar;
    [SerializeField] private GameObject cam;
    [SerializeField] private Text hp_text;
    [SerializeField] private Image hp_plus;
    [SerializeField] private AudioClip boss_explosion;
    [SerializeField] private ParticleSystem towerExplosion;
    [SerializeField] private Vector3 offset;
    private GameManager GM;
    private GameObject player;


    void Start() {
       if(this.CompareTag("Enemy")) offset = transform.position - healthBar.transform.position; //healthbar always on head of enemy

        GM = FindObjectOfType<GameManager>();
        player = GameObject.FindGameObjectWithTag("Player");

        health = 100f;

    }

    private void LateUpdate() {
        if(this.CompareTag("Enemy")){
            healthBar.transform.position = transform.position - offset;  
            healthBar.transform.rotation = cam.transform.rotation;
        }
    }

    public void EnemyHit(float damage) { //hits target with damage //from bullet script
        health -= damage;
        HealthBar();
        if(health <= 0) {
            towerExplosion.Play();
            AudioSource.PlayClipAtPoint(boss_explosion,player.transform.position,100f);
                Invoke("DestroyObject", 0.7f); // time for explosion particle
        }
    }

    public void PlayerHit(float damage) {
        GM.PlayerHealth -= damage;
        GM.HealthUpdate();
    }

    public void DestroyObject(){
        gameObject.SetActive(false);
    }

    public void HealthBar(){
        healthBar.fillAmount = health/100f;

        if (health <= 50){
            healthBar.color = Color.yellow;
        }
        if(health<=25){
            healthBar.color = Color.red;
        }
    }




}
