using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//this is a subclass inheriting from CharacterScript
//this will overload behavior specific to this class, such as attacking and movement abilities
//much of this character's behavior will be handled by CharacterScript's base

public class MeleeCharacterScript : CharacterScript
{
    
    //remember to override movespeed in the inspector!
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
