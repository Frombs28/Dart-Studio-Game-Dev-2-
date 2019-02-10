using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    public int damage = 1;
    public Camera cam;
    public GameObject bullet;
    public GameObject barrel;
    public float bullet_speed = 50f;

    void Start()
    {
        cam = GameObject.Find("Main Camera").GetComponent<Camera>();
        barrel = transform.GetChild(0).gameObject;
    }

    void Update()
    {

    }

    private void FireGun()
    {
        /*
        //Ray ray = cam.ScreenPointToRay(Input.mousePosition);//creates the ray cast
        Ray ray = new Ray(transform.position, transform.forward);//creates the ray cast
        RaycastHit hitInfo;//creates info for thing it hit
        if (Physics.Raycast(ray, out hitInfo, 100))//if it hit something, interact with enemy
        {
            print("Hit something!");
            var enemy = hitInfo.collider.GetComponent<CharacterScript>();
            enemy.TakeDamage(damage);
        }
              
        //Debug.DrawRay(transform.position, transform.forward * 100, Color.red, 2f);
        */
        GameObject cur_bullet;
        cur_bullet = Instantiate(bullet, barrel.transform.position, barrel.transform.rotation);
        cur_bullet.GetComponent<Rigidbody>().velocity = cam.transform.TransformDirection(Vector3.forward * bullet_speed);
        cur_bullet.layer = 9;
        Destroy(cur_bullet, 10);
    }

    private void FireEnemyGun()
    {
        GameObject cur_bullet;
        cur_bullet = Instantiate(bullet, barrel.transform.position, barrel.transform.rotation);
        cur_bullet.GetComponent<Rigidbody>().velocity = transform.TransformDirection(Vector3.forward * bullet_speed);
    }

}
