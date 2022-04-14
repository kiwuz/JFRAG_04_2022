using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class WaveLauncher : MonoBehaviour
{
    private MovementController MC;
    private GameManager GM;
    private TutorialManager TM;

    private PauseMenu PM;
    public GameObject wave;
    private float radius;
    private float power;
    [SerializeField] private ParticleSystem WaveFlash;
    [SerializeField] private Image waveBar;
    [SerializeField] private AudioClip wave_shoot;
    private Scene current_scene;
    private bool  isCtrlPressed;    
    void Start()
    {
        MC = FindObjectOfType<MovementController>();
        PM = FindObjectOfType<PauseMenu>();
        GM = FindObjectOfType<GameManager>();
        TM = FindObjectOfType<TutorialManager>();


        radius = 25.0f;
        power = 60.0f;
    }

    void Update()
    {
        current_scene = SceneManager.GetActiveScene();
        if(current_scene.name == "tutorial_2" || current_scene.name == "tutorial_3"){
            waveBar.fillAmount = TM.waveMana/100f;
                  if (Input.GetMouseButtonDown(0) && TM.waveMana == 100 && !PM.GameIsPaused)
            {
                Wave();
                AudioSource.PlayClipAtPoint(wave_shoot,transform.position);
                TM.waveMana = 0;
            }
        }

        else {
        if (Input.GetMouseButtonDown(0) && GM.waveMana == 100 && !PM.GameIsPaused)
        {
            Wave();
            AudioSource.PlayClipAtPoint(wave_shoot,transform.position);
             GM.waveMana = 0;
        }
        waveBar.fillAmount = GM.waveMana/100f;
    }

        if(Input.GetKeyDown(KeyCode.LeftControl)){
            isCtrlPressed = true;
        }

        if(Input.GetKeyUp(KeyCode.LeftControl)){
            isCtrlPressed = false;
        }
    }


void Wave(){
    Vector3 explosionPos = wave.transform.position;
    Collider[] colliders = Physics.OverlapSphere(explosionPos, radius);
    WaveFlash.Play();
    foreach (Collider hit in colliders) {
        Rigidbody rb = hit.GetComponent<Rigidbody>();

        if(isCtrlPressed  && MC.grounded  && rb!=null){
            if(rb.gameObject.CompareTag("Player")) continue;
                rb.AddExplosionForce(power, explosionPos, radius, 0.5F,ForceMode.Impulse);
                Debug.Log("wave pos: "+ explosionPos);
                Debug.Log("grounded wave");
                }

            if(!isCtrlPressed && rb!=null){//wavable
                rb.AddExplosionForce(power, explosionPos, radius, 0.5F,ForceMode.Impulse);
                Debug.Log("wave pos: "+ explosionPos);
               }
            }
        }
}
