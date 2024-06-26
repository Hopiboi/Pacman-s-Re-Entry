using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Ghost))]

public abstract class GhostBehavior : MonoBehaviour
{
    public Ghost ghost { get; private set; }
    [SerializeField] public float duration;

    private void Awake()
    {
        this.ghost = GetComponent<Ghost>();
        this.enabled = false;
    }

    public void Enable()
    {
        Enable(this.duration);

    }

    public virtual void Enable(float duration)
    {
        this.enabled = true;

        CancelInvoke(); // Reset
        Invoke(nameof(Disable), duration); //Disabling
    }

    public virtual void Disable()
    {
        this.enabled = false;

        CancelInvoke();
    }
}
