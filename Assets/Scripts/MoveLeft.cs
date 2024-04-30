using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveLeft : MonoBehaviour
{
    [SerializeField] private float speed = 0.05f;
    private float maxSpeed = 0.05f;

    private Rigidbody2D projectileRb;
    private Vector2 direction = Vector2.left;
   
  
    private void Start()
    {
        projectileRb = GetComponent<Rigidbody2D>();
        projectileRb.velocity = direction * speed;
        
    }

    // Update is called once per frame
    void Update()
    {
        MoveProjectile();
    }

    public void MoveProjectile()
    {
        projectileRb.MovePosition(projectileRb.position + projectileRb.velocity);

        if (projectileRb.velocity.magnitude > maxSpeed)
        {
            projectileRb.velocity = Vector2.ClampMagnitude(projectileRb.velocity, maxSpeed);
        }
    }
   

}
