using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private bool combat;
    private Animator anime;
    private Rigidbody2D rb;
    private Vector2 move;
    private bool walk, pressed;
    // Start is called before the first frame update
    void Start()
    {
        anime = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {

        if (!combat && !pressed && Input.GetKeyDown(KeyCode.A))
        {
            walk = true;
            pressed = true;
            move.x = Input.GetAxisRaw("Horizontal");

        }

        if (Input.GetKeyUp(KeyCode.A))
        {
            walk = false;
            pressed = false;
        }

        if (!combat && !pressed && Input.GetKeyDown(KeyCode.D))
        {
            walk = true;
            pressed = true;
            move.x = Input.GetAxisRaw("Horizontal");

        }

        if (Input.GetKeyUp(KeyCode.D))
        {
            walk = false;
            pressed = false;
        }

        if (!combat && !pressed && Input.GetKeyDown(KeyCode.W))
        {
            walk = true;
            pressed = true;
            move.y = Input.GetAxisRaw("Vertical");

        }

        if (Input.GetKeyUp(KeyCode.W))
        {
            walk = false;
            pressed = false;

        }

        if (!combat && !pressed && Input.GetKeyDown(KeyCode.S))
        {
            walk = true;
            pressed = true;
            move.y = Input.GetAxisRaw("Vertical");

        }

        if (Input.GetKeyUp(KeyCode.S))
        {
            walk = false;
            pressed = false;

        }

    }

   

    private void FixedUpdate()
    {
        if (move != Vector2.zero)
        {
            anime.SetFloat("xInput", move.x);
            anime.SetFloat("yInput", move.y);
        }

        if (walk)
        {
            anime.SetBool("Walk", true);
            rb.MovePosition(rb.position + move * speed * Time.fixedDeltaTime);
        }

        else
        {
            anime.SetBool("Walk", false);
            move = Vector2.zero;

        }

    }

}
