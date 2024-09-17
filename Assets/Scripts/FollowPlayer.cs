using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    public Transform player;  // Reference to the player's position
    public float offset = 2f; // Offset to add to the player's position
    public float smoothSpeed = 0.125f; // Speed at which the camera smooths its movement

    private Vector3 cameraStartPos;

    private void Start()
    {
        // Set the camera's starting position
        cameraStartPos = new Vector3(0, 0, -10);
    }

    void LateUpdate()
    {
        // Only follow the player if their position is above a certain threshold (-1)
        if (player.position.y > -1)
        {
            Vector3 desiredPosition = new Vector3(0, player.position.y + offset, -10);
            Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed); // Smooth the camera's movement
            transform.position = smoothedPosition;
        }
        else
        {
            // Return to the starting position when the player is below the threshold
            Vector3 smoothedPosition = Vector3.Lerp(transform.position, cameraStartPos, smoothSpeed);
            transform.position = smoothedPosition;
        }
    }
}
