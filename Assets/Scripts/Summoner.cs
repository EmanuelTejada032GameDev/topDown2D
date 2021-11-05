using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Summoner : Enemy
{
    public float minX;
    public float maxX;
    public float minY;
    public float maxY;

    public float meleeAttackSpeed;
    public float meleeAttackrange;
    private float timer;
    

    private Vector2 _targetPosition;
    private Animator _animator;

    public float timeBetweenSummon;
    private float SummonTime;

    public Enemy minion;

    public override void Start()
    {
        base.Start();

        float randomX = Random.Range(minX, maxX);
        float randomY = Random.Range(minY, maxY);

        _targetPosition = new Vector2(randomX, randomY);
        _animator = GetComponent<Animator>();

    }

    private void Update()
    {
        
        if(player != null)
        {
            if(Vector2.Distance(transform.position, _targetPosition) > .5f)
            {
                transform.position = Vector2.MoveTowards(transform.position, _targetPosition, speed * Time.deltaTime);
                _animator.SetBool("isRunning", true);
            }
            else
            {
                _animator.SetBool("isRunning", false);
                if(Time.time >= SummonTime)
                {
                    SummonTime = Time.time + timeBetweenSummon;
                    _animator.SetTrigger("Summon");
                }
            }

            if (Vector2.Distance(transform.position, player.position) < meleeAttackrange)
            {
                if (Time.time >= timer)
                {
                    StartCoroutine(Attack());
                    timer = Time.time + timeBetweenAttacks;
                }
            }

        }
    }

    public void Summon()
    {
        if(player != null)
        {
            Instantiate(minion, transform.position, Quaternion.identity);
        }
    }

    IEnumerator Attack()
    {
        player.GetComponent<Player>().takeDamage(damage);

        Vector2 originalPosition = transform.position;
        Vector2 targetPosition = player.position;

        float percent = 0f;
        while (percent <= 1)
        {

            percent += Time.deltaTime * meleeAttackSpeed;
            float interpolation = (-Mathf.Pow(percent, 2) + percent) * 4;
            transform.position = Vector2.Lerp(originalPosition, targetPosition, interpolation);
            yield return null;

        }
    }

}
