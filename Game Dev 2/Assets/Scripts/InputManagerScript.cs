using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManagerScript : MonoBehaviour
{   
    public GameObject player; //whoms't'd've'ever is possessed rn
    private Camera mainCam; //the main camera in the scene, which should usually be showing the player's POV
    public List<GameObject> cams = new List<GameObject>(); //might not actually use this lol whoops but let's hold onto it for now anyway
    private bool possessing = false; //just a flag
    private int playerhealth=10;

    //when the player possesses a character, this is called to set the new character to our variable "player," which is used in turn to call movement functions on whichever character the player is controlling
    //remember to set the old player's layer back to 0 (so it can be hit by raycasts and be possessed) before you call this
    //i would put that in this function but setting up optional arguments is a hassle
        //in fact i'll have to do this if we want to call this from anywhere other than here so i'll probably actually do it eventually
    //this function is also called by InstantiateScript to determine who the player is when the scene just starts
    public void AssignPlayer(GameObject myPlayer)
    {
        player = myPlayer;
        player.layer = 2; //ignore raycast //should probably eventually change to custom layer
    }

    public void PopulateCamList(GameObject myCam)
    {
        cams.Add(myCam);
    }


    public void tookdamage() //plz capitalize every word in your function names as per the standard many thank
    {
        playerhealth -= 1;
        player.SendMessage("TakeDamage");
    }

    private void Update()
    {
        //player movement
        //if the player is pressing the WASD keys, call a function on the CharacterScript of whatever character the player is controlling
        if (Input.GetAxis("Vertical") != 0 || Input.GetAxis("Horizontal") != 0 && player) { player.SendMessage("MovePlayer"); }
        if (player) { player.SendMessage("RotatePlayer"); }

        //attack and traversal ability
        //if the player is pressing the appropriate keys, call a function on the CharacterScript of whatever character the player is controlling
        if (Input.GetAxis("Attack") != 0 && player) { player.SendMessage("Attack"); }
        else if (Input.GetAxis("TraversalAbility") != 0 && player) { player.SendMessage("TraversalAbility"); }

        //possession
        //if (Input.GetAxis("Possess") != 0 && player && !possessing)
        if(Input.GetMouseButtonDown(1) && player && !possessing)
        {
            //set your flag
            possessing = true;
            //do a raycast from the main camera
            mainCam = GameObject.Find("Main Camera").GetComponent<Camera>();
            RaycastHit hit; //this will contain a path to a reference to whatever GameObject got hit
            int layerMask = 1 << 2;
            layerMask = ~layerMask; //the raycast will ignore anything on this layer
            
            if (Physics.Raycast(mainCam.transform.position, mainCam.transform.forward, out hit, Mathf.Infinity, layerMask))
            {
                if (hit.collider.gameObject.tag == "Possessable")
                {
                    //BTW transform.Find only works bc those virtual cameras are children of the character game objects
                    //de-active the old player character's camera
                    player.transform.Find("VirtualCamera").gameObject.SetActive(false);
                    //set the player to the new character
                    player.layer = 0; //i would put this in AssignPlayer but it's a hassle so do it here
                    AssignPlayer(hit.collider.gameObject);
                    //activate the new player character's virtual camera
                    player.transform.Find("VirtualCamera").gameObject.SetActive(true);
                }
            }
            //reset your flag
            possessing = false;
        }
    }
}