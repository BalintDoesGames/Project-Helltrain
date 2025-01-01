using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFire : MonoBehaviour
{
   public GameObject projectilePrefab;  // The projectile prefab to instantiate
    public float shootForce = 10f;       // Force applied to the projectile
    public float fireRate = 0.5f;        // How fast can the player shoot (in seconds)

    private float nextFireTime = 0f;

    void Update()
    {
        // Shoot when the left mouse button is pressed
        if (Input.GetMouseButton(0) && Time.time >= nextFireTime)
        {
            PrimaryFire();
            nextFireTime = Time.time + fireRate;  // Prevent shooting too often
        }
    }

    void PrimaryFire()
    {
        // Get the mouse position in world space
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePosition.z = 0f;  // Keep the projectile in the 2D plane (z=0)

        // Calculate the direction to the mouse position
        Vector2 direction = (mousePosition - transform.position).normalized;

        // Create the projectile at the player's position
        GameObject projectile = Instantiate(projectilePrefab, transform.position, Quaternion.identity);

        // Get the Rigidbody2D component and apply a force in the direction of the mouse
        Rigidbody2D rb = projectile.GetComponent<Rigidbody2D>();
        if (rb != null)
        {
            rb.velocity = direction * shootForce;
        }
    }

    

}
