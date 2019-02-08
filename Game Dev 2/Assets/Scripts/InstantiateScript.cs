using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

//spawns characters and assigns virtual cameras to them

public class InstantiateScript : MonoBehaviour
{
    public GameObject inputManager;
    public GameObject meleePrefab;
    public GameObject rangedPrefab;
    public GameObject cam; //the main camera //for now just set in the inspector might do it dynamically in a hot sec

    private GameObject myCharacter; //to be instantiated

    private void Start()
    {
        //populate the scene with some characters
        InstantiateCharacter(meleePrefab, new Vector3(0, 2, 0), true);
        InstantiateCharacter(rangedPrefab, new Vector3(5, 2, 5), false);
    }

    //makes a guy
    private void InstantiateCharacter(GameObject myPrefab, Vector3 myPos, bool isPlayer)
    {
        myCharacter = Instantiate(myPrefab, myPos, Quaternion.identity);
        if (isPlayer)
        {
            inputManager.SendMessage("AssignPlayer", myCharacter);
            cam.SendMessage("AssignPlayer", myCharacter);
        }
    }
}