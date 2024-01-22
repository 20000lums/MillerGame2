using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class PlayerMovement : MonoBehaviour
{
    public Rigidbody2D RB;
    public Collider2D Collider;
    public LayerMask ground;
    private Vector2 moveVector;
    private ContactFilter2D groundFilter;
    
    void Start()
    {
        groundFilter.useTriggers = false;
        groundFilter.SetLayerMask(ground);
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
        RaycastHit2D[] Results = new RaycastHit2D[16];
        if (RB.Cast(Direction, groundFilter, Results, Direction.magnitude ) == 0)
        {
            RB.MovePosition(Direction + new Vector2(transform.position.x, transform.position.y));
            return new List<bool>(){false, false};
        }
        else
        {
            RaycastHit2D cum;
             List<RaycastHit2D> ResultsList = new List<RaycastHit2D>();
            for (int i = 0; i < Results.Length; i++)
            {
                if(Vector2.Dot(Results[i].normal,Direction) > 0 )
                {
                    ResultsList.Add(Results[i]);
                }
                
            }
            if(ResultsList.Count == 0)
            {
                 RB.MovePosition(Direction + new Vector2(transform.position.x, transform.position.y));
                 return new List<bool>(){false, false};
            }
            cum = ResultsList[0];
            for (int i = 1; i < ResultsList.Count; i++)
            {
                if(cum.distance < ResultsList[i].distance)
                {
                    cum = ResultsList[i];
                }
            }
            RB.MovePosition(cum.centroid);
            return new List<bool>(){cum.normal.x !=0, cum.normal.y !=0};


        }
    }
      
      
    
}
