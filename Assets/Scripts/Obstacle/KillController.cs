using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillController : ObstacleController
{
    protected override void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            PlayerController player = collision.gameObject.GetComponent<PlayerController>();
            if (player != null)
                player.Dead();
        }
    }
}
