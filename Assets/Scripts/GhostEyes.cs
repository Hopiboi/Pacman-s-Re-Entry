using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GhostEyes : MonoBehaviour
{
    public SpriteRenderer spr { set; private get; }
    public Movement movement { set; private get; }

    public Sprite up;
    public Sprite down;
    public Sprite left;
    public Sprite right;

    private void Awake()
    {
        spr = GetComponent<SpriteRenderer>();
        movement = GetComponentInParent<Movement>();
    }

    private void Update()
    {
        if (this.movement.direction == Vector2.up)
        {
            spr.sprite = this.up;
        }
        else if (this.movement.direction == Vector2.down)
        {
            spr.sprite = this.down;
        }
        else if (this.movement.direction == Vector2.left)
        {
            spr.sprite = this.left;
        }
        else if (this.movement.direction == Vector2.right)
        {
            spr.sprite = this.right;
        }
    }
}
