using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoMoveController : BaseController
{

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        transform.position += Vector3.left * GameManager.GetSpeed() * Time.deltaTime;
    }
}
