using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slime : MonoBehaviour
{
    GameObject hero;
    public float speed;
    public float health = 100;
    float lastHealth;
    bool dead;
    float timer;

    bool stop;
    float distance;
    float direction;

    Rigidbody2D rigHero;
    Animator animHero;
    SpriteRenderer srHero;
    [SerializeField] enemyGroundChecker checker;

    void Start()
    {
        hero = GameObject.FindGameObjectWithTag("Player");
        rigHero = GetComponent<Rigidbody2D>();
        animHero = GetComponent<Animator>();
        srHero = GetComponent<SpriteRenderer>();

        lastHealth = health;
    }

    void FixedUpdate()
    {
        if (!stop)
        {
            rigHero.velocity = new Vector2(speed * direction, 0f);
        }
        else
        {
            rigHero.velocity = Vector2.zero;
        }
    }

    void Update()
    {
        distance = gameObject.transform.position.x - hero.transform.position.x;
        stop = gameObject.transform.GetChild(0).gameObject.GetComponent<enemyGroundChecker>().stop; 

        if (distance > 3 && distance < 10)
        {
            srHero.flipX = false;
            gameObject.transform.GetChild(0).localScale = new Vector3(1, 1, 1);
            direction = -1;
            animHero.SetBool("Attack", false);
        }
        else if (distance < -3 && distance > -10)
        {
            srHero.flipX = true;
            gameObject.transform.GetChild(0).localScale = new Vector3(-1, 1, 1);
            direction = 1;
            animHero.SetBool("Attack", false);
        }
        else if (distance > -3 && distance < 3)
        {
            animHero.SetBool("Attack", true);
            direction = 0;
        }
        else
        {
            animHero.SetBool("Attack", false);
            direction = 0;
        }

        if (lastHealth != health)
        {
            animHero.SetTrigger("Hitted");
            lastHealth = health;
        }

        if (health <= 0)
        {
            animHero.SetTrigger("Dead");
            dead = true;
            Destroy(gameObject, 0.6f);
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player") && !dead)
        {
            timer += Time.deltaTime;
            if (timer >= 1f)
            {
                if (gameObject.CompareTag("Ghost"))
                {
                    animHero.SetTrigger("Attack");
                }
                collision.gameObject.GetComponent<HeroMove>().health -= 1;
                timer = 0;
            }
        }
    }

}
