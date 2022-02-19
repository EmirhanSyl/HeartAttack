using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shettering : MonoBehaviour
{
    Vector2 objectSpeed;
    Vector2 lastLoc;
    Rigidbody2D rigObject;
    [SerializeField] float maxSpeed;

    public GameObject ShetteredObject;
    float lastSpeed;
    bool crash;

    void Start()
    {
        rigObject = GetComponent<Rigidbody2D>();
        //InvokeRepeating("GetObjectSpeed()", 1, 0.2f);
    }

    
    void Update()
    {
        GetObjectSpeed();
        Debug.Log(objectSpeed.magnitude);
        if (!crash)
        {
            lastSpeed = objectSpeed.magnitude;
            lastLoc = gameObject.transform.position;
        }

    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        crash = true;
        if(lastSpeed > maxSpeed)
        {
            Instantiate(ShetteredObject);
            ShetteredObject.transform.Translate(lastLoc);
            Destroy(gameObject);
        }
        else
        {
            crash = false;
        }

    }

    public void GetObjectSpeed()
    {
        objectSpeed = rigObject.velocity;
    }
}
