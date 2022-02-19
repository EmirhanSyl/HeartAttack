using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public float health = 100f;
    public float lastHealth;
    public float speed = 5f;

    bool stopMovement;

    Rigidbody2D rigHero;
    Animator animHero;
    SpriteRenderer srHero;

    void Start()
    {
        rigHero = GetComponent<Rigidbody2D>();
        animHero = GetComponent<Animator>();
        srHero = GetComponent<SpriteRenderer>();

        lastHealth = health;
    }

    void FixedUpdate()
    {
        if(!stopMovement)
        {
            //rigHero.velocity = new Vector2(speed * Input.GetAxis("Horizontal"), 0f);
        }

    }

    void Update()
    {
        
        if(lastHealth != health)
        {
            animHero.SetTrigger("Hit");
            lastHealth = health;

        }
        //if(Input.GetMouseButtonDown(0))
        //{
        //    health -= 5;
        //}
        if (health <= 0)
        {
            animHero.SetTrigger("Dead");
            Destroy(gameObject, 2);
        }



        //if (Input.GetAxis("Horizontal") >= 0.05f)
        //{
        //    srHero.flipX = false;
        //    animHero.SetFloat("Speed", Input.GetAxis("Horizontal"));
        //}
        //else if (Input.GetAxis("Horizontal") <= 0.05f)
        //{
        //    srHero.flipX = true;
        //    animHero.SetFloat("Speed", Input.GetAxis("Horizontal") * -1);
        //}
        //else
        //{
        //    animHero.SetFloat("Speed", 0f);
        //}



        //if(Input.GetKey(KeyCode.W))
        //{
        //    ShieldUp();
        //    animHero.SetBool("ShieldUp", true);
        //    stopMovement = true;
        //}
        //else if(Input.GetKeyDown(KeyCode.Space))
        //{
        //    Attack();
        //    animHero.SetTrigger("Attack");
        //    animHero.SetBool("ShieldUp", false);
        //}
        //else
        //{
        //    animHero.SetBool("ShieldUp", false);
        //}



        if(animHero.GetBool("ShieldUp"))
        {
            stopMovement = true;
        }
        else
        {
            stopMovement = false;
        }
        
    }

    void ShieldUp()
    {

    }

    void Attack()
    {

    }

}
