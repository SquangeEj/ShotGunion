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
    
    [SerializeField] private GameObject MouseAim;
    

    void Start()
    {
        spriteren=gameObject.GetComponent<SpriteRenderer>();
        anim=GetComponent<Animator>();
        anim.runtimeAnimatorController = Weapons[CurrentWeapon].controller;
    }

    // Update is called once per frame
    void Update()
    {
        MouseAim.transform.position = Camera.main.ScreenToWorldPoint(Input.mousePosition + new Vector3(0,0,10));
        if (Input.GetMouseButton(0))
        {
            anim.SetBool("Firing", true);

            
        }
        else
        {
            anim.SetBool("Firing", false);
        }
        if (Input.GetKeyDown(KeyCode.Q)) {

      
            CurrentWeapon = (CurrentWeapon+1) % Weapons.Length;
            anim.runtimeAnimatorController = Weapons[CurrentWeapon].controller;
           
        }
      
    }


    private void ShootSingle()
    {
        GameObject bullet = Instantiate(Weapons[CurrentWeapon].bullet, transform.position + -this.transform.right * Weapons[CurrentWeapon].Offset, transform.rotation);
        bullet.GetComponent<Rigidbody2D>().AddForce((-bullet.transform.right * 20)  , ForceMode2D.Impulse);
        bullet.GetComponent<Rigidbody2D>().AddForce(GetComponentInParent<Rigidbody2D>().velocity, ForceMode2D.Impulse);

        Destroy(bullet, 2f);
    }



}
