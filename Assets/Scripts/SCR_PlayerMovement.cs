using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using static UnityEditor.Searcher.SearcherWindow.Alignment;

public class SCR_PlayerMovement : MonoBehaviour
{

    private Rigidbody2D body;
    float horizontal, vertical;
    [SerializeField] private float runSpeed { get; set; }
    [SerializeField] Animator anim;
    [SerializeField] GameObject RollTrail, RollParticles, RollDash;
    private bool Rolling;
    // Start is called before the first frame update
    void Start()
    {

        runSpeed = 10;
        body = GetComponent<Rigidbody2D>();

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Rolling = true;
            body.drag = 0;

            anim.Play("ToRoll");
            anim.SetBool("Roll", true);
            RollTrail.SetActive(true);

        

        }
        if (Input.GetKeyUp(KeyCode.Space))
        {

            anim.Play("FromRoll");
            anim.SetBool("Roll", false);
            Rolling = false;
            RollTrail.SetActive(false);
         
            GameObject part = Instantiate(RollParticles, transform.position, Quaternion.identity);
            Destroy(part, 2);
                body.drag = 3;
        
        }

      
       
        horizontal = Input.GetAxisRaw("Horizontal");
            vertical = Input.GetAxisRaw("Vertical");


 
    }

   


    private void LateUpdate()
    {
        body.velocity += (new Vector2(horizontal, vertical) * runSpeed) * Time.deltaTime;

       
      if(body.velocity.magnitude > 10 && Rolling == true)
        {
            RollDash.SetActive(true);
        }
        else
        {
            RollDash.SetActive(false);
        }

    }
}
