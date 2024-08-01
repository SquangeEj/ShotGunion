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
    // Start is called before the first frame update
    void Start()
    {

        runSpeed = 10;
        body = GetComponent<Rigidbody2D>();

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            body.drag = 0;
            anim.Play("Roll");
            Roll();
        }
        else 
        {
            Walk();
            body.drag = 3;
            anim.Play("Idle");

        }
        horizontal = Input.GetAxisRaw("Horizontal");
        vertical = Input.GetAxisRaw("Vertical");



    }



    private void Walk()
    {
        body.velocity += (new Vector2(horizontal, vertical) * runSpeed) * Time.deltaTime;

    }

    private void Roll()
    {
        body.velocity += (new Vector2(horizontal, vertical) * runSpeed) * Time.deltaTime;

    }
}
