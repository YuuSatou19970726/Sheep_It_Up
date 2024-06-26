using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    private Transform player;

    private float damping = 2f;
    private float height = 10f;

    private Vector3 startPos;

    private bool can_Follow;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindWithTag(Tags.PLAYER_TAG).transform;
        startPos = transform.position;
        can_Follow = true;
    }

    // Update is called once per frame
    void Update()
    {
        Follow();
    }

    void Follow()
    {
        if (can_Follow)
        {
            transform.position = Vector3.Lerp(transform.position, new Vector3(player.position.x + 10, player.position.y + height, player.position.z - 10f), Time.deltaTime * damping);
        }
    }

    public bool CanFollow
    {
        get { return can_Follow; }
        set { can_Follow = value; }
    }
}
