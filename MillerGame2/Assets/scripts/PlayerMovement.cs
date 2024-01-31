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
    private bool CanDodge = true;
    private float DodgeTime = 0;
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
    // dodge
    public float DodgeLeingth = 1;
    public float DodgeCooldown = 1.5f;
    //fall
    public float FallKnockback = 0;

    public Vector2 moveVector;
    void Controll()
    {
        if (Input.GetKey(KeyCode.D))
        {
            moveVector.x += 1;
        }
        if (Input.GetKey(KeyCode.A))
        {
            moveVector.x += -1;
        }
        if (Input.GetKey(KeyCode.W))
        {
            moveVector.y += 1;
        }
        if (Input.GetKey(KeyCode.S))
        {
            moveVector.y += -1;
        }
        move(moveVector * .2f);
        moveVector = Vector2.zero;
    }
    void Start()
    {
        groundFilter.useTriggers = false;
        groundFilter.SetLayerMask(ground);
    }

    void FixedUpdate()
    {

        //Controll();
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
        switch(GraphType)
        {
            case 0:
                return -15 *Mathf.Pow(GraphPoint, 2);
            case 1:
                return -JumpHeight*Mathf.Pow((1/JumpHangTime)*(GraphPoint - JumpHangTime) , 2) + JumpHeight;
            case 2:
                return -LongJumpHeight * Mathf.Pow((1 / LongJumpHangTime) * (GraphPoint - LongJumpHangTime), 2) + LongJumpHeight;
            case 3:
                return 4;
            case 4:
                return -StompSpeed * GraphPoint;
        }
        return 7;
    }

    void AirUpdate()
    {
        
        if(GroundState == 2)
        {
            
            if (Button3.ReadValue<float>() == 1 && AirGraph != 4)
            {
                
                AirGraph = 4;
                GTime = 0;
            }
            List<bool> CollisionList = new List<bool>();
            CollisionList = move( new Vector2(speed , getGraph(AirGraph, GTime + .02f) - getGraph(AirGraph, GTime)));
            if (CollisionList[0])
            {
                StartFall();
            }
            if(CollisionList[1] && (Mathf.Sign(getGraph(AirGraph, GTime + .02f) - getGraph(AirGraph, GTime))) == -1)
            {
                Debug.Log("this happened");
                GroundState = 1;
                GTime = 0;
            }
            else if(CollisionList[1])
            {
                StartFall();
            }
            GTime += .02f;


        }
    }

    void StartFall()
    {
        GroundState = 3;
        GTime = 0;
    }

    void FallingUpdate()
    {
        if(GroundState == 3)
        {
            if(move(new Vector2(-1f*FallKnockback*Mathf.Sign(speed), getGraph(0, GTime + .02f) - getGraph(0, GTime)))[1])
            {
                GroundState = 1;
                speed = 0;
            }
            GTime += .02f;
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
            if(Button2.ReadValue<float>() == 1 && CanDodge)
            {
                IsDodge = true;
                CanDodge = false;
            }
            if(!CanDodge)
            {
                IsDodge = DodgeTime <= DodgeLeingth;
                CanDodge = DodgeTime > DodgeCooldown;
                DodgeTime += .02f;
            }
            if (Button1.ReadValue<float>() == 1)
            {
                
                GroundState = 2;
                if(IsDodge)
                {
                    AirGraph = 2;
                    CanDodge = true;
                    IsDodge = false;
                    DodgeTime = 0;
                    //Debug.Log(AirGraph);
                }
                else if(Button3.ReadValue<float>() == 1)
                {
                    AirGraph = 3;
                }
                else
                {
                    //Debug.Log("thisHappened");
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
                if (Vector2.Distance(cum.centroid, new Vector2(transform.position.x, transform.position.y)) < Vector2.Distance(ResultsList[i].centroid, new Vector2(transform.position.x, transform.position.y)))
                {
                    cum = ResultsList[i];
                }
            }
            Debug.Log(GroundState);
            Debug.Log(cum.centroid - new Vector2(transform.position.x, transform.position.y));
            Debug.Log(Mathf.Sign(getGraph(AirGraph, GTime + .02f) - getGraph(AirGraph, GTime)));
            transform.position = (new Vector3(cum.centroid.x, cum.centroid.y, 0));
            return new List<bool>(){cum.normal.x !=0, cum.normal.y !=0};
        }
    }
      
      
    
}
