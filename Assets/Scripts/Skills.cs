using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skills
{
    public static List<Moves> moves;

    public static void StoreList()
    {
        moves = new List<Moves>();

        moves.Add(new Moves("Slash", "Strikes the enemy with the main hand", "normal", new List<string> {"player", "slime"}, 20, 50, 0, 1));
        moves.Add(new Moves("Helm Splitter", "Uses Big Axe to do big damage", "barbarian", new List<string> {"player"}, 5, 120, 0, 0.75f));
        moves.Add(new Moves("Fireball", "Casts a simple orb of fire to fling at your enemies", "mage", new List<string> {"player"}, 0, 85, 10, 0.9f));
        moves.Add(new Moves("Mend", "Casts a rejuvenating heal that restores hp", "healer", new List<string> {"player", "slime"}, 15, 0, 20, 1));
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

    public static List<Moves> GetAvailable(string usable, int moveCount)
    {
        List<Moves> list = new List<Moves>();
        for (int i = 0; i < moves.Count; i++)
        {
            for (int j = 0; j < moves[i].usable.Count; j++)
            {
                if (moves[i].usable[j].Equals(usable))
                    list.Add(moves[i]);
            }
        }
        while(list.Count > moveCount)
        {
            list.RemoveAt(Random.Range(0, list.Count));
        }
        return list;
    }
}
