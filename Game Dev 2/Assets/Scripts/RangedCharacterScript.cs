using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//this is a subclass inheriting from CharacterScript
//this will overload behavior specific to this class, such as attacking and movement abilities
//much of this character's behavior will be handled by CharacterScript's base

public class RangedCharacterScript : CharacterScript
{

 

    //remember to set movespeed in the inspector!
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

    private void Update()
    {
        
    }
}
