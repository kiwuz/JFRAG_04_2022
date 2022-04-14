using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ShootingGunController : MonoBehaviour
{
    Animator m_animator;
    public ParticleSystem muzzleFlash;
    public GameObject bullet;
    [SerializeField] private float bulletSpeed; 
    [SerializeField] private Text ammo_text;
    [SerializeField] private Image ammo_icon;
    [SerializeField] private GameObject guntip;
    [SerializeField] private GameObject cam;
    [SerializeField] private AudioClip gun_shoot;


    public float rotationSpeed;
    private GameManager GM;
    private TutorialManager TM;
    private PauseMenu PM;
    private Scene current_scene;

    void Start()
    {
        GM = FindObjectOfType<GameManager>();
        TM = FindObjectOfType<TutorialManager>();
        PM = FindObjectOfType<PauseMenu>();
        m_animator = GetComponent<Animator>();
        bulletSpeed = 100f;
    }

    void Update()
    {
        current_scene = SceneManager.GetActiveScene();
        if(Input.GetMouseButtonDown(0) && !PM.GameIsPaused){
            if(current_scene.name == "tutorial_4"){ ShootTutorial();}
            else Shoot();
        }
    }


public void Shoot() {
        if (GM.ammunition > 0){
            GameObject spawnedBullet = Instantiate(bullet, guntip.transform.position  , cam.transform.rotation );
            muzzleFlash.Play();
            m_animator.SetTrigger("Shoot");
            AudioSource.PlayClipAtPoint(gun_shoot,transform.position);
            GM.ammo_update();

            Rigidbody rb = spawnedBullet.GetComponent<Rigidbody>();

            rb.velocity = cam.transform.forward * bulletSpeed;

            GM.ammunition--;
        }
        else if(GM.ammunition <=0){
            Debug.Log("out of ammo");
        }
    }

    public void ShootTutorial() {
            GameObject spawnedBullet = Instantiate(bullet, guntip.transform.position  , cam.transform.rotation );
            muzzleFlash.Play();
            m_animator.SetTrigger("Shoot");
            AudioSource.PlayClipAtPoint(gun_shoot,transform.position);
            Rigidbody rb = spawnedBullet.GetComponent<Rigidbody>();

            rb.velocity = cam.transform.forward * bulletSpeed;
    }
}


