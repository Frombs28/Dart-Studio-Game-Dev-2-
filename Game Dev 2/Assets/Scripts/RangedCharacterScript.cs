using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangedCharacterScript : CharacterScript
{
    public override void Attack()
    {
        base.Attack();
        Debug.Log("ranged attack!");
    }
    public override void TraversalAbility()
    {
        base.TraversalAbility();
        Debug.Log("ranged traversal!");
    }
}
