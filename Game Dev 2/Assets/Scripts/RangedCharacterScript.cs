using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//this is a subclass inheriting from CharacterScript
//this will overload behavior specific to this class, such as attacking and movement abilities
//much of this character's behavior will be handled by CharacterScript's base

public class RangedCharacterScript : CharacterScript
{
    public float dashDistance = 10f;
    public float dashSpeed = 2f;
    public float dashTime = 1f;
    public float dashCoolDown = 1f;
    private Vector3 dashDirection;
    private float dashStartTime;
    private float dashEndTime = 0;
    private Vector3 startPos;

    private bool dashing = false;
    //remember to override movespeed in the inspector!

    public override void Attack()
    {
        base.Attack();
    }
    public override void TraversalAbility() //i have a problem in the form of collisions not happening
    {
        if ((Time.time - dashEndTime) >= dashCoolDown && !dashing && controller.isGrounded)
        {
            base.TraversalAbility();
            dashing = true;
            startPos = transform.position;
            dashStartTime = Time.time;
            dashDirection = new Vector3(0, 0, 1);
            Vector3.Normalize(dashDirection);
            cam.SendMessage("ChargeCam");
            StartCoroutine("Charge");
        }
    }

    public override void Ability()
    {
        
    }

    public override bool IsCharging()
    {
        Debug.Log(dashing);
        return dashing;
    }

    void StopCharging()
    {
        StopCoroutine("Charge");
        interruptMovement = false;
        cam.SendMessage("NormCam");
        dashEndTime = Time.time;
        dashing = false;
    }

    IEnumerator Charge()
    {
        while ((Time.time - dashStartTime) <= dashTime)
        {
            zeroMovement = false;
            interruptMovement = true;
            //transform.Translate(dashDirection * dashSpeed * Time.deltaTime);
            moveDirection = dashDirection * dashSpeed;
            moveDirection = transform.TransformDirection(moveDirection);
            yield return null;
        }
        interruptMovement = false;
        cam.SendMessage("NormCam");
        dashEndTime = Time.time;
        dashing = false;
    }
}
