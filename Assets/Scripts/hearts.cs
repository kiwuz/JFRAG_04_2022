using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hearts : MonoBehaviour
{
    private GameManager GM;
    private CheckPointManager CM; 
    [SerializeField] private AudioClip coinSound;
    void Start()
    {
        GM = FindObjectOfType<GameManager>();
        CM = FindObjectOfType<CheckPointManager>();
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")){
        if(GM.PlayerHealth < 100){
            GM.PlayerHealth = GM.PlayerHealth + 40;
            GM.HealthUpdate();
        }
        if(GM.ammunition < 20){
            GM.ammunition = GM.ammunition + 8;
            GM.ammo_update();
        }
            AudioSource.PlayClipAtPoint(coinSound,transform.position);
            CM.SetNewCheckpoint(this.transform.position);
            Destroy(gameObject);
        }
    }
}
