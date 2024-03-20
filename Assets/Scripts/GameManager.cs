using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private Ghost[] ghost;
    [SerializeField] private Pacman pacman;
    [SerializeField] private Transform pellets;


    [SerializeField] public int score { get; private set;}
    [SerializeField] public int lives{ get; private set;}

    void Start()
    {
        NewGame();
    }

    private void NewGame()
    {
        SetScore(0);
        SetLives(3);
        NewRound();
    }

    //New round, starting the game or clearing all pellets
    private void NewRound()
    {
        foreach (Transform pellet in this.pellets)
        {
            pellet.gameObject.SetActive(true);
        }

        ResetState();
    }

    //losing lives only, therefore, resetting the state
    private void ResetState()
    {
        for (int i = 0; i < this.ghost.Length; i++)
        {
            this.ghost[i].gameObject.SetActive(true);
        }

        this.pacman.gameObject.SetActive(true);
    }

    private void SetScore(int score)
    {
        this.score = score;
    }

    private void SetLives(int lives)
    {
        this.lives = lives;
    }

}
