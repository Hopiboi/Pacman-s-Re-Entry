using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Passage : MonoBehaviour
{
    [SerializeField] private Transform connection;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Vector3 position = collision.transform.position;
        position.x = this.connection.position.x; //this object position
        position.y = this.connection.position.y; //this object position

        collision.transform.position = position; //Moving the object on that position
    }
}
