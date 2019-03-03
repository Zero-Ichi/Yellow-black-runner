using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class PhysicsObject : BaseController
{
    [SerializeField]
    protected float minGoundNormalY = .65f;
    [SerializeField]
    protected float gravityModifier = 1f;

    protected bool isGrounded;
    protected Vector2 groundNormal;
    protected Vector2 velocity;
    protected Rigidbody2D rb2d;

    protected const float minMoveDistance = 0.001f;
    protected const float shellRadius = 0.01f;
    protected ContactFilter2D contactFilter;
    protected RaycastHit2D[] hitBuffer = new RaycastHit2D[16];

    protected List<RaycastHit2D> hitBufferList = new List<RaycastHit2D>();

    protected Vector2 TargetVelocity;

    protected abstract void ComputeVelocity();

    // Cette fonction est appelée quand l'objet est activé et actif
    private void OnEnable()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }

    // Use this for initialization
    void Start()
    {
        //Ne pas utiliser les triggers
        contactFilter.useTriggers = false;
        //Permet de travailler seulement sur le layer du gameobject
        //Economie de ressources
        contactFilter.SetLayerMask(Physics2D.GetLayerCollisionMask(gameObject.layer));
        contactFilter.useLayerMask = true;

    }

    // Update is called once per frame
    void Update()
    {
        TargetVelocity = Vector2.zero;
        ComputeVelocity();
    }

    //use for physic thing
    private void FixedUpdate()
    {
        velocity += gravityModifier * Physics2D.gravity * Time.deltaTime;
        velocity.x = TargetVelocity.x;
        //Toujours considerer que "isGrounded" est faux avant de recalculer la valeur
        isGrounded = false;

        Vector2 deltaPosition = velocity * Time.deltaTime;

        Vector2 moveAlongGround = new Vector2(groundNormal.y, -groundNormal.x);

        Vector2 move = moveAlongGround * deltaPosition.x;
        Mouvement(move, false);

        move = Vector2.up * deltaPosition.y;

        Mouvement(move, true);
    }

    private void Mouvement(Vector2 move, bool yMouvement)
    {
        //
        float distance = move.magnitude;
        if (distance > minMoveDistance)
        {
            //Cast sert a regarder a la frame d'apres où on sera
            //shellRadius pour ajouter un peut de padding pour ne pas passer dans un autre Collider
            int count = rb2d.Cast(move, contactFilter, hitBuffer, distance + shellRadius);
            hitBufferList.Clear();
            for (int i = 0; i < count; i++)
            {
                hitBufferList.Add(hitBuffer[i]);
            }
            for (int i = 0; i < hitBufferList.Count; i++)
            {
                //Utiliser la Normal evite de que le joueur puisse tenir sur les mur
                Vector2 currentNormal = hitBufferList[i].normal;
                if (currentNormal.y > minGoundNormalY)
                {
                    isGrounded = true;
                    if (yMouvement)
                    {
                        groundNormal = currentNormal;
                        currentNormal.x = 0;
                    }
                }
                //Fait la difference entre les deux verctor et determine ce qu'on a besoin de 
                // soustraire depuis pour eviter que notre player rentre dans un autre collider
                float projection = Vector2.Dot(velocity, currentNormal);
                if (projection < 0)
                {
                    //Cela evite que si le player touche un plafgond il ne s'arrete net
                    velocity = velocity - projection * currentNormal;
                }
                float modifiedDistance = hitBufferList[i].distance - shellRadius;
                distance = modifiedDistance < distance ? modifiedDistance : distance;

            }
        }
        rb2d.position += move.normalized * distance;

    }
}
