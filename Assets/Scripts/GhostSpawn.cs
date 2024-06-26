using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GhostSpawn : GhostBehavior
{
    [SerializeField] public Transform insideTransform;
    [SerializeField] private Transform outsideTransform;

    private void OnEnable()
    {
        StopAllCoroutines();
    }

    private void OnDisable()
    {
        if(this.gameObject.activeSelf)
        {
            StartCoroutine(ExitTransition());
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(this.enabled && collision.gameObject.layer == LayerMask.NameToLayer("Obstacle"))
        {
            this.ghost.movement.SetDirection(-this.ghost.movement.direction);
        }
    }

    private IEnumerator ExitTransition()
    {
        this.ghost.movement.SetDirection(Vector2.up, true);
        this.ghost.movement.rg2D.isKinematic = true;
        this.ghost.movement.enabled = false;

        Vector3 position = this.transform.position;

        float duration = 0.5f;
        float elapsed = 0f;

        // Animation of Ghost going inside(Center)
        while (elapsed < duration)
        {
            Vector3 newPosition = Vector3.Lerp(position, this.insideTransform.position, elapsed/duration);
            newPosition.z = position.z;
            this.ghost.transform.position = newPosition;
            elapsed += Time.deltaTime;
            yield return null;
        }

        elapsed = 0f;

        // Animation of Ghost going Outside Via Inside
        while (elapsed < duration)
        {
            Vector3 newPosition = Vector3.Lerp(this.insideTransform.position, this.outsideTransform.position, elapsed / duration);
            newPosition.z = position.z;
            this.ghost.transform.position = newPosition;
            elapsed += Time.deltaTime;
            yield return null;
        }

        this.ghost.movement.SetDirection(new Vector2(Random.value <  0.5f ? -1f:1f, 0f), true);
        this.ghost.movement.rg2D.isKinematic = false;
        this.ghost.movement.enabled = true;
    }
}
