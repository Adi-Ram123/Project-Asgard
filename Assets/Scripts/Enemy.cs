using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{
    public float health;
    public int mana;
    public string type;
    public int moveCount;
    public float maxHealth;
    [SerializeField] Text healthShow;

    private List<Moves> attacks;
    // Start is called before the first frame update
    void Start()
    {
        maxHealth = health;
        Skills.StoreList();
        attacks = Skills.GetAvailable(type, moveCount);
    }

    public Moves SlimeAttack()
    {
        if(health < 0.5f*maxHealth)
        {
            for(int i=0; i< attacks.Count; i++)
            {
                if (attacks[i].type.Equals("healer"))
                {
                    health += 0.2f * maxHealth;
                    return attacks[i];
                }
            }
        }
        Moves offensive;
        do
        {
            offensive = attacks[Random.Range(0, attacks.Count)];
        } while (offensive.type.Equals("healer"));
        return offensive;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        healthShow.text = "Health: " + health + "/" + maxHealth;
    }
}
