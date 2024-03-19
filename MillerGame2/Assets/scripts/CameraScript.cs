using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour
{
    public GameObject Parent;
    private PlayerMovement PlayerScript;

    public float panMultiplyer = 1;
    public float catchUpSpeed = 1;
    // Start is called before the first frame update
    void Start()
    {
        PlayerScript = Parent.GetComponent<PlayerMovement>();
    }
    

    // Update is called once per frame
    void FixedUpdate()
    {
        if(PlayerScript.GroundState != 3)
        {
            transform.position = Parent.transform.position + Vector3.MoveTowards(transform.position - Parent.transform.position, new Vector3(panMultiplyer*PlayerScript.speed,0,-1), catchUpSpeed);
        }
        else
        {
             transform.position = Parent.transform.position + Vector3.MoveTowards(transform.position - Parent.transform.position, Vector3.back, catchUpSpeed);
        }
    }
}
