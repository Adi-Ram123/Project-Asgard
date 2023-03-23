using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField] float speed;
    private Animator anime;
    private Rigidbody2D rb;
    private bool up, down, left, right, walk;
    // Start is called before the first frame update
    void Start()
    {
        up = down = left = right = walk = false;
        anime = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            left = true;
            walk = true;
        }
            
        if (Input.GetKeyUp(KeyCode.A))
        {
            left = false;
            walk = false;
            anime.ResetTrigger("Left");
        }

        if (Input.GetKeyDown(KeyCode.D))
        {
            right = true;
            walk = true;
        }

        if (Input.GetKeyUp(KeyCode.D))
        {
            right = false;
            walk = false;
            anime.ResetTrigger("Right");
        }

        if (Input.GetKeyDown(KeyCode.W))
        {
            up = true;
            walk = true;
        }

        if (Input.GetKeyUp(KeyCode.W))
        {
            up = false;
            walk = false;
            anime.ResetTrigger("Up");

        }

        if (Input.GetKeyDown(KeyCode.S))
        {
            down = true;
            walk = true;
        }

        if (Input.GetKeyUp(KeyCode.S))
        {
            down = false;
            walk = false;
            anime.ResetTrigger("Down");

        }



    }

    private void FixedUpdate()
    {
        if (walk)
        {
            anime.SetBool("Walk", true);
        }

        else
            anime.SetBool("Walk", false);

        if(up)
        {
            anime.SetTrigger("Up");
            rb.velocity = new Vector2(0, speed * Time.deltaTime);
        }

        if (right)
        {
            anime.SetTrigger("Right");
            rb.velocity = new Vector2(speed * Time.deltaTime, 0);
        }

        if (down)
        {
            anime.SetTrigger("Down");
            rb.velocity = new Vector2(0, -speed * Time.deltaTime);
        }

        if (left)
        {
            anime.SetTrigger("Left");
            rb.velocity = new Vector2(-speed * Time.deltaTime, 0);
        }


        if (!up && !right && !left && !down)
            rb.velocity = new Vector2(0, 0);

    }

}
