using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeCharacterScript : CharacterScript
{
    public override void Attack()
    {
        base.Attack();
        Debug.Log("melee attack!");
    }
    public override void TraversalAbility()
    {
        base.TraversalAbility();
        Debug.Log("melee traversal!");
    }
}
