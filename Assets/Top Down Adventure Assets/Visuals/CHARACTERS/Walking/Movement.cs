using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField] float speed;
    private Animator anime;
    private Rigidbody2D rb;
    private Vector2 move;
    private bool up, down, left, right, walk, pressed;
    // Start is called before the first frame update
    void Start()
    {
        up = down = left = right = walk = pressed = false;
        anime = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {


        if (!pressed && Input.GetKeyDown(KeyCode.A))
        {
            left = true;
            walk = true;
            pressed = true;
            move.x = Input.GetAxisRaw("Horizontal");

        }

        if (Input.GetKeyUp(KeyCode.A))
        {
            left = false;
            walk = false;
            pressed = false;
            anime.ResetTrigger("Left");
        }

        if (!pressed && Input.GetKeyDown(KeyCode.D))
        {
            right = true;
            walk = true;
            pressed = true;
            move.x = Input.GetAxisRaw("Horizontal");

        }

        if (Input.GetKeyUp(KeyCode.D))
        {
            right = false;
            walk = false;
            pressed = false;
            anime.ResetTrigger("Right");
        }

        if (!pressed && Input.GetKeyDown(KeyCode.W))
        {
            up = true;
            walk = true;
            pressed = true;
            move.y = Input.GetAxisRaw("Vertical");

        }

        if (Input.GetKeyUp(KeyCode.W))
        {
            up = false;
            walk = false;
            pressed = false;
            anime.ResetTrigger("Up");

        }

        if (!pressed && Input.GetKeyDown(KeyCode.S))
        {
            down = true;
            walk = true;
            pressed = true;
            move.y = Input.GetAxisRaw("Vertical");

        }

        if (Input.GetKeyUp(KeyCode.S))
        {
            down = false;
            walk = false;
            pressed = false;
            anime.ResetTrigger("Down");

        }

    }

    private void FixedUpdate()
    {

        rb.MovePosition(rb.position + move * speed * Time.fixedDeltaTime);

        if (walk)
        {
            anime.SetBool("Walk", true);
        }

        else
            anime.SetBool("Walk", false);

        if (up)
        {
            anime.SetTrigger("Up");
            //rb.velocity = new Vector2(0, speed * Time.deltaTime);
        }

        if (right)
        {
            anime.SetTrigger("Right");
            //rb.velocity = new Vector2(speed * Time.deltaTime, 0);
        }

        if (down)
        {
            anime.SetTrigger("Down");
           //rb.velocity = new Vector2(0, -speed * Time.deltaTime);
        }

        if (left)
        {
            anime.SetTrigger("Left");
            //rb.velocity = new Vector2(-speed * Time.deltaTime, 0);
        }

        if (!up && !right && !down && !left)
        {
            move = new Vector2(0, 0);
        }
    }

}
