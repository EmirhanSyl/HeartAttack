using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dragger : MonoBehaviour
{
    Vector2 shootStart, shootEnd, shootDelta;
    float startTime, endTime, DeltaShootTime;
    Rigidbody2D _rigidbody;
    Vector2 difference;
    [SerializeField ]float speedV;
    [SerializeField] float speedT;

    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        _rigidbody.gravityScale = 0;
    }
    private void OnMouseDown()
    {
        startTime = Time.time;
        //Debug.Log(startTime);
        shootStart = Input.mousePosition;
        //Debug.Log(shootStart);
        _rigidbody.gravityScale = 1;

    }
    private void OnMouseDrag()
    {
        transform.position = (Vector2)Camera.main.ScreenToWorldPoint(Input.mousePosition); 
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
        _rigidbody.AddForce(shootDelta/ DeltaShootTime );
    }


}
