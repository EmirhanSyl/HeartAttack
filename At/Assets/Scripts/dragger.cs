using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dragger : MonoBehaviour
{
    Vector2 shootStart, shootEnd, shootDelta;
    float startTime, endTime, DeltaShootTime;
    Rigidbody2D _rigidbody;
    Collider2D coll;
    Vector2 difference;
    [SerializeField ]float speedV;
    [SerializeField] float speedT;
    public GameObject hero;

    [Space(20)]
    [Header("Kalp")]
    bool kalp;
    bool halfKalp;
    bool noneKalp;
    public bool kalpFree;


    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        _rigidbody.gravityScale = 0;
        coll = GetComponent<Collider2D>();
        coll.isTrigger = true;

        if(gameObject.CompareTag("Kalp") || gameObject.CompareTag("HalfKalp"))
        {
            kalp = true;
        }

    }
    private void OnMouseDown()
    {
        startTime = Time.time;
        //Debug.Log(startTime);
        shootStart = Input.mousePosition;
        //Debug.Log(shootStart);
        _rigidbody.gravityScale = 1;
        coll.isTrigger = false;

        if (kalp)
        {
            gameObject.GetComponent<Animator>().SetTrigger("Alive");
            gameObject.GetComponent<Animator>().SetBool("inHand", true);
            kalpFree = false;

            //hero.GetComponent<HeroMove>().health -= 1;
        }

    }
    private void OnMouseDrag()
    {
        transform.position = (Vector2)Camera.main.ScreenToWorldPoint(Input.mousePosition);

        if (kalp)
        {
            gameObject.GetComponent<Animator>().SetBool("inHand", true);
        }
    }
    private void OnMouseUp()
    {
        endTime = Time.time;
        //Debug.Log(endTime);
        DeltaShootTime = Mathf.Abs(endTime - startTime)*speedT;
        //Debug.Log(DeltaShootTime);
        shootEnd = Input.mousePosition;
        //Debug.Log(shootDelta);
        shootDelta = (shootEnd - shootStart)*speedV;
        _rigidbody.AddForce(shootDelta/ DeltaShootTime);

        if(kalp)
        {
            gameObject.GetComponent<Animator>().SetBool("inHand", false);
            kalpFree = true;
        }
    }


}
