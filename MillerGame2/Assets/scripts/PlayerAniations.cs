using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAniations : MonoBehaviour
{
    public PlayerMovement PlayerScript;
    public Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        animator.SetFloat("PlayerSpeed", PlayerScript.speedLevel);
    }
}
