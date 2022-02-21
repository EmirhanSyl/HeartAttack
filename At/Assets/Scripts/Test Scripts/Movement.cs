using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public float health = 100f;
    public float lastHealth;
    public float speed = 5f;
    [SerializeField]float Distace;
    int direction;

    bool stopMovement;
    public GameObject hero;

    Rigidbody2D rigHero;
    Animator animHero;
    SpriteRenderer srHero;
    [SerializeField] enemyGroundChecker checker; 
    void Start()
    {
        rigHero = GetComponent<Rigidbody2D>();
        animHero = GetComponent<Animator>();
        srHero = GetComponent<SpriteRenderer>();
        hero = GameObject.FindGameObjectWithTag("Player");
        
        lastHealth = health;
    }

    void FixedUpdate()
    {
        if(!checker.stop)
        {
            rigHero.velocity = new Vector2(speed * direction, 0f);
        }
        else
        {
            animHero.SetFloat("Speed", 0);
        }
        Distace = gameObject.transform.position.x - hero.transform.position.x;

    }

    void Update()
    {
        
        if(lastHealth != health)
        {
            animHero.SetTrigger("Hit");
            lastHealth = health;

        }

        if (health <= 0)
        {
            animHero.SetTrigger("Dead");
            Destroy(gameObject, 2);
        }


        if(animHero.GetBool("ShieldUp"))
        {
            stopMovement = true;
        }
        else
        {
            stopMovement = false;
        }
        
        if(Distace > 3 && Distace < 10)
        {
            srHero.flipX = true;
            gameObject.transform.GetChild(0).localScale = new Vector3(-1, 1, 1);
            direction = -1;
            animHero.SetBool("Attack", false);
            animHero.SetFloat("Speed", -direction);
        }        
        else if(Distace < -3 && Distace > -10)
        {
            srHero.flipX = false;
            gameObject.transform.GetChild(0).localScale = new Vector3(1, 1, 1);
            direction = 1;
            animHero.SetBool("Attack", false);
            animHero.SetFloat("Speed", direction);
        }
        else if(Distace > -3 && Distace < 3)
        {
            animHero.SetBool("Attack", true);
            direction = 0;
            animHero.SetFloat("Speed", direction);
        }
        else
        {
            direction = 0;
            animHero.SetBool("Attack", false);
            animHero.SetFloat("Speed", 0);
        }

    }

    void ShieldUp()
    {

    }

    void Attack()
    {

    }

}
