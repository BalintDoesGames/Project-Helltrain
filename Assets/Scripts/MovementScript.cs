using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementScript : MonoBehaviour
{
   [Header("Setup Variables")]
   Rigidbody2D body;
   float horizontal;
   float vertical;
   [Header("Base Movement Values")]
   [SerializeField]
   public float runSpeed = 20.0f;
   [Header("Dash Values")]
   [SerializeField]
   public float dashSpeed = 10f;
   [SerializeField]
   public float dashDuration = 0.2f;
   [SerializeField]
   public float dashCooldown = 1f;
   [SerializeField]
   private bool canDash = true;
   private Vector2 dashDirection;

void Start ()
{
   body = GetComponent<Rigidbody2D>(); 
}

void Update ()
{
   horizontal = Input.GetAxisRaw("Horizontal");
   vertical = Input.GetAxisRaw("Vertical"); 
   
   Vector2 moveDirection = new Vector2(horizontal, vertical).normalized;

      // Set the dash direction based on the player's movement
      if (moveDirection != Vector2.zero)
      {
         dashDirection = moveDirection;
      }
   
   if (Input.GetKeyDown(KeyCode.LeftShift) && canDash && dashDirection != Vector2.zero)
   {
      StartCoroutine(Dash());
   }
}

private void FixedUpdate()
{  
   body.velocity = new Vector2(horizontal * runSpeed, vertical * runSpeed);
   
}

IEnumerator Dash()
{
    // Prevent dashing if on cooldown
        canDash = false;

        // Store the player's initial position before dashing
        Vector2 dashStartPosition = body.position;

        // Dash towards the direction the player is moving
        float dashTime = 0f;
        while (dashTime < dashDuration)
        {
            body.MovePosition(dashStartPosition + dashDirection * dashSpeed * dashTime);
            dashTime += Time.deltaTime;
            yield return null;
        }

        // Wait for cooldown
        yield return new WaitForSeconds(dashCooldown);

        canDash = true;
}
}
