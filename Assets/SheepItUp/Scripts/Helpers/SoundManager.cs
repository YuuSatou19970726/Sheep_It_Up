using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static SoundManager instance;

    [SerializeField]
    private AudioSource gameStart, gameEnd, coinSound, jumpSound;

    void Awake()
    {
        MakeInstance();
    }

    public void GameStartSound()
    {
        gameStart.Play();
    }

    public void GameEndSound()
    {
        gameEnd.Play();
    }

    public void PickedUpCoin()
    {
        coinSound.Play();
    }

    public void JumpSound()
    {
        jumpSound.Play();
    }

    void MakeInstance()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
