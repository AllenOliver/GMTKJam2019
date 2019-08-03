using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/// <summary>
/// Provides player jumps with gravity and better falling.
/// </summary>
[RequireComponent(typeof(PlayerController))]
public class PlayerJump : MonoBehaviour {

    #region variables

    public float JumpModifier = 2.5f;
    public float FallModifier = 1.75f;
    private Rigidbody2D rb;
    #endregion

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }
	void FixedUpdate () {
	    if (rb.velocity.y < 0)
	    {
            //when jumping
	        rb.gravityScale = JumpModifier;
	    }
        else if(rb.velocity.y > 0 && !Input.GetButton("Jump"))
	    {
            //when falling 
	        rb.gravityScale = FallModifier;
        }
	    else
	    {
            //reg scale
	        rb.gravityScale = 1f;
	    }
	}
}
