using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private Ghost[] ghost;
    [SerializeField] private Pacman pacman;
    [SerializeField] private Transform pellets;


    [SerializeField] public int score{ get; private set;}
    [SerializeField] public int lives{ get; private set;}

    void Start()
    {
        NewGame();
    }

    private void Update()
    {
        if (this.lives <= 0 && Input.anyKeyDown)
        {
            NewRound();
        }
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

    private void GameOver()
    {
        for (int i = 0; i < this.ghost.Length; i++)
        {
            this.ghost[i].gameObject.SetActive(false);
        }

        this.pacman.gameObject.SetActive(false);
    }

    //current score
    private void SetScore(int score)
    {
        this.score = score;
    }

    private void SetLives(int lives)
    {
        this.lives = lives;
    }

    //ghost was eaten by pacman
    public void GhostEaten(Ghost ghost)
    {
        SetScore(this.score + ghost.points); //current score + amount
    }

    //pacman got eaten by the ghost
    public void PacmanEaten()
    {
        this.pacman.gameObject.SetActive(false);

        SetLives(this.lives - 1);

        if(this.lives > 0)
        {
            // when condition met, name of a function, then will call the function after time passes
            Invoke(nameof(ResetState), 4f);
            ResetState();
        }
        else
        {
            GameOver();
        }

    }

}
