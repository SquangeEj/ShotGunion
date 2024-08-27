using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SCR_EnemyHealth : MonoBehaviour
{
    [SerializeField] private float health;
    [SerializeField] private MonoBehaviour EnemyBehaviour;
    [SerializeField] private MonoBehaviour EnemyDeathBehaviour;
    
    public void EnemyTakeDamage(float damage)
    {
        health -= damage;

        if(health < 0)
        {
          //  EnemyBehaviour.enabled = false;
            if(EnemyDeathBehaviour != null)
            {
                EnemyDeathBehaviour.enabled = true;
            }
            GetComponent<Animator>().Play("EnemyDeath");
            GetComponent<Rigidbody2D>().gravityScale = 1;
            Destroy(GetComponent<Collider2D>());
        }
    }
}
