﻿using Assets.Scripts.Globals;
using System.Collections;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    /// <summary>
    /// Handles most things for the player
    /// </summary>

    #region Private Variables

    private Animator anim;

    public GameObject Particles;

    private AudioSource sound
        ;

    private bool talking;
    private bool jumpBool;
    private bool isOverlappingInteractable;

    #endregion Private Variables

    #region Public Variables

    [Header("[RunSpeed]")]
    public float moveSpeed;

    [Header("[How High Player Can Jump]")]
    public float jumpHeight;

    [Header("[Ground Object Pls]")]
    public Transform groundCheck;

    [Header("[circle to see if ground is near]")]
    public float groundCheckRadius;

    [Header("[Which Layers can I jump Off of?]")]
    public LayerMask whatIsGround;

    [Header("[Grounded?]")]
    public bool isGrounded;

    public GameObject AttackObject;

    public int AttackPower;

    #endregion Public Variables

    private Rigidbody2D rbody;

    private void Start()
    {
        rbody = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        sound = GetComponent<AudioSource>();
        jumpBool = false;
    }

    // Update is called once per frame
    private void Update()
    {
        if (!GlobalVariables.canMove)
            return;

        GroundCheck();

        switch (GlobalVariables.canMove)
        {
            case (true):
                if (Input.GetAxisRaw("Horizontal") > 0f)
                {
                    rbody.velocity = new Vector3(moveSpeed, rbody.velocity.y, 0f);
                    transform.localScale = new Vector3(-1f, 1f, 0f);
                    Particles.transform.localScale = new Vector3(1f, 1f, 0f);
                    anim.SetBool("IsWalking", true);
                }
                else if (Input.GetAxisRaw("Horizontal") < 0f && GlobalVariables.canWalkLeft)
                {
                    rbody.velocity = new Vector3(-moveSpeed, rbody.velocity.y, 0f);
                    transform.localScale = new Vector3(1f, 1f, 0f);
                    Particles.transform.localScale = new Vector3(-1f, 1f, 0f);

                    anim.SetBool("IsWalking", true);
                }
                else
                {
                    rbody.velocity = new Vector3(0, rbody.velocity.y, 0f);
                    anim.SetBool("IsWalking", false);
                }

                if (Input.GetButtonDown("Attack"))
                {
                    if (isOverlappingInteractable)
                        talking = true;
                    else
                        Attack();
                }

                if (Input.GetButtonDown("Jump") && isGrounded && GlobalVariables.canJump)
                {
                    jumpBool = true;
                }

                Grounded();
                //anim.SetFloat("Movement", GetPlayerYVelocity());
                break;

            case (false):
                Grounded();
                //anim.SetFloat("Movement", GetPlayerYVelocity());
                return;
        }
        anim.SetFloat("Movement", GetPlayerYVelocity());

        isGrounded = GroundCheck();
    }

    private void Attack() => StartCoroutine(AttackRoutine());

    private IEnumerator AttackRoutine()
    {
        if (GlobalVariables.canAttack)
        {
            using (new TogglePlayerAction())
            {
                //PlayerStop();
                sound.pitch = Random.Range(1.1f, 1.3f);
                sound.Play();
                anim.SetTrigger("Attack");
                yield return new WaitForSeconds(.2f);
                AttackObject.Active();
                yield return new WaitForSeconds(.05f);
                AttackObject.Inactive();
            }
        }
    }

    private void FixedUpdate()
    {
        if (jumpBool)
        {
            GetComponent<Rigidbody2D>().AddForce(Vector2.up * jumpHeight, ForceMode2D.Impulse);
            jumpBool = false;
        }
    }

    /// <summary>
    /// sets animator to grounded or jumping
    /// </summary>
    private void Grounded()
    {
        if (GroundCheck())
            anim.SetBool("Grounded", true);
        else
            anim.SetBool("Grounded", false);
    }

    private bool GroundCheck() => Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, whatIsGround);

    //private void SetAnimMovementFloat() => anim.SetFloat("Movement", Input.GetAxisRaw("Horizontal"));

    /// <summary>
    /// Dies this instance.
    /// </summary>
    /// <returns></returns>
    public IEnumerator Die()
    {
        yield return null;
    }

    #region Public Kill Function

    public void Kill() => StartCoroutine(Die());

    #endregion Public Kill Function

    private void OnTriggerEnter2D(Collider2D coll)
    {
        switch (coll.gameObject.tag)
        {
            case ("Interactable"):
                var dm = FindObjectOfType<DialogueManager>();
                PlayerStop();
                isOverlappingInteractable = true;
                break;
        }
    }

    private void OnTriggerStay2D(Collider2D col)
    {
        switch (col.gameObject.tag)
        {
            case "Interactable":
                if (talking)
                {
                    col.gameObject.GetComponent<Interactable>().TriggerDialogue();
                    talking = false;
                }

                break;
        }
    }

    private void OnTriggerExit2D(Collider2D col)
    {
        switch (col.gameObject.tag)
        {
            case "Interactable":
                isOverlappingInteractable = false;
                break;
        }
    }

    private IEnumerator TalkWait(Collider2D col)
    {
        col.gameObject.GetComponent<Interactable>().TriggerDialogue();
        yield return new WaitForSeconds(.25f);
        talking = false;
    }

    public void PlayerStop()
    {
        rbody.velocity = new Vector3(0, rbody.velocity.y, 0f);
        anim.SetBool("IsWalking", false);
    }

    public float GetPlayerYVelocity() => (rbody.velocity.y < 0) ? 0f : 1f;
}