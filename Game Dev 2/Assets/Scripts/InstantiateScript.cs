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
    //public GameObject camPrefab;

    private GameObject myCam; //to be instantiated //the virtual camera game object that will be assigned to a character
    private CinemachineFreeLook vCam; //to be instantiated //the component of the above virtual camera that handles settings
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
        //myCam = Instantiate(camPrefab, myCharacter.transform);
        myCam = new GameObject("VirtualCamera");
        myCam.transform.SetParent(myCharacter.transform);
            //you need to assign all sorts of setting here if you're not using a prefab
        //vCam = myCam.GetComponent<CinemachineFreeLook>();
        vCam = myCam.AddComponent<CinemachineFreeLook>();
        vCam.m_LookAt = myCharacter.transform;
        vCam.m_Follow = myCharacter.transform;

        if (isPlayer)
        {
            inputManager.SendMessage("AssignPlayer", myCharacter);
            myCam.SetActive(true);
        }
        else
        {
            myCam.SetActive(false);
        }
        inputManager.SendMessage("PopulateCamList", myCam);
    }
}