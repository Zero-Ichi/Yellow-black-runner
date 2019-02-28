using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider2D))]
public abstract class ObstacleController : MonoBehaviour
{
    protected Collider2D collider { get; set; }
    private void Awake()
    {
        collider = GetComponent<Collider2D>();
        if (collider != null)
        {
            collider.isTrigger = true;
        }
    }
    // OnTriggerEnter2D est appelé quand le Collider2D other entre dans le déclencheur (moteur physique 2D uniquement)
    abstract protected void OnTriggerEnter2D(Collider2D collision);

}
