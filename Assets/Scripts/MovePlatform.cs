using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePlatform : MonoBehaviour
{
    [SerializeField] Vector3[] distanceRange = new Vector3[2];
    [SerializeField] float speed = 0.5f;

    Vector3 currentPosition;
    [SerializeField] Vector3 targetPosition;

    void Start()
    {
        currentPosition = transform.position;
        targetPosition = distanceRange[1];
    }

    void Update()
    {
        Move();
    }

    void Move()
    {
        currentPosition = Vector3.MoveTowards(currentPosition, targetPosition, speed * Time.deltaTime);
        transform.position = currentPosition;

        if (currentPosition.x == distanceRange[1].x)
        {
            targetPosition = distanceRange[0];
        }
        else if (currentPosition.x == distanceRange[0].x)
        {
            targetPosition = distanceRange[1];
        }

    }

    void OnCollisionEnter2D(Collision2D other)
    {
        other.transform.parent = transform;
    }
}
