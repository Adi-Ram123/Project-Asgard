using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skills
{
    public static List<Moves> moves;

    public static void List()
    {
        moves = new List<Moves>();

        moves.Add(new Moves("Slash", "Strikes the enemy with the main hand", "normal", 20, 50, 0, 100));
        moves.Add(new Moves("Helm Splitter", "Uses Big Axe to do big damage", "barbarian", 5, 120, 0, 75));
        moves.Add(new Moves("Fireball", "Casts a simple orb of fire to fling at your enemies", "mage", 10, 85, 10, 100));
        moves.Add(new Moves("Mend", "Casts a rejuvenating heal that restores hp", "healer", 15, 0, 20, 100));
    }

    public static Moves GetMove(string name)
    {
        for(int i=0; i<moves.Count; i++)
        {
            if (moves[i].name.Equals(name))
                return moves[i];
        }
        return null;
    }
}
