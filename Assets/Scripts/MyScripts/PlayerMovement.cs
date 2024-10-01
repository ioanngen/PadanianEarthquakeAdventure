using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PLM
{
    public class PlayerMovement : MonoBehaviour
    {
        public bool canMove = true;
        Rigidbody2D body;
        Animator animator;
        float directionX = 0f;
        SpriteRenderer sprite;
        [SerializeField] float JumpingForce = 14f;
        [SerializeField] float MovingForce = 7f;
        BoxCollider2D collider;
        [SerializeField] LayerMask JumpableGround;
        enum MovementState { idle, running, jumping, falling }
        [SerializeField] AudioSource jumpSoundEffect;

        void Start()
        {
            body = GetComponent<Rigidbody2D>();
            animator = GetComponent<Animator>();
            sprite = GetComponent<SpriteRenderer>();
            collider = GetComponent<BoxCollider2D>();
        }

        void Update()
        {
            if (canMove)
            {
                directionX = Input.GetAxisRaw("Horizontal");
                body.velocity = new Vector2(directionX * MovingForce, body.velocity.y);
                if (Input.GetButtonDown("Jump") && IsGrounded())
                {
                    body.velocity = new Vector2(body.velocity.x, JumpingForce);
                    jumpSoundEffect.Play();
                }
                AnimationUpdate();
            }
            else 
            {
                directionX = 0f;
                AnimationUpdate();
            }
        }

        void AnimationUpdate()
        {
            MovementState state;
            if (directionX > 0f)
            {
                state = MovementState.running;
                sprite.flipX = false;
            }
            else if (directionX < 0f)
            {
                state = MovementState.running;
                sprite.flipX = true;
            }
            else
            {
                state = MovementState.idle;
            }
            if (body.velocity.y > .1f)
            {
                state = MovementState.jumping;
            }
            else if (body.velocity.y < -.1f)
            {
                state = MovementState.falling;
            }

            animator.SetInteger("MovementState", (int)state);
        }

        bool IsGrounded()
        {
            return Physics2D.BoxCast(collider.bounds.center, collider.bounds.size, 0f, Vector2.down, .1f, JumpableGround);
        }
    }

}