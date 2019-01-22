using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform : MonoBehaviour
{

    public GameObject platform;
    public float movementSpeed;
    public Transform currentPoint;
    public Transform[] points;
    public int pointSelect;

    void Start()
    {
        currentPoint = points[pointSelect];
    }

    void Update()
    {
        platform.transform.position = Vector3.MoveTowards(platform.transform.position, currentPoint.position, Time.deltaTime * movementSpeed);

        if (platform.transform.position == currentPoint.position)
        {
            pointSelect++;

            if (pointSelect == points.Length)
            {
                pointSelect = 0;
            }
            currentPoint = points[pointSelect];
        }
    }
}
