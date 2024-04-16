using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Passage : MonoBehaviour
{
    [SerializeField] private Transform connection;
    private void OnTriggerEnter2D(Collider2D other)
    {
        Vector3 position = other.transform.position; // who triggers and getting the position
        position.x = this.connection.position.x; //updating the position
        position.y = this.connection.position.y; //updating

        other.transform.position = position; //Teleporting
    }
}
