using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//this is a subclass inheriting from CharacterScript
//this will overload behavior specific to this class, such as attacking and movement abilities
//much of this character's behavior will be handled by CharacterScript's base

public class RangedCharacterScript : CharacterScript
{

    GameObject player;

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

    // Use this for initialization
    void Awake()
    {
        player = GameObject.Find("Player");
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float y = transform.position.y;
        //Vector3 newpos = Vector3.MoveTowards(transform.position, player.transform.position, 5*Time.deltaTime);
        //newpos.y = y;
        transform.LookAt(player.transform);
        transform.rotation = Quaternion.Euler(0, transform.rotation.eulerAngles.y, transform.rotation.eulerAngles.z);
        Ray ray = new Ray(transform.position, transform.forward);//creates the ray cast
        RaycastHit hitInfo;//creates info for thing it hit
        if (Physics.Raycast(ray, out hitInfo, 100))//if it hit something, interact with enemy
        {
            if (hitInfo.transform == player.transform)
            {
                //shoot the gun code here
            }
        }
        //transform.position = newpos;

    }
    /* will use knockback if needed
    public void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.gameObject.GetComponent<CharacterScript>().TakeDamage(40);
            Vector3 diff = transform.position - collision.gameObject.transform.position;
            diff.Normalize();
            diff.y = 0;
            collision.gameObject.GetComponent<Rigidbody>().AddForce(-3000*diff);
        }
    }
    */
   
}
