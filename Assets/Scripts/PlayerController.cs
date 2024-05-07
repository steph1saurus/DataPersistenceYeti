using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{

    [Header ("Player Movement Modifiers")]
    [SerializeField] float speed = 20;
    [SerializeField] float jumpForce = 35f;
    [SerializeField] float gravityModifier = 2f;
    [SerializeField] float horizontalInput;

    private Rigidbody2D playerRb;//Player's rigidbody
    private float maxSpeed =20;//Maxspeed allowed
   
    public bool onGround = true;

    [Header("Player Controls")]
    private InputAction moveAction;
    private InputAction jumpAction;

    [Header("Audio")]
    [SerializeField] AudioSource playerAudio;
    [SerializeField] AudioClip jumpSound;


    private void Awake()
    {
        //Player's rigid body and physics
        playerRb = GetComponent<Rigidbody2D>();
        Physics.gravity *= gravityModifier;

        // Find input actions by name
        var playerControlsAsset = Resources.Load<InputActionAsset>("PlayerControls");
        moveAction = playerControlsAsset.FindAction("Move");
        jumpAction = playerControlsAsset.FindAction("Jump");

        // Enable the input actions
        moveAction.Enable();
        jumpAction.Enable();

    }

    private void OnDisable()
    {
        // Disable the input actions when the script is disabled
        moveAction.Disable();
        jumpAction.Disable();
    }

    void Update()
    {
        //read move input value
        horizontalInput = moveAction.ReadValue<float>();

        // Move the player horizontally
        playerRb.AddForce(Vector2.right * speed * horizontalInput);

        if (playerRb.velocity.magnitude > maxSpeed) //stops the player from accelerating endlessley
        {
            playerRb.velocity = Vector2.ClampMagnitude(playerRb.velocity, maxSpeed);
        }

        if (jumpAction.triggered && onGround)
        {
            playerRb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
            onGround = false;
            playerAudio.PlayOneShot(jumpSound);


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
