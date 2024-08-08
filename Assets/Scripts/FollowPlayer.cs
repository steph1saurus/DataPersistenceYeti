using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    public Transform player;
    public Vector3 offset;

    void LateUpdate()
    {
        //the camera follows the player only after the player's position goes above 0
        if (player.position.y >= 0)
        {
            Vector3 position = transform.position;
            position.y = (player.position + offset).y; //I'd like to stop the camera position.y from going below 0
            transform.position = position;
        }
      
    }
}
