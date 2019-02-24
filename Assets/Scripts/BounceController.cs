using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BounceController : ObstacleController
{
    [SerializeField]
    protected float Bounciness = 10f;

    protected override void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            PlayerController player = collision.gameObject.GetComponent<PlayerController>();
            if (player != null)
                player.Jump(Bounciness);
        }
    }
}
