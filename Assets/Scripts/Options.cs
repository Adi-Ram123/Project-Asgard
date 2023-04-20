using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Options : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
<<<<<<< Updated upstream
=======
        if (Input.GetKey(KeyCode.Escape))
        {
            // set all other canvases inactive
            health.SetActive(true);
            mainCanvas.SetActive(true);
            fight.SetActive(false);
            status.SetActive(false);
            run.SetActive(false);
            items.SetActive(false);
            movedesc.SetActive(false);
        }
    }

    public void Fight()
    {
        mainCanvas.SetActive(false);
        fight.SetActive(true);
        status.SetActive(false);
        run.SetActive(false);
    }

    public void Status()
    {
        health.SetActive(false);
        status.SetActive(true);
    }

    public void Items()
    {
        mainCanvas.SetActive(false);
        items.SetActive(true);
    }

    public void Run()
    {
        health.SetActive(false);
        run.SetActive(true);
        if (Random.value > 0.5f)
        {
            run.GetComponentInChildren<Text>().text = "Escaped!";
        }
        else
        {
            run.GetComponentInChildren<Text>().text = "Escape Failed!";
        }
        turn = 1;
    }

    public void Attack()
    {
>>>>>>> Stashed changes
        
    }
}
