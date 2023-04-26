using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Moves
{
    public string name, desc, type;
    public int uses, power, mp;
    public float accuracy;
    public List<string> usable;
    public Moves(string name, string desc, string type, List<string> usable, int uses, int power, int mp, float accuracy)
    {
        this.name = name;
        this.desc = desc;
        this.type = type;
        this.usable = usable;
        this.uses = uses;
        this.power = power;
        this.mp = mp;
        this.accuracy = accuracy;
    }
}
