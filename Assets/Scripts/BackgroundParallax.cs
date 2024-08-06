using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundParallax : MonoBehaviour
{
    private float height; 
    private float startPos; //starting position of object

    public GameObject cam1; //camera
    public float parallaxEffect; //how much the background object will move when camera moves

    void Start()
    {
        startPos = transform.position.y; //start position of background plane
        height = GetComponent<SpriteRenderer>().bounds.size.y; //size of the background element

    }

    void Update()
    {
        float temp = (cam1.transform.position.y * (1 - parallaxEffect));
        float dist = (cam1.transform.position.y * parallaxEffect);

        //if it's moving up and down and how much

        transform.position = new Vector3(transform.position.x, startPos + dist, transform.position.z);

        if (temp> startPos + height)
        {
            startPos += height;
        }
        else if (temp < startPos - height)
        {
            startPos -= height;
        }
    }
}
