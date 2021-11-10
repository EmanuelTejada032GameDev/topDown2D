using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : MonoBehaviour
{
    public int health;
    public Enemy[] enemies;
    public float spawnOffset;

    private int halfHealth;
    private Animator _animator;
    public int damage;
    private void Start()
    {
        halfHealth = health / 2;
        _animator = GetComponent<Animator>();
    }
    public void takeDamage(int damageAmount)
    {
        health -= damageAmount;
        if (health <= 0)
        {
            Debug.Log("wasted");
            Destroy(gameObject);
        }

        if (health <= halfHealth)
        {
            _animator.SetTrigger("stage2");
        }


        Enemy randomEnemy = enemies[Random.Range(0, enemies.Length)];
        Instantiate(randomEnemy, transform.position + new Vector3(spawnOffset, spawnOffset, 0), transform.rotation);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            collision.GetComponent<Player>().takeDamage(damage);
        }
    }

}
