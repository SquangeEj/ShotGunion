using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class SCR_BulletDamage : MonoBehaviour
{
    private Collider2D col2d;
    public float damage;
    [SerializeField] private bool Bouncy;
    private Animator anim;

    private void Start()
    {
        col2d = GetComponent<Collider2D>();
        anim = GetComponent<Animator>();
    }

    private void OnCollisionEnter2D(Collision2D other)
    {

        if (other.gameObject.GetComponent<SCR_EnemyHealth>())
        {
            other.gameObject.GetComponent<SCR_EnemyHealth>().EnemyTakeDamage(damage);
        }
        if(Bouncy!= true)
        {
            GetComponent<Rigidbody2D>().velocity = Vector2.zero;
            anim.Play("BulDeath");
        }
    }

    private void KillBul()
    {
        Destroy(this.gameObject);
    }
}
