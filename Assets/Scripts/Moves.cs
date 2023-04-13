using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Moves
{
    private string name, desc, type;
    private int uses, power, mp, accuracy;
    public Moves(string name, string desc, string type, int uses, int power, int mp, int accuracy)
    {
        this.name = name;
        this.desc = desc;
        this.type = type;
        this.uses = uses;
        this.power = power;
        this.mp = mp;
        this.accuracy = accuracy;
    }
}
