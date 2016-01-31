using System;
using UnityEngine;

public class PlatformerMotor : MonoBehaviour
{
	[SerializeField] private Animator m_Anim;            // Reference to the player's animator component.
    [SerializeField] private float m_MaxSpeed = 10f;                    // The fastest the player can travel in the x axis.
	[SerializeField] private float m_JumpSpeed = 4f;                  // Amount of force added when the player jumps;
	[SerializeField] private float m_WindJumpSpeed = 4f;                  // Amount of force added when the player jumps when he cast wind spell;
	[SerializeField] private float m_maxJumpDuration = 0.2f;                  // Amount of force added when the player jumps;
    [SerializeField] private LayerMask m_WhatIsGround;                  // A mask determining what is ground to the character
	public SkeletonAnimator modelAnimator = null;

    private Transform m_GroundCheck;    // A position marking where to check if the player is grounded.
    const float k_GroundedRadius = .1f; // Radius of the overlap circle to determine if grounded
	private bool m_Grounded;            // Whether or not the player is grounded.
    const float k_CeilingRadius = .01f; // Radius of the overlap circle to determine if the player can stand up

    private Rigidbody2D m_Rigidbody2D;
    internal bool m_FacingRight = true;  // For determining which way the player is currently facing.

	private float _jumpTimeElapsed = 0f;
    protected bool LastMove = true;

    private void Awake()
    {
        // Setting up references.
        m_GroundCheck = transform.Find("GroundCheck");
        m_Rigidbody2D = GetComponent<Rigidbody2D>();
    }


    private void FixedUpdate()
    {
        m_Grounded = false;

        // The player is grounded if a circlecast to the groundcheck position hits anything designated as ground
        // This can be done using layers instead but Sample Assets will not overwrite your project settings.
        Collider2D[] colliders = Physics2D.OverlapCircleAll(m_GroundCheck.position, k_GroundedRadius, m_WhatIsGround);
        for (int i = 0; i < colliders.Length; i++)
        {
			if (colliders [i].gameObject != gameObject)
			{
				if (!m_Grounded) {
					modelAnimator.Reset ();
				}
				m_Grounded = true;
				_jumpTimeElapsed = 0f;
			}
        }
        m_Anim.SetBool("Ground", m_Grounded);

        // Set the vertical animation
        m_Anim.SetFloat("VerticalSpeed", m_Rigidbody2D.velocity.y);
    }
		
	#region Movement
	public void Move(float move, bool a_jump)
    {
		// Apply speed reduction if necessary.
		// move = move;
       	if(move != 0f)
		{
			LastMove = move>0;
		}
		if (GameMode.instance.player.StatusManager.CheckStatus(EStatus.Fire))
		{
			if(LastMove)
			move = 1;
			else
			move = -1;
		}
		
        // The Speed animator parameter is set to the absolute value of the horizontal input.
        m_Anim.SetFloat("HorizontalSpeed", Mathf.Abs(move));

        // Move the character
		m_Rigidbody2D.velocity = new Vector2(move*m_MaxSpeed, m_Rigidbody2D.velocity.y);
		ManageJump (a_jump);

        // If the input is moving the player right and the player is facing left...
        if (move > 0 && !m_FacingRight)
        {
            // ... flip the player.
            Flip();
        }
            // Otherwise if the input is moving the player left and the player is facing right...
        else if (move < 0 && m_FacingRight)
        {
            // ... flip the player.
            Flip();
        }
    }

	protected bool _isContinuousJump = false;
	protected void ManageJump(bool a_isJumping)
	{
		if (a_isJumping && (_isContinuousJump || m_Grounded) && _jumpTimeElapsed < m_maxJumpDuration)
		{
    		_jumpTimeElapsed += Time.fixedDeltaTime;
			_isContinuousJump = true;

			m_Grounded = false;
			m_Anim.SetBool ("Ground", false);
			Vector2 velocity = m_Rigidbody2D.velocity;
			velocity.y = m_JumpSpeed;
			m_Rigidbody2D.velocity = velocity;
		}

		_isContinuousJump = a_isJumping && _isContinuousJump;
		if (GameMode.instance.player.StatusManager.CheckStatus(EStatus.Wind))
		{
			Vector2 velocity = m_Rigidbody2D.velocity;
			velocity.y = m_WindJumpSpeed;
			m_Rigidbody2D.velocity = velocity;
		}
	}
	#endregion

	#region Internal management
	private void Flip()
	{
		// Switch the way the player is labelled as facing.
		m_FacingRight = !m_FacingRight;

		// Multiply the player's x local scale by -1.
		Vector3 theScale = transform.localScale;
		theScale.x *= -1;
		transform.localScale = theScale;
	}
	#endregion

	internal void SetAnim (string arg)
	{
		m_Anim.SetTrigger(arg);
	}
}
