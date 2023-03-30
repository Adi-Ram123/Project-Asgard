using System.Linq;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Tilemaps;

[CreateAssetMenu]
public class ExampleSiblingRuleTile : RuleTile
{
    [Header("Advanced Tile")]

    [Tooltip("If enabled, the tile will connect to these tiles too when the mode is set to \"This\"")]
    public bool alwaysConnect;

    [Space]
    [Tooltip("Tiles to connect to")]
    public TileBase[] tilesToConnect;

    [Space]
    [Tooltip("Check itseft when the mode is set to \"any\"")]
    public bool checkSelf = true;

    public class Neighbor : RuleTile.TilingRule.Neighbor
    {
        public const int Specified = 3;
    }

    public override bool RuleMatch(int neighbor, TileBase tile)
    {
        switch (neighbor)
        {
            case Neighbor.This: return Check_This(tile);
            case Neighbor.NotThis: return Check_NotThis(tile);
            case Neighbor.Specified: return Check_Specified(tile);
        }
        return base.RuleMatch(neighbor, tile);
    }
    bool Check_This(TileBase tile)
    {
        if (!alwaysConnect) return tile == this;
        else return tilesToConnect.Contains(tile) || tile == this;
        //.Contains requires "using System.Linq;"
    }
    bool Check_NotThis(TileBase tile)
    {
        if (!alwaysConnect) return tile != this;
        else return !tilesToConnect.Contains(tile) && tile != this;
        //.contains requires "using system.linq;"
    }
    bool Check_Specified(TileBase tile)
    {
        if (checkSelf) return tile != null;
        else return tile != null && tile != this && tile == tilesToConnect.Contains(tile);
    }



    /*public enum SibingGroup
    {
        Poles,
        Terrain,
    }
    public SibingGroup sibingGroup;
   

    public override bool RuleMatch(int neighbor, TileBase other)
    {

        return other != null && connect_to.Contains(other);


        // This script checks if a tile is part of its sibling group and if so, then connect to it.
        // However there is more specific conditions that can be placed to only connnect to specific tiles.
        /*
        if (other is RuleOverrideTile)
            other = (other as RuleOverrideTile).m_InstanceTile;

        switch (neighbor)
        {

            case TilingRule.Neighbor.This:
                {
                    return other is ExampleSiblingRuleTile
                        && (other as ExampleSiblingRuleTile).sibingGroup == this.sibingGroup;
                }

            case TilingRule.Neighbor.NotThis:
                {
                    return !(other is ExampleSiblingRuleTile
                        && (other as ExampleSiblingRuleTile).sibingGroup == this.sibingGroup);
                }
        }

        return base.RuleMatch(neighbor, other);
        
    }
*/
}
