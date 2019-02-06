using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeCharacterScript : CharacterScript
{
    private int enemyhealth;

    public int Enemyhealth
    {
        get
        {
            return enemyhealth;
        }
        set
        {
            enemyhealth = value;
        }
    }

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
