using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider2D))]
public abstract class ObstacleController : BaseController
{
    protected Collider2D Col{ get; set; }
    protected override void Awake()
    {
        base.Awake();
        Col = GetComponent<Collider2D>();
        if (Col != null)
        {
            Col.isTrigger = true;
        }
    }

    abstract protected void OnTriggerEnter2D(Collider2D collision);

}
