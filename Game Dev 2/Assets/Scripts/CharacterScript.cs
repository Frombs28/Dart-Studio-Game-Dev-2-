using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterScript : MonoBehaviour
{
    public float moveSpeed; //this should be overridden
    //public bool amPlayer; //if so, don't receive AI commands
    public Camera cam; //player character rotation based on camera rotation

    private void Start()
    {
        cam = GameObject.Find("Main Camera").GetComponent<Camera>();
    }

    //movement if this character is possessed by the player
    void MovePlayer()
    {
        Vector3 myVect = new Vector3(Input.GetAxis("Horizontal"), 0f, Input.GetAxis("Vertical")).normalized;
        transform.Translate(myVect * moveSpeed * Time.deltaTime);
    }

    //rotation based on camera rotation if this character is possessed by the player
    void RotatePlayer()
    {
        //this isn't perfect but it works for now
        transform.rotation = Quaternion.Euler(0, cam.transform.rotation.eulerAngles.y, 0);
    }

    public void ActivateCam()
    {
        transform.Find("3rd Person Cam(Clone)").gameObject.SendMessage("Activate");
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
    public virtual void Attack() {}
    public virtual void TraversalAbility() {}
}