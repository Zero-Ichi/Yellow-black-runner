using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    [SerializeField]
    protected float runningSpeed = 10;

    [SerializeField]
    protected float dropSpeed = -3;



    protected Rigidbody2D rig;
	// Use this for initialization
	void Start () {
        rig = GetComponent<Rigidbody2D>();
	}

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.Space))
        {
            //rig.AddForce(new Vector2(10, 0), ForceMode2D.Force);
            rig.velocity += 10 * Vector2.up;
            //rig.AddForce(new Vector2(0,10), ForceMode2D.Impulse);
        }
        ////float hAxis = Input.GetAxis("Horizontal");
        //float vAxis = Input.GetAxis("Vertical") <= 0 ? dropSpeed : Input.GetAxis("Vertical");

        Vector2 mouvement = new Vector2(1,-1) * runningSpeed * Time.deltaTime;

        rig.MovePosition(new Vector2(transform.position.x, transform.position.y) + mouvement);

        //rig.velocity += 0 * Vector2.right;


    }
}
