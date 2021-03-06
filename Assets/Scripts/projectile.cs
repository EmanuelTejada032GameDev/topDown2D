using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class projectile : MonoBehaviour
{
    public float speed;
    public float lifeTime;
    public GameObject explosion;
    public GameObject projectileSound;

    public int damage;
   
    void Start()
    {
        Invoke("DestroyProjectile", lifeTime);
        Instantiate(projectileSound, transform.position, transform.rotation);
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector2.up * speed * Time.deltaTime);
    }

    void DestroyProjectile()
    {
        Instantiate(explosion, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Enemy")
        {
            collision.GetComponent<Enemy>().takeDamage(damage);
            DestroyProjectile();
        }

        if (collision.tag == "Boss")
        {
            collision.GetComponent<Boss>().takeDamage(damage);
            DestroyProjectile();
        }
    }


}
