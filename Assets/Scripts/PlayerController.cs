using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    
    [SerializeField] private float speed = 20;
    [SerializeField] private float jumpForce = 35f;
    [SerializeField] private float gravityModifier = 2f;
    [SerializeField] private float horizontalInput;

    private Rigidbody2D playerRb;//Player's rigidbody
    private float maxSpeed =20;//Maxspeed allowed
   
    public bool onGround = true;

    [Header("PlayerControls")]
    private PlayerControls playerControls; //reference to player controls


    private void Awake()
    {
        //Player's rigid body and physics
        playerRb = GetComponent<Rigidbody2D>();
        Physics.gravity *= gravityModifier;

        playerControls = new PlayerControls(); //instantiate the player controls

    }

    private void OnEnable() //enable action map in order to read from it
    {
        playerControls.Enable();
    }

    private void OnDisable()
    {
        playerControls.Disable();
    }

    private void Start()
    {
            
    }

    void Update()
    {
        float move = playerControls.Default.Move.ReadValue<float>();
        Debug.Log(move);

        playerControls.Default.Jump.ReadValue<float>();
        if (playerControls.Default.Jump.ReadValue<float>() == 1)
        {
            Debug.Log("Jump");
        }

        horizontalInput = move;
        

        playerRb.AddForce(transform.right * speed * horizontalInput);

        if (playerRb.velocity.magnitude > maxSpeed) //stops the player from accelerating endlessley
        {
            playerRb.velocity = Vector2.ClampMagnitude(playerRb.velocity, maxSpeed);
        }

        if ((playerControls.Default.Jump.ReadValue<float>() == 1) && onGround)
        
        {
            playerRb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
            onGround = false;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Floor"))
        {
            onGround = true;
        }
        else if (collision.gameObject.CompareTag("Platform"))
        {
            onGround = true;
        }

        else if (collision.gameObject.CompareTag("Projectile"))
        {
            onGround = true;
        }
    }

   

}
