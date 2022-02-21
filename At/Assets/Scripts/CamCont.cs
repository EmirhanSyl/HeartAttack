using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamCont : MonoBehaviour
{
    public GameObject hero;
    Vector2 camPos;

    void Start()
    {
        
    }

    
    void Update()
    {

    }

    private void LateUpdate()
    {
        gameObject.transform.position = new Vector3(hero.transform.position.x, hero.transform.position.y, gameObject.transform.position.z);
    }
}
