using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerAniations : MonoBehaviour
{
    //input things
    private PlayerInputs playerInputs;
    private InputAction LeftRight;

    private void Awake()
    {
        playerInputs = new PlayerInputs();
    }

    private void OnEnable()
    {
        LeftRight = playerInputs.Player.LeftRight;
        LeftRight.Enable();
    }

    private void OnDisable()
    {
        LeftRight.Disable();
    }

    public PlayerMovement PlayerScript;
    public Animator animator;
    private SpriteRenderer Rend;

    // Start is called before the first frame update
    void Start()
    {
        Rend = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        animator.SetFloat("PlayerSpeed", PlayerScript.speedLevel);
        animator.SetBool("PlayerIsAirborn", PlayerScript.GroundState != 1);
        if(LeftRight.ReadValue<float>() > 0)
        {
            Rend.flipX= false;
        }
        else if(LeftRight.ReadValue<float>() < 0)
        {
            Rend.flipX = true;
        }
    }
}
