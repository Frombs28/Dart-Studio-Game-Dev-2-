using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    public int damage = 1;
    public Camera cam;
    public GameObject bullet;
    public GameObject barrel;
    public float bullet_speed = 0.1f;
    float start_time = 0f;
    float burst_rate = 60f;
    int burst_num = 4;
    int i;

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
        
        GameObject cur_bullet;
        Vector3 myDirection;
        RaycastHit hit;
        if (Physics.Raycast(cam.transform.position, cam.transform.forward, out hit))
        {
            myDirection = hit.point - barrel.transform.position;
        }
        else
        {
            myDirection = cam.transform.forward;
        }
        cur_bullet = Instantiate(bullet, barrel.transform.position, barrel.transform.rotation);
        //cur_bullet.GetComponent<Rigidbody>().velocity = cam.transform.TransformDirection(Vector3.forward * bullet_speed);
        cur_bullet.GetComponent<Rigidbody>().velocity = myDirection.normalized * bullet_speed;
        cur_bullet.layer = 9;
        Destroy(cur_bullet, 5);
    }

    private void FireEnemyGun()
    {
        StartCoroutine("FireBurst");
        print("Fire!");
        i = 0;
    }

    IEnumerator FireBurst()
    {
        for(i = 0; i < burst_num; i++)
        {
            GameObject cur_bullet;
            cur_bullet = Instantiate(bullet, barrel.transform.position, barrel.transform.rotation);
            cur_bullet.GetComponent<Rigidbody>().velocity = transform.TransformDirection(Vector3.forward * (bullet_speed * 0.5f));
            Destroy(cur_bullet, 5);
            yield return new WaitForSeconds(burst_rate);
        }

    }
}
