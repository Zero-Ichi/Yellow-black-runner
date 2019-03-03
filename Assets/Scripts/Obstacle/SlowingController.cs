using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlowingController : ObstacleController
{
    [SerializeField]
    protected float slowdownTime = 5f;
    [SerializeField]
    protected float speedDivider = 2f;

    protected override void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            PlayerController player = collision.gameObject.GetComponent<PlayerController>();
            if (player != null)
            {
                GameManager.SlowDown(speedDivider, slowdownTime);
                this.Col.enabled = false;
            }
        }
    }
}
