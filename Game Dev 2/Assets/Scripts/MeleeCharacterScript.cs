using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//this is a subclass inheriting from CharacterScript
//this will overload behavior specific to this class, such as attacking and movement abilities
//much of this character's behavior will be handled by CharacterScript's base

public class MeleeCharacterScript : CharacterScript
{
    public float dashDistance = 10f;
    public float dashSpeed = 10f;
    public float dashTime = 0.5f;
    private Vector3 dashDirection;
    private float dashStartTime;
    private Vector3 startPos;
    //remember to override movespeed in the inspector!

    public override void Attack()
    {
        base.Attack();
        Debug.Log("melee attack!");
    }
    public override void TraversalAbility() //i have a problem in the form of collisions not happening
    {
        base.TraversalAbility();
        startPos = transform.position;
        dashStartTime = Time.time;
        //"flatten" the input axes to be trinarily 1 or 0 or -1 instead of a float between the three
        float myVert = Input.GetAxis("Vertical");
        float myHor = Input.GetAxis("Horizontal");
        if (myVert != 0)
        {
            if (myVert < 0) { myVert = -1; }
            else { myVert = 1; }
        }
        if (myHor != 0)
        {
            if (myHor < 0) { myHor = -1; }
            else { myHor = 1; }
        }
        if (myVert == 0 && myHor == 0) { myVert = 1; }
        dashDirection = new Vector3(myHor, 0, myVert);
        Vector3.Normalize(dashDirection);
        StartCoroutine("Dash");
    }

    IEnumerator Dash()
    {
        while (Vector3.Distance(startPos, transform.position) <= dashDistance && (Time.time - dashStartTime) <= dashTime)
        {
            zeroMovement = false;
            interruptMovement = true;
            //transform.Translate(dashDirection * dashSpeed * Time.deltaTime);
            moveDirection = dashDirection * dashSpeed;
            moveDirection = transform.TransformDirection(moveDirection);
            yield return null;
        }
        interruptMovement = false;
    }
}
