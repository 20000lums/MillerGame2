using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;



public class PlayerMovement : MonoBehaviour
{


    private PlayerInputs playerInputs;
    private InputAction LeftRight;
    private InputAction Button1;
    private InputAction Button2;
    private InputAction Button3;

    private void Awake()
    {
        playerInputs = new PlayerInputs();
    }

    private void OnEnable()
    {
        LeftRight = playerInputs.Player.LeftRight;
        LeftRight.Enable();
        Button1 = playerInputs.Player.ActionPrimary;
        Button1.Enable();
        Button2 = playerInputs.Player.ActionSecondary;
        Button2.Enable();
        Button3 = playerInputs.Player.ActionTirtiary;
        Button3.Enable();
    }

    private void OnDisable()
    {
        LeftRight.Disable();
        Button1.Disable();
        Button2.Disable();
        Button3.Disable();
    }


    public Rigidbody2D RB;
    public Collider2D Collider;
    public LayerMask ground;
    private ContactFilter2D groundFilter;
    private int GroundState = 1;
    private float speed = 0;
    // movement variables n shit. 
    public float TopSpeed = 1;
    public float AccelerationTime = 1;
    public float DecelerationTime = 1;

    void Start()
    {
        groundFilter.useTriggers = false;
        groundFilter.SetLayerMask(ground);
        RB.isKinematic = true;
        move(new Vector2(0,-2));
    }

    
    void  FixedUpdate()
    {
        groundedUpdate();
    }

    void groundedUpdate()
    {
        if(GroundState == 1)
        {
            if(LeftRight.ReadValue<float>() != 0)
            {
                speed += Mathf.Sign(LeftRight.ReadValue<float>())*TopSpeed/(AccelerationTime*50);
            }
            else if(speed != 0)
            {
                float signNow;
                signNow = Mathf.Sign(speed);
                speed += Mathf.Sign(speed)*-1*TopSpeed/(DecelerationTime*50);
                if(signNow != Mathf.Sign(speed))
                {
                    speed = 0;
                }
            }
            if (move(new Vector2(speed, 0))[0])
            {
                speed = 0;
            }
        }
    }

    //simulates normal force. moving using this method will prevent you from going through layer "ground" but will be uneffected by momentum n stuff
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
            
            List<RaycastHit2D> ResultsList = new List<RaycastHit2D>();
            for (int i = 0; i < Results.Length; i++)
            {
                if(Vector2.Dot(Results[i].normal,Direction) < 0 )
                {
                    ResultsList.Add(Results[i]);
                }
                
            }
            if(ResultsList.Count == 0)
            {
                 RB.MovePosition(Direction + new Vector2(transform.position.x, transform.position.y));
                 return new List<bool>(){false, false};
            }
            RaycastHit2D cum = ResultsList[0];
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
