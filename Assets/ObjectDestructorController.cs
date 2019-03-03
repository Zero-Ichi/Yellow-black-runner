using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectDestructorController : ObstacleController
{
    protected override void OnTriggerEnter2D(Collider2D collision)
    {
        Destroy(collision.gameObject);
        Debug.Log("Somthing is destory");
    }


}
