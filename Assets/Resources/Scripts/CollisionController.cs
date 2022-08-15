using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionController : MonoBehaviour
{
    public BallMovement ballMovement;
    //monitor collision with walls and count scores
    public ScoreController scoreController;

    //method for bounce
    void BounceFromRacket(Collision2D c)
    {
        //ball position
        Vector3 ballPosition = this.transform.position;
        //racket position
        Vector3 racketPosition = c.gameObject.transform.position;
        //racket height
        float racketHeight = c.collider.bounds.size.y;
        //player1 racket bounces off to the right and of player2 to the left
        float x;
        if (c.gameObject.name == "RacketPlayer1")
        {
            x = 1;
        }
        else
        {
            x = -1;
        }
        //create vector2
        float y = (ballPosition.y - racketPosition.y) / racketHeight;
        this.ballMovement.IncreaseHitCounter();
        this.ballMovement.MoveBall(new Vector2(x, y));
    }
    //introduce correct and incorrect player movement
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name == "RacketPlayer1" || collision.gameObject.name == "RacketPlayer2") 
        {
            this.BounceFromRacket(collision);
        }
        else if (collision.gameObject.name == "LeftWall")
        {
            Debug.Log("Collision with LeftWall");
            //player2 gets a point if leftwall is hit
            this.scoreController.GoalPlayer2();
            //ball starts on the left hand side in new round
            StartCoroutine(this.ballMovement.StartBall(true));
        }
        else if (collision.gameObject.name == "RightWall")
        {
            Debug.Log("Collision with RightWall");
            //player1 gets a point if the rightwall is hit
            this.scoreController.GoalPlayer1();
            //ball starts on the right hand side in new round
            StartCoroutine(this.ballMovement.StartBall(false));
        }
    }
}
