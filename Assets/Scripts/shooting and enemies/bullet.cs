using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bullet : MonoBehaviour
{
    [SerializeField] private float damageForEnemy;
    [SerializeField] private float damageForPlayer;

    void Start()
    {
        damageForEnemy = 25;
        damageForPlayer = 20;
    }

    void OnCollisionEnter(Collision other) {
        Target target = other.gameObject.GetComponent<Target>(); // zadaje obrazenia jesli gameobjekt ma komponent Target
        if(target != null) {
            if(target.CompareTag("Enemy")){
                target.EnemyHit(damageForEnemy);
                Destroy(gameObject); 
            }
            else if(target.CompareTag("Player")){
                target.PlayerHit(damageForPlayer);
                Destroy(gameObject); 
            }
        }
        if (target == null) Destroy(gameObject); 
    }


}
