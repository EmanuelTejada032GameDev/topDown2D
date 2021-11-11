using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponPickUp : MonoBehaviour
{
    public Weapon weaponToEquip;
    public GameObject pickupEffect;
    public GameObject pickupSound;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            collision.GetComponent<Player>().ChangeWeapon(weaponToEquip);
            Instantiate(pickupEffect, transform.position, Quaternion.identity);
            Instantiate(pickupSound, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
    }

}
