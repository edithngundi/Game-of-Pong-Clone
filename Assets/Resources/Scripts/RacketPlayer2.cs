using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RacketPlayer2 : MonoBehaviour
{
    //speed of player2 racket
    public float movementSpeed;

    private void FixedUpdate()
    {
        //check whether user pressed movement keys
        float v = Input.GetAxisRaw("Vertical2");
        //change speed of player1 racket
        GetComponent<Rigidbody2D>().velocity = new Vector2(0, v) * movementSpeed;
    }

}
