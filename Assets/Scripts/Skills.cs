using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skills
{
    private List<Moves> moves;

    public Skills()
    {
        moves = new List<Moves>();

        moves.Add(new Moves("Slash", "Strikes the enemy with the main hand", "normal", 20, 50, 0, 100));
        moves.Add(new Moves("Helm Splitter", "Uses Big Axe to do big damage", "barbarian", 5, 120, 0, 75));
        moves.Add(new Moves("Fireball", "Casts a simple orb of fire to fling at your enemies", "mage", 10, 85, 10, 100));
        moves.Add(new Moves("Mend", "Casts a rejuvenating heal that restores hp", "healer", 15, 0, 20, 100));

    }

    public List<Moves> GetSkills()
    {
        return moves;
    }
}
