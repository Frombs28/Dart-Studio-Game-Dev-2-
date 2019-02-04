using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//this should be in "CharacterScript"
//and you should check "amPlayer" before doing it
//nah just have input manager send a message to do it
//no wait that's less efficient
//no wait that's more efficient

public class MouseRotation : MonoBehaviour
{
    public Camera cam;

    private void Update()
    {
        transform.rotation = Quaternion.Euler(0, cam.transform.rotation.eulerAngles.y, 0);
    }
}