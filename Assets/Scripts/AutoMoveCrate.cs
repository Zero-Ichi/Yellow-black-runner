using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoMoveCrate : PhysicsObject {

    protected override void ComputeVelocity()
    {
    }

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        this.TargetVelocity = Vector2.left;
	}
}
