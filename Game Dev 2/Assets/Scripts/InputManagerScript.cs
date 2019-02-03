using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManagerScript : MonoBehaviour
{
    public GameObject player; //whoms't'd've'ever is possessed rn

    private void Update()
    {
        //player movement
        if (Input.GetAxis("Vertical") != 0 || Input.GetAxis("Horizontal") != 0 && player) { player.SendMessage("MovePlayer"); }

        //attack and traversal ability
        //at this point these are just proof of concept
        if (Input.GetAxis("Attack") != 0) { player.SendMessage("Attack"); }
        else if (Input.GetAxis("TraversalAbility") != 0) { player.SendMessage("TraversalAbility"); }
    }
}