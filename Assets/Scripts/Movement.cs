using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Movement : MonoBehaviour
{
    [Header("Speed Setting")]
    [SerializeField] private float speed = 8f;
    [SerializeField] private float speedMultiplier = 8f;

    [Header("Direction and Collision")]
    [SerializeField] private Vector2 initialDirection;
    [SerializeField] private LayerMask obstacleLayer;

    //[Header("Player Direction")]
    [SerializeField] public Vector2 direction { get; private set; }
    [SerializeField] public Vector2 nextDirection { get; private set; }
    [SerializeField] public Vector3 startingPosition { get; private set; }

    public Rigidbody2D rg2D { get; private set; }


    
    private void Awake()
    {
        rg2D = GetComponent<Rigidbody2D>();
        this.startingPosition = this.transform.position;
    }

    private void Start()
    {
        
    }


    void Update()
    {
        
    }
}
