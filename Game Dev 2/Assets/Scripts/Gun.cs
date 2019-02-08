using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    void Update()
    {

    }

    private void fireGun()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);//creates the ray cast
        RaycastHit hitInfo;//creates info for thing it hit
        if (Physics.Raycast(ray, out hitInfo, 100))//if it hit something, interact with enemy
        {
            print("Hit something!");
            var enemy = hitInfo.collider.GetComponent<CharacterScript>();
            enemy.TakeDamage();
        }
    }

}
