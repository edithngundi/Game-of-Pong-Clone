using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ScoreController : MonoBehaviour
{
    //variables for player scores
    private int scorePlayer1 = 0;
    private int scorePlayer2 = 0;

    //unity text display for scores
    public GameObject scoreTextPlayer1;
    public GameObject scoreTextPlayer2;

    //set goal limit for win
    public int goalToWin;

    // Update is called once per frame
    void Update()
    {
        //check if one of the players has won
        if (this.scorePlayer1 >= this.goalToWin || this.scorePlayer2 >= this.goalToWin)
        {
            Debug.Log("Game Won");
            //displays game over scene when one player wins
            SceneManager.LoadScene("Game Over");
        }
    }

    //Update the UI
    private void FixedUpdate()
    {
        //displays player1 scores
        Text uiScorePlayer1 = this.scoreTextPlayer1.GetComponent<Text>();
        uiScorePlayer1.text = this.scorePlayer1.ToString();

        //displays player2 scores
        Text uiScorePlayer2 = this.scoreTextPlayer2.GetComponent<Text>();
        uiScorePlayer2.text = this.scorePlayer2.ToString();
    }

    //increases scores for player1
    public void GoalPlayer1()
    {
        this.scorePlayer1++;
    }

    //increases scores for player2
    public void GoalPlayer2()
    {
        this.scorePlayer2++;
    }
}
