using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallMovement : MonoBehaviour
{
    //control ball speed
    public float movementSpeed;

    //increases ball speed after each bounce
    public float extraSpeedPerHit;

    //set speed limit
    public float maxExtraSpeed;

    //monitor speed by checking hits
    int hitCounter = 0;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(this.StartBall());
    }

    //reposition the ball after 5 rounds
    void PositionBall(bool isStartingPlayer1)
    {
        //reduce velocity of ball to 0
        this.GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0);
        //if its player1's turn, ball moves from center to left
        if (isStartingPlayer1)
        {
            this.gameObject.transform.localPosition = new Vector3(-100, 0, 0);
        }
        // if its player2's turn, ball moves from center to right
        else
        {
            this.gameObject.transform.localPosition = new Vector3(100, 0, 0);
        }
    }

    //default game starts with player1
    public IEnumerator StartBall(bool isStartingPlayer1 = true)
    {
        //restarting round
        this.PositionBall(isStartingPlayer1);

        //reset the counter
        this.hitCounter = 0;
        //counter is activated 2 secs after game restart
        yield return new WaitForSeconds(2);
        //if player1 starts, ball moves left
        if (isStartingPlayer1)
            this.MoveBall(new Vector2(-1, 0));
        else
        {
            //if player2 starts, ball moves right
            this.MoveBall(new Vector2(1, 0));
        }

    }

    //function for ball movement
    public void MoveBall(Vector2 direction)
    {
        //return vector with a magnitude of 1
        direction = direction.normalized;
        //function for speed increase
        float speed = this.movementSpeed + this.hitCounter * this.extraSpeedPerHit;
        //add force to the ball to execute speed
        Rigidbody2D rigidBody2D = this.gameObject.GetComponent<Rigidbody2D>();
        //influence direction
        rigidBody2D.velocity = direction * speed;
    }

    //function for increasing hit counter
    public void IncreaseHitCounter()
    {
        if(this.hitCounter * this.extraSpeedPerHit <= this.maxExtraSpeed)
        {
            this.hitCounter++;
        }
    }
}
