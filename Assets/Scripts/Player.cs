using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Player : MonoBehaviour
{
    public float speed;
    public int health;

    private Rigidbody2D _rigidBody;
    private Vector2 _movementAmount;
    private Animator _animator;

    public Image[] hearts;
    public Sprite fullHeartUI;
    public Sprite emptyHeartUI;


    private void Awake()
    {
        _rigidBody = GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator>();
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 moveInput = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        _movementAmount = moveInput.normalized * speed;

        if(moveInput != Vector2.zero)
        {
            _animator.SetBool("isRunning", true);
        }
        else
        {
            _animator.SetBool("isRunning", false);
        }

       
    }

    private void FixedUpdate()
    {
        _rigidBody.MovePosition(_rigidBody.position + _movementAmount * Time.fixedDeltaTime);
    }

    public void takeDamage(int damageAmount)
    {
        health -= damageAmount;
        UpdateHealthUI(health);
        if (health <= 0)
        {
            Debug.Log("wasted");
            Destroy(gameObject);
        }
    }

    public void ChangeWeapon(Weapon weaponToEquip)
    {
        Destroy(GameObject.FindGameObjectWithTag("Weapon"));
        Instantiate(weaponToEquip, transform.position, transform.rotation, transform);

    }

    public void UpdateHealthUI(int currentHealth)
    {
        for(int i = 0;i < hearts.Length; i++)
        {
            if(i < currentHealth)
            {
                hearts[i].sprite = fullHeartUI;
            }
            else
            {
                hearts[i].sprite = emptyHeartUI;
            }
        }

    }

    public void Heal(int healthAmount)
    {
        if(health + healthAmount > 5)
        {
            health = 5;
        }
        else
        {
            health += healthAmount;
        }
        UpdateHealthUI(health);
    }
}
