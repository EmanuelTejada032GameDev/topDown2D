using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class healthPickup : MonoBehaviour
{
    public int healthAmount;
    private Player playerScript;
    public GameObject pickupEffect;
    public GameObject pickupSound;

    private void Start()
    {
        playerScript = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            playerScript.Heal(healthAmount);
            Instantiate(pickupEffect, transform.position, Quaternion.identity);
            Instantiate(pickupSound, transform.position, Quaternion.identity);

            Destroy(gameObject);
        }
    }
}
