using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class ItemManager : MonoBehaviour
{
    Rigidbody2D rb;

    Vector3 startPos;
    Vector3 endPos;
    [HideInInspector] public int scoreValue;
    [SerializeField] float speed = 0.5f;

    [SerializeField] bool hasBeenPlaced = false;
    public bool HasBeenPlaced
    {
        get { return hasBeenPlaced; }
        set
        {
            hasBeenPlaced = value;
            if (value)
            {
                Score.instance.AddScore(scoreValue);
            }
        }
    }

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    public void Init(Vector3 _startPos, Vector3 _endPos, int _scoreValue)
    {
        startPos = _startPos;
        endPos = _endPos;
        scoreValue = _scoreValue;
    }

    void Update()
    {
        Move();
    }

    void Move()
    {
        if (!rb.simulated)
        {
            transform.position = Vector3.MoveTowards(transform.position, endPos, speed * Time.deltaTime);
            if (transform.position == endPos)
            {
                Destroy(gameObject);
            }
        }
    }

    public void Drop()
    {
        rb.simulated = true;
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        ItemManager itemManager = other.gameObject.GetComponent<ItemManager>();
        if (itemManager != null && !itemManager.HasBeenPlaced)
        {
            itemManager.HasBeenPlaced = true;
        }
    }
}
