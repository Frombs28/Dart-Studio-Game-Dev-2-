using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class InstantiateScript : MonoBehaviour
{

    public GameObject inputManager;
    public GameObject meleePrefab;
    public GameObject rangedPrefab;

    private GameObject myCam;
    private CinemachineVirtualCamera vCam;
    private GameObject myCharacter;

    private void Start()
    {
        InstantiateCharacter(meleePrefab, new Vector3(0, 2, 0), true);
        InstantiateCharacter(rangedPrefab, new Vector3(5, 2, 5), false);
    }

    private void InstantiateCharacter(GameObject myPrefab, Vector3 myPos, bool isPlayer)
    {
        myCharacter = Instantiate(myPrefab, myPos, Quaternion.identity);
        myCam = new GameObject("VirtualCamera"); //it needs to be a freelook camera
        myCam.AddComponent<CamScript>();
        vCam = myCam.AddComponent<CinemachineVirtualCamera>();
        vCam.m_LookAt = myCharacter.transform;
        vCam.m_Follow = myCharacter.transform;
        myCharacter.SendMessage("AssignCamera", myCam);
        /*
        var transposer = vCam.GetCinemachineComponent<CinemachineTransposer>();
        transposer.m_ScreenX = 0.4; //idk if this is even real //update it's not //or at least it's not under "transposer"
        */

        if (isPlayer)
        {
            inputManager.SendMessage("AssignPlayer", myCharacter);
            myCam.SendMessage("Activate");
            //do something to assign the Main Camera to the virtual camera
        }
        else
        {
            myCam.SendMessage("DeActivate");
        }
        inputManager.SendMessage("PopulateCamList", myCam);
    }
}