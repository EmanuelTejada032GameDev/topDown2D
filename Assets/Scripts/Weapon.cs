using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{

    public GameObject projectile;
    public Transform firePoint;
    public float timeBetweenShots;

    private float _shotTime;


    // Update is called once per frame
    void Update()
    {
        Vector2 direction = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        Quaternion rotation = Quaternion.AngleAxis(angle - 90 , Vector3.forward);
        transform.rotation = rotation;

        if (Input.GetMouseButton(0))
        {
            if(Time.time >= _shotTime)
            {
                Instantiate(projectile, firePoint.position, transform.rotation);
                _shotTime = Time.time + timeBetweenShots;
            }
        }

    }
}
