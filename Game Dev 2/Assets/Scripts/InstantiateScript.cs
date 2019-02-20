﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//spawns characters and assigns virtual cameras to them

public class InstantiateScript : MonoBehaviour
{
    public GameObject inputManager;
    public GameObject meleePrefab;
    public GameObject rangedPrefab;
    public GameObject cam; //the main camera //for now just set in the inspector might do it dynamically in a hot sec

    private GameObject myCharacter; //to be instantiated

    private GameObject myPlayer;

    private void Start()
    {
        //populate the scene with some characters
        InstantiateCharacter(meleePrefab, new Vector3(0, 2, 0), true);

        InstantiateCharacter(meleePrefab, new Vector3(10, 2, 5), false);
        InstantiateCharacter(meleePrefab, new Vector3(20, 2, 10), false);
        InstantiateCharacter(meleePrefab, new Vector3(30, 2, 15), false);
        InstantiateCharacter(meleePrefab, new Vector3(-10, 2, -5), false);
        InstantiateCharacter(meleePrefab, new Vector3(-20, 2, -10), false);
        InstantiateCharacter(meleePrefab, new Vector3(-30, 2, -15), false);
        InstantiateCharacter(meleePrefab, new Vector3(40, 2, 5), false);
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    //makes a guy
    private void InstantiateCharacter(GameObject myPrefab, Vector3 myPos, bool isPlayer)
    {
        myCharacter = Instantiate(myPrefab, myPos, Quaternion.identity);
        if (isPlayer)
        {
            inputManager.SendMessage("AssignPlayer", myCharacter);
            cam.SendMessage("AssignPlayer", myCharacter.transform.GetChild(1).gameObject);
            myPlayer = myCharacter;
        }
        myCharacter.SendMessage("AssignPlayer", myPlayer);
        inputManager.SendMessage("PopulateCharacterList", myCharacter);
    }
}