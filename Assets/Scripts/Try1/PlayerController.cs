using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    [SerializeField]
    protected float runningSpeed = 10;

    [SerializeField]
    protected float dropSpeed = -3;

    [SerializeField]
    protected float jumpSpeed = 10;



    protected Rigidbody2D rig;

    // Use this for initialization
    void Start()
    {
        rig = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {


        ////float hAxis = Input.GetAxis("Horizontal");
        //float vAxis = Input.GetAxis("Vertical") <= 0 ? dropSpeed : Input.GetAxis("Vertical");

        Vector2 mouvement = new Vector2(1, -1) * runningSpeed * Time.deltaTime;



        //rig.velocity += 0 * Vector2.right;

        if (Input.GetKeyDown(KeyCode.Space))
        {
            mouvement.y += jumpSpeed;
        }
        rig.MovePosition(new Vector2(transform.position.x, transform.position.y) + mouvement);
    }
}
