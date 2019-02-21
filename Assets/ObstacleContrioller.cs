using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleContrioller : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    // OnCollisionEnter2D est appelé quand ce collider2D/rigidbody2D commence à toucher un autre rigidbody2D/collider2D (moteur physique 2D uniquement)
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            PlayerController player = collision.gameObject.GetComponent<PlayerController>();
            if (player != null)
            {
                player.Dead(true);
            }
        }
        
    }


}
