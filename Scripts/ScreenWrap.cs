using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]//for objects with rigidbody 2D

public class ScreenWrap : MonoBehaviour
{

    [SerializeField] private Rigidbody2D myRigidbody; //object's rigid body
   
    void Start()
    {
        myRigidbody = GetComponent<Rigidbody2D>();
    }

  
    void Update()
    {
        Vector3 screenPos = Camera.main.WorldToScreenPoint(transform.position);  //get screen position of object in pixels

        float rightSideOfScreenInWorld = Camera.main.ScreenToWorldPoint(new Vector2(Screen.width, Screen.height)).x; //get right side of the screen in world units
        float leftSideOfScreenInWorld = Camera.main.ScreenToWorldPoint(new Vector2(0f, 0f)).x; //get left side of screen in world units

        //if player is moving through left side of screen
        if (screenPos.x <=0 && myRigidbody.velocity.x <0)
        {
            transform.position = new Vector2(rightSideOfScreenInWorld, transform.position.y);
        }
        //if player is moving through right side os screen
        else if (screenPos.x >=Screen.width && myRigidbody.velocity.x >0)

        {
            transform.position = new Vector2(leftSideOfScreenInWorld, transform.position.y);
        }
    }
}
