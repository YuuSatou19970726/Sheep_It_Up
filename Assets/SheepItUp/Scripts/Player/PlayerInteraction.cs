using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteraction : MonoBehaviour
{
    private Rigidbody myBody;
    private bool playerDied;
    private CameraFollow cameraFollow;

    void Awake()
    {
        myBody = GetComponent<Rigidbody>();
        cameraFollow = Camera.main.GetComponent<CameraFollow>();
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        PlayerDied();
    }

    void PlayerDied()
    {
        if (!playerDied)
        {
            if (myBody.velocity.sqrMagnitude > 60)
            {
                playerDied = true;
                cameraFollow.CanFollow = false;

                SoundManager.instance.GameEndSound();
                GameplayController.instance.RestartGame();
            }
        }
    }

    void OnTriggerEnter(Collider target)
    {
        if (target.tag == Tags.COIN)
        {
            SoundManager.instance.PickedUpCoin();
            GameplayController.instance.IncrementScore();

            target.gameObject.SetActive(false);
        }

        if (target.tag == Tags.SPIKE_TAG)
        {
            cameraFollow.CanFollow = false;
            gameObject.SetActive(false);

            SoundManager.instance.GameEndSound();
            GameplayController.instance.RestartGame();
        }
    }

    void OnCollisionEnter(Collision target)
    {
        if (target.gameObject.tag == Tags.END_PLATFORM_TAG)
        {
            SoundManager.instance.GameStartSound();
            GameplayController.instance.RestartGame();
        }
    }
}
