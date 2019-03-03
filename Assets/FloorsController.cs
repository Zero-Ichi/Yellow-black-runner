using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloorsController : MonoBehaviour {


    [SerializeField]
    protected float speed = 1;
	// Use this for initialization
	void Start () {
		
	}

    // Update is called once per frame
    void Update()
    {
        transform.position += Vector3.left * speed * Time.deltaTime;
    }
}
