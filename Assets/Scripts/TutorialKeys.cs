using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TutorialKeys : MonoBehaviour
{
    private float rotation_speed;
    
    private Scene current_scene;
    [SerializeField] private AudioClip keySound;

    void Start()
    {
        rotation_speed = 50f;
    }

    void Update()
    {
        current_scene = SceneManager.GetActiveScene();
        transform.Rotate(Vector3.up *rotation_speed * Time.deltaTime);
    }

    void OnTriggerEnter(Collider other)
    {
     if(other.CompareTag("Player")){
        if(current_scene.name == "tutorial_1") SceneManager.LoadScene("tutorial_2");
        if(current_scene.name == "tutorial_2") SceneManager.LoadScene("tutorial_3");
        if(current_scene.name == "tutorial_3") SceneManager.LoadScene("tutorial_4");
        if(current_scene.name == "tutorial_4") SceneManager.LoadScene("tutorial_5");
        if(current_scene.name == "tutorial_5") SceneManager.LoadScene("TutorialCompleted");

        AudioSource.PlayClipAtPoint(keySound,transform.position);

        Destroy(gameObject); 
        }
    }
}
