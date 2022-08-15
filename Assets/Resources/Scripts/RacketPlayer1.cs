using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RacketPlayer1 : MonoBehaviour
{
    //speed of player1 racket
    public float movementSpeed;

    private void FixedUpdate()
    {
        //check whether user pressed movement keys
        float v = Input.GetAxisRaw("Vertical");
        //change speed of player1 racket
        GetComponent<Rigidbody2D>().velocity = new Vector2(0, v) * movementSpeed;
    }

}
