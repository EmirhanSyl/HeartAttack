using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeroMove : MonoBehaviour
{
    public float health = 6;
    public float lastHealth;
    public float speed = 5f;
    public float jumpForce = 50f;

    float timer = 0;
    bool stopMovement;
    bool jump;
    

    Rigidbody2D rigHero;
    Animator animHero;
    SpriteRenderer srHero;
    GroundCheck checker;

    public GameObject CheckObject;
    public GameObject hitDetecterObject;
    public GameObject throwedSword;
    public GameObject instantietedThrowedSword;

    [Header("HealthChangeState")]
    public GameObject fullKalp;
    public GameObject halfKalp;
    public GameObject noneKalp;

    public Transform kalpHolder1;
    public Transform kalpHolder2;
    public Transform kalpHolder3;


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
        timer += Time.deltaTime;

        if (lastHealth != health)
        {
            ChangeHealthState();
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

        if(Input.GetKeyDown(KeyCode.F))
        {          
            if(timer > 10f)
            {
                instantietedThrowedSword = Instantiate(throwedSword, gameObject.transform.position, gameObject.transform.rotation);
                StartCoroutine(ThrowAttack());
                timer = 0;
            }
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

    IEnumerator ThrowAttack()
    {
        if(srHero.flipX)
        {
            instantietedThrowedSword.GetComponent<Rigidbody2D>().velocity = new Vector2(-15f, 0f);
            instantietedThrowedSword.GetComponent<SpriteRenderer>().flipX = true;
        }
        else
        {
            instantietedThrowedSword.GetComponent<Rigidbody2D>().velocity = new Vector2(15f, 0f);
            instantietedThrowedSword.GetComponent<SpriteRenderer>().flipX = false;
        }        
        yield return new WaitForSeconds(4f);
        Destroy(instantietedThrowedSword);
    }

    void ChangeHealthState()
    {
        switch(health)
        {
            case 6:
                
                break;
            case 5:

                if(!kalpHolder3.GetChild(0).gameObject.activeSelf)
                {
                    Destroy(kalpHolder3.GetChild(0).gameObject);
                    var newHeart00 = Instantiate(halfKalp, kalpHolder3.position, kalpHolder3.rotation);
                    newHeart00.transform.parent = kalpHolder3;
                }
                else if(!kalpHolder2.GetChild(0).gameObject.activeSelf)
                {
                    Destroy(kalpHolder2.GetChild(0).gameObject);
                    var newHeart02 = Instantiate(fullKalp, kalpHolder2.position, kalpHolder2.rotation);
                    newHeart02.transform.parent = kalpHolder2;

                    Destroy(kalpHolder3.GetChild(0).gameObject);
                    var newHeart01 = Instantiate(halfKalp, kalpHolder3.position, kalpHolder3.rotation);
                    newHeart01.transform.parent = kalpHolder3;
                }
                else if (!kalpHolder1.GetChild(0).gameObject.activeSelf)
                {
                    Destroy(kalpHolder1.GetChild(0).gameObject);
                    var newHeart03 = Instantiate(fullKalp, kalpHolder1.position, kalpHolder1.rotation);
                    newHeart03.transform.parent = kalpHolder1;

                    Destroy(kalpHolder3.GetChild(0).gameObject);
                    var newHeart01 = Instantiate(halfKalp, kalpHolder3.position, kalpHolder3.rotation);
                    newHeart01.transform.parent = kalpHolder3;
                }
                else
                {
                    var newHeart = Instantiate(halfKalp, kalpHolder3.GetChild(0).position, kalpHolder3.GetChild(0).rotation);
                    newHeart.transform.parent = kalpHolder3;
                    Destroy(kalpHolder3.GetChild(0).gameObject);
                }                
                break;


            case 4:
                if (!kalpHolder3.GetChild(0).gameObject.activeSelf)
                {
                    Destroy(kalpHolder3.GetChild(0).gameObject);
                    var newHeart00 = Instantiate(noneKalp, kalpHolder3.position, kalpHolder3.rotation);
                    newHeart00.transform.parent = kalpHolder3;
                }
                else if (!kalpHolder2.GetChild(0).gameObject.activeSelf)
                {
                    Destroy(kalpHolder2.GetChild(0).gameObject);
                    var newHeart02 = Instantiate(fullKalp, kalpHolder2.position, kalpHolder2.rotation);
                    newHeart02.transform.parent = kalpHolder2;

                    Destroy(kalpHolder3.GetChild(0).gameObject);
                    var newHeart01 = Instantiate(noneKalp, kalpHolder3.position, kalpHolder3.rotation);
                    newHeart01.transform.parent = kalpHolder3;
                }
                else if (!kalpHolder1.GetChild(0).gameObject.activeSelf)
                {
                    Destroy(kalpHolder1.GetChild(0).gameObject);
                    var newHeart03 = Instantiate(fullKalp, kalpHolder1.position, kalpHolder1.rotation);
                    newHeart03.transform.parent = kalpHolder1;

                    Destroy(kalpHolder3.GetChild(0).gameObject);
                    var newHeart01 = Instantiate(noneKalp, kalpHolder3.position, kalpHolder3.rotation);
                    newHeart01.transform.parent = kalpHolder3;
                }
                else
                {
                    var newHeart = Instantiate(noneKalp, kalpHolder3.GetChild(0).position, kalpHolder3.GetChild(0).rotation);
                    newHeart.transform.parent = kalpHolder3;
                    Destroy(kalpHolder3.GetChild(0).gameObject);
                }
                break;


            case 3:
                if (!kalpHolder3.GetChild(0).gameObject.activeSelf)
                {
                    Destroy(kalpHolder3.GetChild(0).gameObject);
                    var newHeart00 = Instantiate(noneKalp, kalpHolder3.position, kalpHolder3.rotation);
                    newHeart00.transform.parent = kalpHolder3;

                    Destroy(kalpHolder2.GetChild(0).gameObject);
                    var newHeart02 = Instantiate(halfKalp, kalpHolder2.position, kalpHolder2.rotation);
                    newHeart02.transform.parent = kalpHolder2;
                }
                else if (!kalpHolder2.GetChild(0).gameObject.activeSelf)
                {
                    Destroy(kalpHolder2.GetChild(0).gameObject);
                    var newHeart02 = Instantiate(halfKalp, kalpHolder2.position, kalpHolder2.rotation);
                    newHeart02.transform.parent = kalpHolder2;
                }
                else if (!kalpHolder1.GetChild(0).gameObject.activeSelf)
                {
                    Destroy(kalpHolder1.GetChild(0).gameObject);
                    var newHeart03 = Instantiate(fullKalp, kalpHolder1.position, kalpHolder1.rotation);
                    newHeart03.transform.parent = kalpHolder1;

                    Destroy(kalpHolder2.GetChild(0).gameObject);
                    var newHeart01 = Instantiate(halfKalp, kalpHolder3.position, kalpHolder3.rotation);
                    newHeart01.transform.parent = kalpHolder2;
                }
                else
                {
                    var newHeart = Instantiate(noneKalp, kalpHolder2.GetChild(0).position, kalpHolder2.GetChild(0).rotation);
                    newHeart.transform.parent = kalpHolder2;
                    Destroy(kalpHolder2.GetChild(0).gameObject);
                }
                break;


            case 2:
                if (!kalpHolder3.GetChild(0).gameObject.activeSelf)
                {
                    Destroy(kalpHolder3.GetChild(0).gameObject);
                    var newHeart00 = Instantiate(noneKalp, kalpHolder3.position, kalpHolder3.rotation);
                    newHeart00.transform.parent = kalpHolder3;

                    Destroy(kalpHolder2.GetChild(0).gameObject);
                    var newHeart02 = Instantiate(noneKalp, kalpHolder2.position, kalpHolder2.rotation);
                    newHeart02.transform.parent = kalpHolder2;
                }
                else if (!kalpHolder2.GetChild(0).gameObject.activeSelf)
                {
                    Destroy(kalpHolder2.GetChild(0).gameObject);
                    var newHeart02 = Instantiate(noneKalp, kalpHolder2.position, kalpHolder2.rotation);
                    newHeart02.transform.parent = kalpHolder2;
                }
                else if (!kalpHolder1.GetChild(0).gameObject.activeSelf)
                {
                    Destroy(kalpHolder1.GetChild(0).gameObject);
                    var newHeart03 = Instantiate(fullKalp, kalpHolder1.position, kalpHolder1.rotation);
                    newHeart03.transform.parent = kalpHolder1;

                    Destroy(kalpHolder2.GetChild(0).gameObject);
                    var newHeart01 = Instantiate(noneKalp, kalpHolder2.position, kalpHolder2.rotation);
                    newHeart01.transform.parent = kalpHolder2;
                }
                else
                {
                    var newHeart = Instantiate(noneKalp, kalpHolder2.GetChild(0).position, kalpHolder2.GetChild(0).rotation);
                    newHeart.transform.parent = kalpHolder2;
                    Destroy(kalpHolder2.GetChild(0).gameObject);
                }
                break;


            case 1:
                if (!kalpHolder3.GetChild(0).gameObject.activeSelf)
                {
                    Destroy(kalpHolder3.GetChild(0).gameObject);
                    var newHeart00 = Instantiate(noneKalp, kalpHolder3.position, kalpHolder3.rotation);
                    newHeart00.transform.parent = kalpHolder3;

                    Destroy(kalpHolder1.GetChild(0).gameObject);
                    var newHeart02 = Instantiate(halfKalp, kalpHolder1.position, kalpHolder1.rotation);
                    newHeart02.transform.parent = kalpHolder1;
                }
                else if (!kalpHolder2.GetChild(0).gameObject.activeSelf)
                {
                    Destroy(kalpHolder2.GetChild(0).gameObject);
                    var newHeart02 = Instantiate(noneKalp, kalpHolder2.position, kalpHolder2.rotation);
                    newHeart02.transform.parent = kalpHolder2;

                    Destroy(kalpHolder1.GetChild(0).gameObject);
                    var newHeart03 = Instantiate(halfKalp, kalpHolder1.position, kalpHolder1.rotation);
                    newHeart03.transform.parent = kalpHolder1;
                }
                else if (!kalpHolder1.GetChild(0).gameObject.activeSelf)
                {
                    Destroy(kalpHolder1.GetChild(0).gameObject);
                    var newHeart03 = Instantiate(noneKalp, kalpHolder1.position, kalpHolder1.rotation);
                    newHeart03.transform.parent = kalpHolder1;
                }
                else
                {
                    var newHeart = Instantiate(halfKalp, kalpHolder1.GetChild(0).position, kalpHolder1.GetChild(0).rotation);
                    newHeart.transform.parent = kalpHolder1;
                    Destroy(kalpHolder1.GetChild(0).gameObject);
                }
                break;
            case 0:
                //animHero.SetTrigger("Dead");
                Destroy(gameObject, 2f);
                break;
        }
    }

}
