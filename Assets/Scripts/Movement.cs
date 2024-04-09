using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Movement : MonoBehaviour
{
    [Header("Speed Setting")]
    [SerializeField] private float speed = 8f;
    [SerializeField] private float speedMultiplier = 2f;

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
        ResetState();
    }

    private void Update()
    {
        if (this.nextDirection != Vector2.zero)
        {
            SetDirection(this.nextDirection);
        }
    }

    public void ResetState()
    {
        this.speedMultiplier = 1f;
        this.direction = this.initialDirection;
        this.nextDirection = Vector2.zero;
        this.transform.position = this.startingPosition;
        this.rg2D.isKinematic = false;
        this.enabled = true;
    }

    //FixedUpdate will always for movement/physics
    private void FixedUpdate()
    {
        Vector2 position = this.rg2D.position; // calculate position
        Vector2 translation = this.direction * this.speed * this.speedMultiplier * Time.fixedDeltaTime; //MovementSpeed and direction
        this.rg2D.MovePosition(position + translation); // new position
    }

    //where we want to move if we use pacman, input
    //can be used for ai of ghost
    public void SetDirection(Vector2 direction, bool forced = false) // shorcuts for the another script 
    {
        //not occupied // forcing direction to change
        if (!OccupiedTiles(direction) || forced)
        {
            this.direction = direction;
            this.nextDirection = Vector2.zero;
            Debug.Log(this.direction);
        }
        else // occupied
        {
            this.nextDirection = direction;
        }
    }

    //checking when colliding 
    public bool OccupiedTiles(Vector2 direction)
    {
        RaycastHit2D hit = Physics2D.BoxCast(this.transform.position, Vector2.one * .75f, 0f, direction, 1.5f, this.obstacleLayer);
        return hit.collider != null;
        
    }
}
