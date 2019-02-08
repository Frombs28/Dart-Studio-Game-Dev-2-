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
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hitInfo;
        if (Physics.Raycast(ray, out hitInfo, 100))
            print("Hit something!");
        var enemy = hitInfo.collider.GetComponent<CharacterScript>();
        enemy.TakeDamage();
    }

}
