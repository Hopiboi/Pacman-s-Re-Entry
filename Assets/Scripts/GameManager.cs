using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private GameObject[] ghost;
    [SerializeField] private GameObject[] pacman;
    [SerializeField] private Transform pellets;


    [SerializeField] public int score { get; private set;}
    [SerializeField] public int lives{ get; private set;}

    void Start()
    {
        
    }

    void Update()
    {
        
    }
}
