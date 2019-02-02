using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManagerScript : MonoBehaviour
{
    public GameObject player;   //whoms't'd've is possessed rn?

    private void Update()
    {
        if (Input.GetMouseButtonDown(0)) {player.SendMessage("Attack");}
        else if (Input.GetMouseButtonDown(1)) {player.SendMessage("TraversalAbility");}
    }
}