using System.Collections;
using System.Collections.Generic;
using UnityEditor.Presets;
using UnityEngine;

public class Movement : MonoBehaviour
{
    [Header("Input & Mvmt")]
    [SerializeField] float speed = 10;
    private List<KeyCode> presses;


    [Header("Components")]
    [SerializeField] Rigidbody2D rb;
    [SerializeField] Animator anim;

    
    // Start is called before the first frame update
    void Start()
    {
        presses = new List<KeyCode>(); 
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            presses.Add(KeyCode.A);
        }
        if (Input.GetKeyDown(KeyCode.W))
        {
            presses.Add(KeyCode.W);
        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            presses.Add(KeyCode.D);
        }
        if (Input.GetKeyDown(KeyCode.S))
        {
            presses.Add(KeyCode.S);
        }

        
        if (Input.GetKeyUp(KeyCode.A))
        {
            presses.Remove(KeyCode.A);
        }
        if (Input.GetKeyUp(KeyCode.W))
        {
            presses.Remove(KeyCode.W);
        }
        if (Input.GetKeyUp(KeyCode.D))
        {
            presses.Remove(KeyCode.D);
        }
        if (Input.GetKeyUp(KeyCode.S))
        {
            presses.Remove(KeyCode.S);
        }
    }

    public void Move(int x, int y)
    {
        anim.SetFloat("horiz", x);
        anim.SetFloat("vert", y);

        rb.velocity = new Vector2(x, y) * speed;
    }

    private void FixedUpdate()
    {
        if (presses.Count > 0)
        {
            anim.SetBool("move", true);
            if (presses[^1] == KeyCode.A)
            {
                Move(-1, 0);
            }
            if (presses[^1] == KeyCode.S)
            {
                Move(0, -1);
            }
            if (presses[^1] == KeyCode.W)
            {
                Move(0, 1);
            }
            if (presses[^1] == KeyCode.D)
            {
                Move(1, 0);
            }
        }
        else
        {
            anim.SetBool("move", false);

            rb.velocity = Vector2.zero;
        }
    }
    
}
