using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManagerScript : MonoBehaviour
{   
    public GameObject player; //whoms't'd've'ever is possessed rn
    private Camera mainCam;
    public List<GameObject> cams = new List<GameObject>(); //might not actually use this lol whoops but let's hold onto it for now anyway
    private bool possessing = false; //just a flag
    private int playerhealth=10;

    public void AssignPlayer(GameObject myPlayer)
    {
        player = myPlayer;
        player.layer = 2; //ignore raycast //should probably eventually change to custom layer
    }

    public void PopulateCamList(GameObject myCam)
    {
        cams.Add(myCam);
    }


    public void tookdamage()
    {
        playerhealth -= 1;
        player.SendMessage("TakeDamage");
    }

    private void Update()
    {
        //player movement
        if (Input.GetAxis("Vertical") != 0 || Input.GetAxis("Horizontal") != 0 && player) { player.SendMessage("MovePlayer"); }
        if (player) { player.SendMessage("RotatePlayer"); }

        //attack and traversal ability
        //at this point these are just proof of concept
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
            RaycastHit hit;
            int layerMask = 1 << 2;
            layerMask = ~layerMask;
            
            if (Physics.Raycast(mainCam.transform.position, mainCam.transform.forward, out hit, Mathf.Infinity, layerMask))//should probs give it a layer mask
            {
                if (hit.collider.gameObject.tag == "Possessable")
                {
                    //de-active that player's camera
                    player.transform.Find("VirtualCamera").gameObject.SetActive(false);
                    //set the player
                    player.layer = 0;
                    AssignPlayer(hit.collider.gameObject);
                    //activate the player's camera and de-activate all the other cameras
                    player.transform.Find("VirtualCamera").gameObject.SetActive(true);
                }
            }
            //reset your flag
            possessing = false;
        }
    }
}