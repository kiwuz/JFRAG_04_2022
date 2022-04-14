using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class boss_zone : MonoBehaviour
{
    [SerializeField] private GameObject tower_1;
    [SerializeField] private GameObject tower_2;
    [SerializeField] private AudioSource boss;
    [SerializeField] private GameManager GM;
    public bool bossMusic;


    void Start()
    {
        GM = FindObjectOfType<GameManager>();
        bossMusic = false;
    }
    void Update()
    {
        if (!tower_2.activeSelf && !tower_1.activeSelf) {
            boss.Stop();
            bossMusic = false;
        }
    }
void OnTriggerEnter(Collider other)
    {
        if (tower_2.activeSelf || tower_1.activeSelf){
            if (other.gameObject.tag == "Player")
            {
            boss.Play();
            boss.volume = 60f;
            GM.gameMusic.volume = 0f;
            }
        }
        bossMusic = true;
    }

    void OnTriggerExit(Collider other){
        if(other.gameObject.tag =="Player"){
            boss.Stop();
            bossMusic = false;
        }
    }
}
