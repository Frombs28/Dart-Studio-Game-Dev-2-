﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//the base character class
//all character types will inherit from this class
//sub-classes will override functions specific to thier own behavior, such as attacking and using movement abilities
//this base class will contain behavior that every character would use, such as movement and AI
//this class also allows the character to be controlled by the player

public class CharacterScript : MonoBehaviour
{
    public float moveSpeed; //how fast the character can move //this should be overridden
    //public bool amPlayer; //if so, don't receive AI commands
    public Camera cam; //player character rotation is based on camera rotation //this is the MAIN CAMERA,  *not*  your personal VIRTUAL CAMERA
    public bool traversalInterrupted = false; //flag set true on collision to stop the character from dashing through a wall or character

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



    private void Start()
    {
        //get a reference to the main camera
        //you'll need to do this every time you change cameras in the future
        cam = GameObject.Find("Main Camera").GetComponent<Camera>();
    }

    //movement if this character is possessed by the player
    //this function gets called from InputManager
    void MovePlayer()
    {
        Vector3 myVect = new Vector3(Input.GetAxis("Horizontal"), 0f, Input.GetAxis("Vertical")).normalized;
        transform.Translate(myVect * moveSpeed * Time.deltaTime);
    }

    //rotation based on camera rotation if this character is possessed by the player
    //this fucntion gets called from InputManager
    void RotatePlayer()
    {
        //this isn't perfect but it works for now
        transform.rotation = Quaternion.Euler(0, cam.transform.rotation.eulerAngles.y, 0);
    }

    //insert a bunch of functions to receive from the AI controller
    //movement if this character is not possessed by the player
    /*
    void MoveForwards() {transform.Translate(Vector3.forward * moveSpeed * Time.deltaTime);}
    void MoveBackwards() {transform.Translate(Vector3.forward * moveSpeed * Time.deltaTime);}
    void MoveRight() {transform.Translate(Vector3.right * moveSpeed * Time.deltaTime);}
    void MoveLeft() {transform.Translate(-Vector3.right * moveSpeed * Time.deltaTime);}
    void MoveForwardsRight() {transform.Translate(new Vector3(rootTwo, rootTwo, 0) * moveSpeed * Time.deltaTime);}
    void MoveForwardsLeft() {transform.Translate(new Vector3(rootTwo, -rootTwo, 0) * moveSpeed * Time.deltaTime);}
    void MoveBackwardsRight() {transform.Translate(new Vector3(-rootTwo, rootTwo, 0) * moveSpeed * Time.deltaTime);}
    void MoveBackwardsLeft() {transform.Translate(new Vector3(-rootTwo, -rootTwo, 0) * moveSpeed * Time.deltaTime);}
    */

    //the virtual stuff that must be overloaded by the subclasses
    public virtual void Attack() { }
    public virtual void TraversalAbility() { }
    public virtual void TakeDamage(int damage)
    {
        enemyhealth -= damage;
        print("hey it worked");
        if (enemyhealth <= 0)
        {
            Destroy(gameObject,0.1f);
        }
    }

    void OnCollisionEnter(Collision collider)
    {
        if (collider.gameObject.tag == "Projectile")
        {
            Destroy(collider.gameObject);
            TakeDamage(1);
        }
        else if (collider.gameObject.tag == "Possessable" || collider.gameObject.tag == "Wall")
        {
            Debug.Log("yo was good famsquad");
            traversalInterrupted = true;
        }
    }
}