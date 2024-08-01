using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor.Animations;

public class SCR_ShotGunionWeapon : MonoBehaviour
{
    public WeaponSCROBJ[] Weapons;

    private SpriteRenderer spriteren;
    private Animator anim;

    private int CurrentWeapon;

    void Start()
    {
        spriteren=gameObject.GetComponent<SpriteRenderer>();
        anim=GetComponent<Animator>();
        anim.runtimeAnimatorController = Weapons[CurrentWeapon].controller;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            anim.Play("Fire");
            
        }
        if (Input.GetKeyDown(KeyCode.Q)) {

      
            CurrentWeapon = (CurrentWeapon+1) % Weapons.Length;
            anim.runtimeAnimatorController = Weapons[CurrentWeapon].controller;
           
        }
      
    }


    private void ShootSingle()
    {
        GameObject bullet = Instantiate(Weapons[0].bullet, transform.position, Quaternion.identity);

        Destroy(bullet, 2f);
    }



}
