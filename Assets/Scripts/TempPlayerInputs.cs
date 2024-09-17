using UnityEngine;

public class TempPlayerInputs : MonoBehaviour
{
    [Header("Player Movement Modifiers")]
    [SerializeField] float speed = 20;
    [SerializeField] float jumpForce = 35f;
    [SerializeField] float gravityModifier = 2f;
    [SerializeField] float horizontalInput;

    private Rigidbody2D playerRb;//Player's rigidbody
    private float maxSpeed = 20;//Maxspeed allowed

    public bool onGround = true;


    [Header("Audio")]
    [SerializeField] AudioSource playerAudio;
    [SerializeField] AudioClip jumpSound;


    // Start is called before the first frame update
    void Start()
    {
        //Player's rigid body and physics
        playerRb = GetComponent<Rigidbody2D>();
        Physics.gravity *= gravityModifier;

    }

    // Update is called once per frame
    void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        // Move the player horizontally
        playerRb.AddForce(Vector2.right * speed * horizontalInput);

        if (playerRb.velocity.magnitude > maxSpeed) //stops the player from accelerating endlessley
        {
            playerRb.velocity = Vector2.ClampMagnitude(playerRb.velocity, maxSpeed);
        }

        if (Input.GetKeyDown(KeyCode.Space) && onGround)
        {
            playerRb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
            onGround = false;
            playerAudio.PlayOneShot(jumpSound);


        }

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Floor"))
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
