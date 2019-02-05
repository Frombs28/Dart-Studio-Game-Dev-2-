using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManagerScript : MonoBehaviour
{
    public GameObject player; //whoms't'd've'ever is possessed rn
    public List<GameObject> cams = new List<GameObject>();

    public void AssignPlayer(GameObject myPlayer)
    {
        player = myPlayer;
    }

    public void PopulateCamList(GameObject myCam)
    {
        cams.Add(myCam);
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
        //I'M SO CLOSE TO BEING ABLE TO IMPLEMENT THIS I SWEAR TO GOD
    }
}