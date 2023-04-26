using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
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
    [SerializeField] GameObject won;
    [SerializeField] GameObject lost;
    [SerializeField] GameObject lifeBar;
    [SerializeField] float hp;
    private float maxHp;

    [SerializeField] GameObject enemy;
    public bool go;
    public string turn;
    // Start is called before the first frame update
    void Start()
    {
        maxHp = hp;
        go = true;
        turn = "Player";
        lost.SetActive(false);
        won.SetActive(false);
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

    void FixedUpdate()
    {
        if(turn.Equals("Enemy") && go)
        {
            if(enemy.name.Equals("slime"))
            {
                Attack(enemy.GetComponent<Enemy>().SlimeAttack(), enemy.GetComponent<Lerp>());
            }
            go = false;
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
            StartCoroutine(TurnChange());
        }
    }

    public void Attack(Moves move, Lerp lerp)
    {
        if (Random.value < (move.accuracy))
        {
            if(!move.type.Equals("healer"))
                lerp.SetMove(true);
            attackDisplay.GetComponentInChildren<Text>().text = turn + " succesfully used " + move.name;
            attackDisplay.SetActive(true);
            if(turn.Equals("Player"))
            {
                enemy.GetComponent<Enemy>().health -= move.power;
                if (enemy.GetComponent<Enemy>().health <= 0)
                    enemy.GetComponent<Enemy>().health = 0;

                if (move.type.Equals("healer"))
                    hp += 0.2f * maxHp;
                if (hp > 200) { hp = 200; }
            }
            if (turn.Equals("Enemy"))
            {
                hp -= move.power;
                if (hp <= 0)
                    hp = 0;
            }
            lifeBar.GetComponent<Slider>().value = hp / maxHp;
        }
        else
        {
            attackDisplay.GetComponentInChildren<Text>().text = turn + " missed " + move.name;
            attackDisplay.SetActive(true);
        }
        StartCoroutine(TurnChange());
    }

    IEnumerator TurnChange()
    {
        yield return new WaitForSeconds(1.75f);
        if (enemy.GetComponent<Enemy>().health > 0)
        {
            if (turn.Equals("Player"))
            {
                go = true;
                turn = "Enemy";
            }
            else
                turn = "Player";
        }
        if (enemy.GetComponent<Enemy>().health == 0)
            won.SetActive(true);
        if (hp == 0)
            lost.SetActive(true);
    }

}
