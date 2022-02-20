using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeroMove : MonoBehaviour
{
    public float health = 6;
    public float lastHealth;
    public float speed = 5f;
    public float jumpForce = 50f;

    bool stopMovement;
    bool jump;

    Rigidbody2D rigHero;
    Animator animHero;
    SpriteRenderer srHero;
    GroundCheck checker;

    public GameObject CheckObject;
    public GameObject hitDetecterObject;

    void Start()
    {
        rigHero = GetComponent<Rigidbody2D>();
        animHero = GetComponent<Animator>();
        srHero = GetComponent<SpriteRenderer>();
        checker = CheckObject.GetComponent<GroundCheck>();

        lastHealth = health;
    }

    void FixedUpdate()
    {
        if (!stopMovement)
        {
            rigHero.velocity = new Vector2(speed * Input.GetAxis("Horizontal"), rigHero.velocity.y);
        }
    }
    
    void Update()
    {
        if (lastHealth != health)
        {
            lastHealth = health;
        }
        if (health <= 0)
        {
            Destroy(gameObject, 2);
        }



        if (Input.GetAxis("Horizontal") >= 0.05f)
        {
            srHero.flipX = false;
            animHero.SetFloat("Speed", Input.GetAxis("Horizontal"));
        }
        else if (Input.GetAxis("Horizontal") <= 0.05f)
        {
            srHero.flipX = true;
            animHero.SetFloat("Speed", Input.GetAxis("Horizontal") * -1);
        }
        else
        {
            animHero.SetFloat("Speed", 0f);
        }



        if (Input.GetKey(KeyCode.W) && checker.isGrounded)
        {
            rigHero.velocity = new Vector2(rigHero.velocity.x, jumpForce);
            jump = true;
            animHero.SetBool("Jump", true);
        }
        else if (Input.GetKeyDown(KeyCode.Space))
        {
            StartCoroutine(Attack());
            animHero.SetTrigger("Attack");
            animHero.SetBool("Jump", false);
        }
        else
        {
            animHero.SetBool("Jump", false);
        }

    }

    IEnumerator Attack()
    {
        if(animHero.GetCurrentAnimatorStateInfo(0).IsName("Attack"))
        {

        }
        hitDetecterObject.SetActive(true);

        if (srHero.flipX)
        {
            hitDetecterObject.transform.localScale = new Vector3(-1, 1, 1);
        }
        else
        {
            hitDetecterObject.transform.localScale = new Vector3(1, 1, 1);
        }

        yield return new WaitForSeconds(0.5f);
        hitDetecterObject.SetActive(false);
    }

}
