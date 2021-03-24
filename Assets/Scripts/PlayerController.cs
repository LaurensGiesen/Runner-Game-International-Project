using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    public float moveSpeed;
    public float speedMultiplier;
    public float speedIncreaseMilestone;
    public float jumpForce;
    public float jumpTime;
    private float jumpTimeCounter;
    private float speedMilestoneCount;
    private Rigidbody2D myRigidbody;
    public bool grounded; 
    public LayerMask whatIsGround; 
    public Transform groundCheck;
    public float groundCheckRadius;
    private Animator myAnimator;
    // Start is called before the first frame update
    void Start() {
        myRigidbody = GetComponent<Rigidbody2D>(); 
        myAnimator = GetComponent<Animator>();
        jumpTimeCounter = jumpTime;
        speedMilestoneCount = speedIncreaseMilestone;
    }
    // Update is called once per frame
    void Update() {
        grounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, whatIsGround);
        if (transform.position.x > speedMilestoneCount) {
            speedMilestoneCount += speedIncreaseMilestone;
            speedIncreaseMilestone = speedIncreaseMilestone * speedMultiplier;
            moveSpeed = moveSpeed * speedMultiplier;
        }

        myRigidbody.velocity = new Vector2(moveSpeed, myRigidbody.velocity.y);

        if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0)) 
        {
            if(grounded)
            {
                myRigidbody.velocity = new Vector2(myRigidbody.velocity.x, jumpForce);
            }
        }  

        if (Input.GetKey (KeyCode.Space) || Input.GetMouseButton(0)) {
            if(jumpTimeCounter > 0) {
                myRigidbody.velocity = new Vector2(myRigidbody.velocity.x, jumpForce);
                jumpTimeCounter -= Time.deltaTime;
            }
        }

        if (Input.GetKeyUp (KeyCode.Space) || Input.GetMouseButtonUp(0)) {
            jumpTimeCounter = 0;
        }

        if (grounded) {
            jumpTimeCounter = jumpTime;
        }
        myAnimator.SetFloat("Speed", myRigidbody.velocity.x);
        myAnimator.SetBool("Grounded", grounded);
    }
}
