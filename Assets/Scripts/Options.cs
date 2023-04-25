using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Options : MonoBehaviour
{
    public static string selected;
    [SerializeField] GameObject mainCanvas;
    [SerializeField] GameObject fight;
    [SerializeField] GameObject health;
    [SerializeField] GameObject movedesc;
    [SerializeField] GameObject items;
    [SerializeField] GameObject itemdesc;
    [SerializeField] GameObject status;
    [SerializeField] GameObject run;
    [SerializeField] GameObject attackDisplay;

    [SerializeField] GameObject enemy;

    private int turn; // 0 is player, 1 is enemy
    // Start is called before the first frame update
    void Start()
    {
        turn = 0;
        movedesc.SetActive(false);
        fight.SetActive(false);
        status.SetActive(false);
        run.SetActive(false);
        items.SetActive(false);
        itemdesc.SetActive(false);
        attackDisplay.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
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

    public void Attack(Moves move)
    {
        if (Random.value < (move.accuracy))
        {
            attackDisplay.GetComponentInChildren<Text>().text = "Player succesfully used " + move.name;
            attackDisplay.SetActive(true);
        }
        else
        {
            attackDisplay.GetComponentInChildren<Text>().text = "Player missed " + move.name;
            attackDisplay.SetActive(true);
        }

        turn = 1;
    }

}
