using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GhostChase : GhostBehavior
{
    private void OnDisable()
    {
        this.ghost.scatter.Enable();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        Node node = other.GetComponent<Node>();

        if (node != null && this.enabled && !this.ghost.frightened.enabled) //we have node , it is enabled, and not frightened
        {

            Vector2 direction = Vector2.zero; // Starting point to find pacman using 0,0
            float minDistance = float.MaxValue; // distance to pacman

            //Looping
            foreach (Vector2 availableDirection in node.availableDirections)
            {
                Vector3 newPosition = this.transform.position + new Vector3(availableDirection.x, availableDirection.y, 0f); // ghost position + new position
                float distance = (this.ghost.target.position - newPosition).sqrMagnitude; // ghost position - pacman position = distance needed // optimizing the route

                // Direction to bring closer to pacman than before
                if (minDistance > distance)
                {
                    direction = availableDirection; //Current Direction to Best Direction
                    minDistance = distance; //Update the distance
                }
            }

            this.ghost.movement.SetDirection(direction); // the ghost will move to pacman and chase it

        }
    }
}
