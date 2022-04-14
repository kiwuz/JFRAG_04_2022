using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class GoldenKey : MonoBehaviour
{
    [SerializeField] private AudioClip keySound;


    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")){
            SceneManager.LoadScene("winner", LoadSceneMode.Single);
            AudioSource.PlayClipAtPoint(keySound,transform.position);
            Destroy(gameObject);
        }
    }
}
