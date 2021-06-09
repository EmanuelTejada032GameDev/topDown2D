using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : MonoBehaviour
{

    private Player _playerScript;
    private Vector2 _targetPosition;

    public float speed;
    public int damage;
    void Start()
    {
        _playerScript = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
        _targetPosition = _playerScript.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (Vector2.Distance(transform.position, _targetPosition) > .1f )
        {
            transform.position = Vector2.MoveTowards(transform.position, _targetPosition, speed * Time.deltaTime);
            
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            _playerScript.takeDamage(damage);
            Destroy(gameObject);
        }
    }
}
