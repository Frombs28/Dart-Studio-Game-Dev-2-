using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThirdPersonCamScript : MonoBehaviour
{
    public Transform lookAt;

    public float distance = 10f;
    public float sensitivityX = 4f;
    public float sensitivityY = 4f;
    public float minY = -70f;
    public float maxY = 70f;
    private float currentX = 0f;
    private float currentY = 0f;

    public void AssignPlayer(GameObject player)
    {
        lookAt = player.transform;
    }

    private void Update()
    {
        currentX += Input.GetAxis("Mouse X");
        currentY += Input.GetAxis("Mouse Y");

        currentY = Mathf.Clamp(currentY, minY, maxY);
    }

    private void LateUpdate()
    {
        Vector3 direction = new Vector3(0, 0, -distance);
        Quaternion rotation = Quaternion.Euler(-currentY, currentX, 0);
        transform.position = lookAt.position + (rotation * direction);
        transform.LookAt(lookAt.position);
    }
}
