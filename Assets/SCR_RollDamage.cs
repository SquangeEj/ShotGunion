using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class SCR_RollDamage : MonoBehaviour
{
    [SerializeField] private CircleCollider2D PlayerCol;
    [SerializeField] private Rigidbody2D rb;

    private void OnEnable()
    {
 
        PlayerCol.radius = 0.1f;   
    }

    
    private void OnTriggerEnter2D(Collider2D other)
    {
      
        
        if (other.gameObject.GetComponent<SCR_EnemyHealth>())
        {
            
            other.gameObject.GetComponent<SCR_EnemyHealth>().EnemyTakeDamage(rb.velocity.magnitude);
        
            GetComponent<CinemachineImpulseSource>().GenerateImpulse(rb.velocity.magnitude);
            StartCoroutine(FreezeFrame());
            if (other.gameObject.GetComponent<Rigidbody2D>())
            {
                other.gameObject.GetComponent<Rigidbody2D>().AddForce(rb.velocity * 100);
            }
        }
    }

    private IEnumerator FreezeFrame()
    {

        Time.timeScale = 0;


        yield return new WaitForSecondsRealtime(0.15f);

        Time.timeScale = 1;

        yield return null;
    }

    private void OnDisable()
    {
        PlayerCol.radius = 0.3f;
        Time.timeScale = 1;
    }
}
