using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    // Initializ animator
    public Animator animator;

    // Initalize horizontalMove variable to 0
    float horizontalMove = 0;
    
    // Initialize runSpeed variable to 4
    public float runSpeed = 4f;

    // Create header Component
    [Header("Component")]
    
    // Initialize Rigidbody2D
    public Rigidbody2D Rb;

    // Initialize LayerMask
    public LayerMask groundLayer;

    // Creadt header Collision
    [Header("Collision")]

    // Initialize onGround variable to be false
    public bool onGround = false;

    // Initialize the length of the line that checks the collision of the ground
    public float groundLine = 2;


    // Start is called before the first frame update
    void Start()
    {
        // Initialize Rigidbody2D on Start function
        Rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        // Checks the ground by using Raycast to see if there are collisions with colliders which will then return true
        onGround = Physics2D.Raycast(transform.position, Vector2.down, groundLine, groundLayer);
        
        // Input keys for character movement
        bool space = Input.GetKey(KeyCode.Space);
        bool rightKey = Input.GetKey(KeyCode.RightArrow);
        bool leftKey = Input.GetKey(KeyCode.LeftArrow);

        
        // When right key is pressed, character will move right
        if (rightKey)
        {
            Debug.Log("Right Key Pressed");
            Rb.AddForce(Vector2.right, ForceMode2D.Impulse);

        }


        // When left key is pressed, character will move right
        if (leftKey)
        {
            Debug.Log("Left Key Pressed");
            Rb.AddForce(Vector2.left, ForceMode2D.Impulse);

        }

        // When space key is pressed, character will jump off the ground, but also has to standing on the ground
        if (space && onGround)
        {
            Debug.Log("Space Key Pressed");
            Rb.AddForce(Vector2.up * 4, ForceMode2D.Impulse);

        }
        // Player's animation movement
        horizontalMove = Input.GetAxisRaw("Horizontal") * runSpeed;

        if (onGround)
        {

            animator.SetBool ("IsJumping", false);
        }
        else {
            animator.SetBool("IsJumping",true);
        }
        animator.SetFloat("Speed", Mathf.Abs(horizontalMove));

    }


    private void OnDrawGizmos()
    {
        // The color of the raycast line is blue
        Gizmos.color = Color.blue;

        // The DrawLine function draw a line where the raycast is
        Gizmos.DrawLine(transform.position, transform.position + Vector3.down*groundLine);
    }
}
