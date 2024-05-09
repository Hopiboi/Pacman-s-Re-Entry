using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))] // automatically adding this component

public class AnimationScript : MonoBehaviour
{
    public SpriteRenderer spr { get; private set; }

    [SerializeField] private Sprite[] sprites;
    [SerializeField] private bool looping = true;
    [SerializeField] private float animationTime = .125f;
    [SerializeField] public int animationFrame { get; private set; }

    private void Awake()
    {
        spr = GetComponent<SpriteRenderer>();    
    }

    private void Start()
    {
        InvokeRepeating(nameof(Advance), this.animationTime, this.animationTime);
    }

    private void Advance()
    {

        if (!this.spr.enabled)
        {
            return;
        }


        this.animationFrame++;

        if (this.animationFrame >= this.sprites.Length && this.looping)
        {
            this.animationFrame = 0;
        }

        if (this.animationFrame >= 0 && this.animationFrame < this.sprites.Length)
        {
            this.spr.sprite = this.sprites[this.animationFrame];
        }
    }

    public void Restart()
    {
        this.animationFrame = -1;

        Advance();
    }
}
