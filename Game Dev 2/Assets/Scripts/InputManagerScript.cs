using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManagerScript : MonoBehaviour
{   
    public GameObject player; //whoms't'd've'ever is possessed rn
    private Camera mainCam; //the main camera in the scene, which should usually be showing the player's POV
    public bool receiveInput = true; //flag //set false by this script when i start possessing; set true by the camera (which sends a message to this) when the transition is complete
    private int playerhealth=10;
    float timer = 0f;
    float possess_timer = 0f;
    public float fire_rate = 1f;
    public float possession_rate = 1.25f;

    public GameObject reticle;

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

    public void TookDamage() //plz capitalize every word in your function names as per the standard many thank
    {
        playerhealth -= 1;
        player.SendMessage("TakeDamage");
    }

    public void SetReceiveInputTrue()
    {
        receiveInput = true;
    }

    private void Update()
    {
        timer += Time.deltaTime;
        possess_timer += Time.deltaTime;

        //player movement
        //if the player is pressing the WASD keys, call a function on the CharacterScript of whatever character the player is controlling
        if ((Input.GetAxis("Vertical") != 0 || Input.GetAxis("Horizontal") != 0) && player && receiveInput) { player.SendMessage("MovePlayer"); }
        if (Input.GetButton("Jump") && player && receiveInput) { player.SendMessage("JumpPlayer"); }
        if (player && receiveInput) { player.SendMessage("RotatePlayer"); }

        //attack and traversal ability
        //if the player is pressing the appropriate keys, call a function on the CharacterScript of whatever character the player is controlling
        //if (Input.GetAxis("Attack") != 0 && player && receiveInput) { player.SendMessage("Attack"); }
        //else if (Input.GetAxis("TraversalAbility") != 0 && player && receiveInput) { player.SendMessage("TraversalAbility"); }
        if (Input.GetAxis("Attack") != 0 && player && receiveInput) { player.SendMessage("Attack"); }
        if (Input.GetButtonDown("TraversalAbility") && player && receiveInput) { player.SendMessage("TraversalAbility"); }

        //possession
        //if (Input.GetAxis("Possess") != 0 && player && !possessing)
        //if pressed, start timer
        if (Input.GetMouseButtonDown(1) && player && receiveInput)
        {
            possess_timer = 0f;
            reticle.SendMessage("Possessing");
        }
        //if released after enough time has passed, trigger possession
        if(possess_timer >= possession_rate && Input.GetMouseButtonUp(1) && player && receiveInput)
        { 
            //do a raycast from the main camera
            mainCam = GameObject.Find("Main Camera").GetComponent<Camera>();
            RaycastHit hit; //this will contain a path to a reference to whatever GameObject got hit
            int layerMask = 1 << 2;
            layerMask = ~layerMask; //the raycast will ignore anything on this layer
            
            if (Physics.Raycast(mainCam.transform.position, mainCam.transform.forward, out hit, Mathf.Infinity, layerMask))
            {
                if (hit.collider.gameObject.tag == "Possessable")
                {
                    receiveInput = false;
                    //set the player to the new character
                    player.layer = 0; //i would put this in AssignPlayer but it's a hassle so do it here
                    AssignPlayer(hit.collider.gameObject);
                    //transition the camera
                    mainCam.SendMessage("PossessionTransitionStarter", hit.collider.gameObject);
                    //call an actual transition once you write one on the camera
                }
            }
        }

        if (timer >= fire_rate && Input.GetButton("Attack"))
        {
            timer = 0f;
            player.SendMessage("FireGun");
        }
    }
}