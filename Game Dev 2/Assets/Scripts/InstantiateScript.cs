using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class InstantiateScript : MonoBehaviour
{
    //don't worry about events rn, just plop some bois and cams down and maybe some more after some time has passed, as a proof of concept
    //give your cameras to the input manager
    //give the player to the input manager
    //do this in Start()

    public GameObject inputManager;
    public GameObject camPrefab;
    public GameObject meleePrefab;
    public GameObject rangedPrefab;

    private GameObject myCam;
    private CinemachineVirtualCamera vCam;
    private GameObject myCharacter;

    private void Start()
    {
        myCharacter = Instantiate(meleePrefab, new Vector3(0, 2, 0), Quaternion.identity);

        myCam = Instantiate(camPrefab, myCharacter.transform);
        vCam = myCam.GetComponent<CinemachineVirtualCamera>();
        vCam.m_LookAt = myCharacter.transform;
        vCam.m_Follow = myCharacter.transform;

        inputManager.SendMessage("AssignPlayer", myCharacter);
        myCam.SendMessage("Activate");
        inputManager.SendMessage("PopulateCamList", myCam);

        myCharacter = Instantiate(rangedPrefab, new Vector3(0, 2, 0), Quaternion.identity);

        myCam = Instantiate(camPrefab, myCharacter.transform);
        vCam = myCam.GetComponent<CinemachineVirtualCamera>();
        vCam.m_LookAt = myCharacter.transform;
        vCam.m_Follow = myCharacter.transform;

        inputManager.SendMessage("PopulateCamList", myCam);
        myCam.SendMessage("DeActivate");
        //do i pass in myCam or vCam???
        //do i have the prefab be an actual camera or a virtual camera???
        //if it works with a virtual camera, do that. if not, create the virtual camera and set the fov and screenxoffset in code

        //your problem is that you instantiate an object and then try to get a reference to it in the same frame, before it had time to instantiate.
        //well, what are you doing here that you could be doing in myCharacter's Awake()???
        //nah man i'm just trying to access the transform so i can assign my vCam to it
        //i could try to do that from vCam but then vCam needs a reference to myCharacter

    }
}