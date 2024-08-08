using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    public GameObject cam;
    public Transform player;  //references the player's position
    private int offset = 2; //offsets the camera by a certain amount when following the player

    private Vector3 cameraStartPos;
    private Vector3 whereMyCameraIsLocated;

    private void Start()
    {
        cameraStartPos = new Vector3(0, 0, -10);
    }


    void LateUpdate()
    {
        //the camera follows the player only after the player's position goes above 0
        if (player.position.y >-1)
        {
            Vector3 position = cam.transform.position;
            whereMyCameraIsLocated = new Vector3(0,player.position.y + offset, -10);
            cam.transform.position = position;
        }

        else if (cam.transform.position.y <=0)
        {
            whereMyCameraIsLocated = cameraStartPos;
        }
    }
}