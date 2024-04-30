using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCamera : MonoBehaviour
{
    private float triggerAlt1 = 5.5f;
    private float triggerAlt2 = 15f;
    private float triggerAlt3 = 20.5f;



    public GameObject player;
    public List<GameObject> areas;

    private void Awake()
    {
        areas[0].SetActive(true);
        areas[1].SetActive(false);
        areas[2].SetActive(false);
    }

    //Alters camera position based on player's position and if it passes triggered altitude points
    //this allows the camera to follow the player "up" and "down" the map
    void Update()
    {
        if (player.transform.position.y >triggerAlt1 && player.transform.position.y < triggerAlt2)
        {
            Camera.main.transform.position = new Vector3(0, 10, -10);
            areas[0].SetActive(false);
            areas[1].SetActive(true);

        }
        else if (player.transform.position.y < triggerAlt1)
        {
            Camera.main.transform.position = new Vector3(0, 0, -10);
            areas[0].SetActive(true);
            areas[1].SetActive(false);

        }
        else if (player.transform.position.y >triggerAlt2 && player.transform.position.y < triggerAlt3)
        {
            Camera.main.transform.position = new Vector3(0, 20, -10);
            areas[0].SetActive(false);
            areas[1].SetActive(false);
            areas[2].SetActive(true);
        }
    }
}
