using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundController : MonoBehaviour
{
    public AudioSource wallSound;
    public AudioSource racketSound;

    //function for sounds on collision
    private void OnCollisionEnter2D(Collision2D collision)
    {
        //if the ball hits a racket, play racket sound
        if (collision.gameObject.name == "RacketPlayer1" || collision.gameObject.name == "RacketPlayer2")
        {
            this.racketSound.Play();
        }
        //if the ball hits anything else/walls, play wall sound
        else
        {
            this.wallSound.Play();
        }
    }
}
