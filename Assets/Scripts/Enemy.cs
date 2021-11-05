using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int health;

    [HideInInspector]
    public Transform player;
    public float speed;
    public int damage;

    public float timeBetweenAttacks;

    public int pickUpChance;
    public GameObject[] pickups;


    public virtual void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }
    public void takeDamage(int damageAmount)
    {
        health -= damageAmount;
        if(health <= 0)
        {
            int randomNumber = Random.Range(0, 101);
            if(randomNumber < pickUpChance)
            {
                GameObject randomPickup = pickups[Random.Range(0, pickups.Length)];
                Instantiate(randomPickup, transform.position, transform.rotation);
            }
            Destroy(gameObject);
        }
    }
}
