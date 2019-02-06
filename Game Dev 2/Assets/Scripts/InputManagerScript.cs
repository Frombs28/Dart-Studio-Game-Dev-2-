using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManagerScript : MonoBehaviour
{
    public GameObject player; //whoms't'd've'ever is possessed rn
    public GameObject playerCam; //this is only public for debuggind and stuff
    private Camera mainCam;
    public List<GameObject> cams = new List<GameObject>();
    private bool possessing = false; //just a flag

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
        //okay so it's saying that the sendmessages don't have recievers and idk why
        if (Input.GetAxis("Possess") != 0 && player && !possessing)
        {
            mainCam = GameObject.Find("Main Camera").GetComponent<Camera>();
            possessing = true;
            playerCam = player.transform.Find("3rd Person Cam(Clone)").gameObject;
            RaycastHit hit;
            if (Physics.Raycast(mainCam.transform.position, mainCam.transform.forward, out hit))
            {
                if (hit.collider.gameObject.tag == "Possessable")
                {
                    Debug.Log("Did it!!!");
                    playerCam.SendMessage("DeActivate");
                    hit.collider.gameObject.SendMessage("ActivateCam");
                    player = hit.collider.gameObject;
                }
            }
            possessing = false;
        }
    }
}