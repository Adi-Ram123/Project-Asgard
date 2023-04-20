using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] int health;
    [SerializeField] int mana;
    [SerializeField] string type;
    [SerializeField] int moveCount;

    private List<Moves> attacks;
    // Start is called before the first frame update
    void Start()
    {
        Skills.StoreList();
        attacks = Skills.GetAvailable(type, moveCount);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
