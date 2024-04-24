using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ghost : MonoBehaviour
{
    public int points = 200;
    public Movement movement { get; private set; }
    public GhostSpawn spawn { get; private set; }
    public GhostScatter scatter { get; private set; }
    public GhostChase chase { get; private set; }
    public GhostFrightened frightened { get; private set; }

    public GhostBehavior initialBehavior;
    public Transform target;

    private void Awake()
    {
        this.movement = GetComponent<Movement>();
        this.spawn = GetComponent<GhostSpawn>();
        this.scatter = GetComponent<GhostScatter>();
        this.chase = GetComponent<GhostChase>();
        this.frightened = GetComponent<GhostFrightened>();
    }

    private void Start()
    {
        ResetState();
    }

    public void ResetState()
    {
        this.gameObject.SetActive(true);
        this.movement.ResetState();

        this.frightened.Disable();
        this.chase.Disable();
        this.scatter.Enable();

        if(this.spawn != this.initialBehavior)
        {
            this.spawn.Disable();
        }

        if(this.initialBehavior != null)
        {
            this.initialBehavior.Enable();
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.layer == LayerMask.NameToLayer("Pacman"))
        {
            if (this.frightened.enabled)
            {
                FindAnyObjectByType<GameManager>().GhostEaten(this); // not efficient, should call gamemanager and just reference it
            }
            else
            {
                FindAnyObjectByType<GameManager>().PacmanEaten();
            }
        }
    }
}
