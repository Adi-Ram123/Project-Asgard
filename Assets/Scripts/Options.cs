using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Options : MonoBehaviour
{
    public static string selected;
    [SerializeField] GameObject mainCanvas;
    [SerializeField] GameObject fight;
    [SerializeField] GameObject health;
    [SerializeField] GameObject moves;
    [SerializeField] GameObject items;
    [SerializeField] GameObject status;
    [SerializeField] GameObject run;
    // Start is called before the first frame update
    void Start()
    {
        moves.SetActive(false);
        fight.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Escape))
        {
            // set all other canvases inactive
            mainCanvas.SetActive(true);
        }
    }

    public void Fight()
    {
        mainCanvas.SetActive(false);
        fight.SetActive(true);
    }

    public void Status()
    {
        mainCanvas.SetActive(false);
        //status.SetActive(true);
    }

    public void Items()
    {
        mainCanvas.SetActive(false);
        //items.SetActive(true);
    }

    public void Run()
    {
        if (Random.value > 0.5f)
        {
            int x = 3; // placeholder
            // add code to change text object such that it
            // shows whether player successfully ran away
        }
    }
}
