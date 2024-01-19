using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class PlayerMovement : MonoBehaviour
{
    public Rigidbody2D RB;
    public Collider2D Collider;
    public LayerMask ground;
    private Vector2 moveVector;
   
    
    void Start()
    {
        RB.isKinematic = true;
    }

    
    void  FixedUpdate()
    {
        if(Input.GetKey(KeyCode.D))
        {
            moveVector.x += 1;
        }
        if(Input.GetKey(KeyCode.A))
        {
            moveVector.x += -1;
        }
        if(Input.GetKey(KeyCode.W))
        {
            moveVector.y += 1;
        }
        if(Input.GetKey(KeyCode.S))
        {
            moveVector.y += -1;
        }
        RB.velocity = moveVector;
        moveVector = new Vector2(0, 0);
    }
    //simulates normal force. moving using this method will prevent you from going through layer "ground" but will be uneffected by physics
    List<bool> move(Vector2 Direction) 
    {
        if (!Physics2D.BoxCast(transform.position, transform.localScale, 0f, Direction, Direction.magnitude, ground))
        {
           RB.MovePosition(Direction + new Vector2(transform.position.x, transform.position.y));
           return new List<bool>() { false, false };
        }
        else
        {
           RB.MovePosition(Physics2D.BoxCast(transform.position, transform.localScale, 0f, Direction, Direction.magnitude, ground).centroid);
           return new List<bool>() { Physics2D.BoxCast(transform.position, transform.localScale, 0f, Vector2.right, .01f, ground), Physics2D.BoxCast(transform.position, transform.localScale, 0f, Vector2.up, .01f, ground) };
        }

    }
}
