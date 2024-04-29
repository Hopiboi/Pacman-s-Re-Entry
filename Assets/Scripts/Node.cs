using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Node : MonoBehaviour
{
    [SerializeField] private LayerMask obstacleLayer;
    public List<Vector2> availableDirections { get; private set; }

    private void Start()
    {
        this.availableDirections =new List<Vector2>();

        CheckAvailableDirection(Vector2.up);
        CheckAvailableDirection(Vector2.down);
        CheckAvailableDirection(Vector2.left);
        CheckAvailableDirection(Vector2.right);

       
    }

    private void CheckAvailableDirection(Vector2 direction)
    {
        RaycastHit2D hit = Physics2D.BoxCast(this.transform.position, Vector2.one * .5f, 0f, direction, 1f, this.obstacleLayer);

        // no wall
        if (hit.collider == null)
        {
            this.availableDirections.Add(direction);
        }
    }
}
