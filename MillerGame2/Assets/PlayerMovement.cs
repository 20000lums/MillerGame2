using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class PlayerMovement : MonoBehaviour
{
    public Rigidbody2D RB;
    public Collider2D Collider;
    public LayerMask ground;
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
        if (Physics2D.BoxCast(transform.position, transform.localScale, 0f, Direction, Direction.magnitude, ground) == null)
        {
           RB.MovePosition(Direction + new Vector2(transform.position.x, transform.position.y));
           return new List<bool>() { false, false };
        }
        else
        {
           RB.MovePosition(Physics2D.BoxCast(transform.position, transform.localScale, 0f, Direction, Direction.magnitude, ground).centroid);
           return new List<bool>() { Physics2D.BoxCast(transform.position, transform.localScale, 0f, Vector2.right, .01f, ground) != null, Physics2D.BoxCast(transform.position, transform.localScale, 0f, Vector2.up, .01f, ground) != null };
        }

    }
}
