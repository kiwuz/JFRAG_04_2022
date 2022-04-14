using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooters : MonoBehaviour
{
    [SerializeField] private ParticleSystem muzzleFlash;
    [SerializeField] private GameObject bullet;
    [SerializeField] private GameObject guntip;
    private float bulletSpeed;
    private bool canFire;
    private float elapsed;

    void Start()
    {
        bulletSpeed = 10f;
        canFire = false;
        elapsed = 0f;
    }

    void Update()
    {
        if (canFire){
            elapsed += Time.deltaTime;
            if (elapsed >= 2f){
                elapsed = elapsed %1.5f;
                Shooting();
            }
        }
    }


    void OnTriggerEnter(Collider other) // enemy detection 
    {
        if (other.gameObject.tag == "Player")
        {
            canFire = true;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player") canFire = false;
    }

    void Shooting(){
            GameObject spawnedBullet = Instantiate(bullet, guntip.transform.position, guntip.transform.rotation );
            muzzleFlash.Play();
            Rigidbody rb = spawnedBullet.GetComponent<Rigidbody>();
            rb.velocity = guntip.transform.up * bulletSpeed;
        }
}
