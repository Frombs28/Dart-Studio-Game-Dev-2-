using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterScript : MonoBehaviour
{
    //movement
    //only the movespeed itself will be overloaded
    public float moveSpeed;
    private float rootTwo = Mathf.Sqrt(2);

    void MoveForwards() {transform.Translate(Vector3.forward * moveSpeed * Time.deltaTime);}
    void MoveBackwards() {transform.Translate(Vector3.forward * moveSpeed * Time.deltaTime);}
    void MoveRight() {transform.Translate(Vector3.right * moveSpeed * Time.deltaTime);}
    void MoveLeft() {transform.Translate(-Vector3.right * moveSpeed * Time.deltaTime);}
    void MoveForwardsRight() {transform.Translate(new Vector3(rootTwo, rootTwo, 0) * moveSpeed * Time.deltaTime);}
    void MoveForwardsLeft() {transform.Translate(new Vector3(rootTwo, -rootTwo, 0) * moveSpeed * Time.deltaTime);}
    void MoveBackwardsRight() {transform.Translate(new Vector3(-rootTwo, rootTwo, 0) * moveSpeed * Time.deltaTime);}
    void MoveBackwardsLeft() {transform.Translate(new Vector3(-rootTwo, -rootTwo, 0) * moveSpeed * Time.deltaTime);}

    //the virtual stuff that must be overloaded by the subclasses
    public virtual void Attack() {}
    public virtual void TraversalAbility() {}
}