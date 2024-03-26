using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))] // automatically adding this component

public class AnimationScript : MonoBehaviour
{
    public SpriteRenderer spr { get; private set; }

    [SerializeField] private Sprite[] sprite;
    [SerializeField] private bool looping = true;
    [SerializeField] private float animationTime = .25f;
    [SerializeField] public int animationFrame { get; private set; }

    private void Awake()
    {
        spr = GetComponent<SpriteRenderer>();    
    }

    private void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
