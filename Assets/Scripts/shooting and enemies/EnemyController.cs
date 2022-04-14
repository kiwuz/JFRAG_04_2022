using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public bool canFire;
    Transform player;
    public float FireRange;

    //rotation
    public Transform gunBody;
    public Transform baseRotation;

    //shooting
    [SerializeField] private GameObject bullet;
    [SerializeField] private ParticleSystem muzzleFlash;
     
    [SerializeField] private float bulletSpeed;
    [SerializeField] private GameObject enemy_guntip;
    [SerializeField] private AudioClip boss_Shoot;
    private float elapsed;
    private GameObject Player;
    void Start()
    {
        canFire = false;
        this.GetComponent<SphereCollider>().radius = FireRange;
        bulletSpeed = 2.5f;
        elapsed = 0f;
        Player = GameObject.FindWithTag("Player");
    }

    void Update()
    {
        if (canFire){
            Aiming();
            elapsed += Time.deltaTime;
            if (elapsed >= 2f){
                elapsed = elapsed %2f;
                Shooting();
            }
            Aiming();
        }
    }

    
    void OnDrawGizmosSelected() //firerange preview
    {
        
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, FireRange);
    }

    void OnTriggerEnter(Collider other) // enemy detection 
    {
        if (other.gameObject.tag == "Player")
        {
            player = other.transform;
            canFire = true;
        }
    }
    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player") canFire = false;
    }

    void Aiming(){ //tower rotation
            Vector3 baseTargetPostition = new Vector3(player.position.x, this.transform.position.y, player.position.z);
            baseRotation.transform.LookAt(baseTargetPostition);
            Vector3 gunBodyTargetPostition = new Vector3( player.position.x,  player.position.y,  player.position.z);
            Vector3 guntipTargetPostition = new Vector3( player.position.x,  player.position.y,  player.position.z);
            gunBody.transform.LookAt(gunBodyTargetPostition);
    }


    void Shooting(){ //tower shooting
            GameObject spawnedBullet = Instantiate(bullet, enemy_guntip.transform.position, enemy_guntip.transform.rotation );
            muzzleFlash.Play();
            Rigidbody rb = spawnedBullet.GetComponent<Rigidbody>();
            Vector3 shootingDirection = player.position - enemy_guntip.transform.position;
            rb.velocity = shootingDirection * bulletSpeed;
            AudioSource.PlayClipAtPoint(boss_Shoot,player.transform.position,100f);
        }

}
