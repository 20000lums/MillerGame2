using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;



public class PlayerMovement : MonoBehaviour
{

//all this is input stuff
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
//this concludes the input stuff

    public Rigidbody2D RB;
    public Collider2D Collider;
    public LayerMask ground;
    private ContactFilter2D groundFilter;
    // variables for movement
    private int GroundState = 1;
    private float speed = 0;
    private int AirGraph = 0;
    private bool IsDodge = false;
    public float speedLevel { get; private set; } = 0;
    float GTime = 0;
    // movement variables n shit.
    // basic movement
    public float TopSpeed = 1;
    public float AccelerationTime = 1;
    public float DecelerationTime = 1;
    // normal jump
    public float JumpHeight = 1;
    public float JumpHangTime = 1;
    // long jump
    public float LongJumpHeight = 1;
    public float LongJumpHangTime = 1;
    // high jump
    public float HighJumpStepHeight = 1;
    public float HighJumpBaseHeight = 1;
    public float HighJumpHangTime = 1;
    // stomp
    public float StompSpeed = 1;

    void Start()
    {
        groundFilter.useTriggers = false;
        groundFilter.SetLayerMask(ground);
        RB.isKinematic = true;
    }

    
    void FixedUpdate()
    {
        FallingUpdate();
        AirUpdate();
        groundedUpdate();
    }
    //AirGraph 0 = fall
    //AirGraph 1 = normal jump
    //AirGraph 2 = long jump
    //AirGraph 3 = high jump
    //Airgraph 4 = stomp
    float getGraph(int GraphType, float GraphPoint)
    {
        return 1;
    }

    void AirUpdate()
    {
        if(GroundState == 2)
        {
            if(Button3.ReadValue<float>() == 1 && AirGraph != 4)
            {
                AirGraph = 4;
                GTime = 0;
            }
            List<bool> CollisionList = new List<bool>();
            CollisionList = move( new Vector2(speed , getGraph(AirGraph, GTime + .02f) - getGraph(AirGraph, GTime)));
            GTime += .02f;
            if(CollisionList[0])
            {
                GroundState = 3;
            }
            if(CollisionList[1] && Mathf.Sign(getGraph(AirGraph, GTime + .02f) - getGraph(AirGraph, GTime)) == -1)
            {
                GroundState = 1;
                GTime = 0;
            }
        }
    }

    void StartFall(Vector2 KnockbackDirection)
    {
        GroundState = 3;
        RB.isKinematic = false;
        RB.velocity = KnockbackDirection;
    }

    void FallingUpdate()
    {
        RaycastHit2D[] trash = new RaycastHit2D[16];
        if(GroundState == 3 && RB.Cast(Vector2.down, groundFilter,trash, .01f) != 0)
        {
            RB.isKinematic = true;
            GroundState = 1;
        }
    }

    void groundedUpdate()
    {
        if(GroundState == 1)
        {
            if(LeftRight.ReadValue<float>() != 0)
            {
                speed += Mathf.Sign(LeftRight.ReadValue<float>())*TopSpeed/(AccelerationTime*50);
                if(Mathf.Abs(speed) > TopSpeed)
                {
                    speed = Mathf.Sign(speed) * TopSpeed;
                }
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
            speedLevel = (3*speed/TopSpeed)-((3*speed/TopSpeed)%1);
            if (Button1.ReadValue<float>() == 1)
            {
                GroundState = 2;
                if(IsDodge)
                {
                    AirGraph = 2;
                }
                else if(Button3.ReadValue<float>() == 1)
                {
                    AirGraph = 3;
                }
                else
                {
                    AirGraph = 1;
                }
            }
            RaycastHit2D[] trash = new RaycastHit2D[16];
            if(RB.Cast(Vector2.down, groundFilter,trash, .01f) == 0)
            {
                GroundState = 2;
                AirGraph = 0;
            }
            
        }
    }

    //simulates normal force. moving using this method will prevent you from going through layer "ground" but will be uneffected by momentum n stuff
    List<bool> move(Vector2 Direction) 
    {
        RaycastHit2D[] Results = new RaycastHit2D[16];
        if (RB.Cast(Direction, groundFilter, Results, Direction.magnitude) == 0)
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
