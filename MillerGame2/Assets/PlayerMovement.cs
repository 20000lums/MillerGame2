using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public Rigidbody2D RB;
    public Collider2D Collider;
    public
    // Start is called before the first frame update
    void Start()
    {
        RB.isKinematic = true;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    List<bool> move(Vector2 Direction)
    {
        if (Physics2D.BoxCast(transform.position, transform.scale, 0f, Direction, Direction.magnitude, QueryTriggerInteraction.terrain) == null)
        {
           RB.MovePosition(Direction + transform.position);
           return new List<bool>[false, false];
        }
        else
        {
            RB.MovePosition(Physics2D.BoxCast(transform.position, transform.scale, 0f, Direction, Direction.magnitude, terrain).centroid);
            return new List<bool>[Physics2D.BoxCast(transform.position, transform.scale, 0f, Vector2.right, .01f, QueryTriggerInteraction.terrain) != null, Physics2D.BoxCast(transform.position, transform.scale, 0f, Vector2.up, .01f, QueryTriggerInteraction.terrain) == null];
        }

    }
}
